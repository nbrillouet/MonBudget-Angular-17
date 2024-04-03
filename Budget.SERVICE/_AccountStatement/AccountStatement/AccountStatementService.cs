using AutoMapper;
using Budget.DATA.Repositories;
using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Dto.GMap;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using Budget.SERVICE.GMap;
using Mailjet.Client.Resources.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class AccountStatementService : IAccountStatementService
    {
        private readonly IMapper _mapper;
        private readonly IOperationTransverseAsService _operationTransverseAsService;
        private readonly ReferentialService _referentialService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;

        private readonly IAccountStatementRepository _accountStatementRepository;

        public AccountStatementService(
            IMapper mapper,
            IOperationTransverseAsService operationTransverseAsService,
            ReferentialService referentialService,
            IBusinessExceptionMessageService businessExceptionMessageService,

            IAccountStatementRepository accountStatementRepository
            )
        {
            _mapper = mapper;
            _operationTransverseAsService = operationTransverseAsService;
            _referentialService = referentialService;
            _businessExceptionMessageService = businessExceptionMessageService;

            _accountStatementRepository = accountStatementRepository;
        }

        public PagedList<AsForTable> GetTable(FilterAsTableSelected filter)
        {
            var pagedList = _accountStatementRepository.GetAsTable(filter);

            var result = new PagedList<AsForTable>(_mapper.Map<List<AsForTable>>(pagedList.Datas), pagedList.Pagination);

            foreach (var data in result.Datas)
            {
                //var toto = _planService.GetForSelectByIdAs(data.Id);
                ////data.Plans = 
                //data.Plans = _planService.GetForSelectByIdAs(data.Id);
            }
            return result;
        }

        public PagedList<AsForTable> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter)
        {
            var pagedList = _accountStatementRepository.GetPlanNotAsTable(filter);
            var result = new PagedList<AsForTable>(_mapper.Map<List<AsForTable>>(pagedList.Datas), pagedList.Pagination);

            return result;
        }

        public int GetPlanNotAsCount(FilterFixedPlanNotAsTableSelected filterFixed)
        {
            return _accountStatementRepository.GetPlanNotAsCount(filterFixed);
        }

        public AsForDetail GetForDetail(int idAs)
        {
            //var userForGroup = _userService.GetForUserGroup(idUser);
            AsForDetail asForDetail = GetById(idAs);
            //operationForDetail.User = userForGroup;

            return asForDetail;
        }

        private AsForDetail GetById(int idAs)
        {
            AccountStatement accountStatement = _accountStatementRepository.GetForDetail(idAs);
            var asForDetail = _mapper.Map<AsForDetail>(accountStatement);

            asForDetail.OperationTransverse = _operationTransverseAsService.GetOperationTransverseSelectList(idAs, EnumSelectType.Empty);

            return asForDetail;
        }

        public List<AsForTable> GetByPlanPosteReferences(Poste poste, List<PlanAccount> planAccounts, List<PlanPosteReference> planPosteReferences, MonthYear monthYear)
        {
            DateTime minDate = monthYear.Month.Id == (int)EnumMonth.BalanceSheetYear 
                ? Convert.ToDateTime($"01/01/{monthYear.Year}")
                : Convert.ToDateTime($"01/{monthYear.Month.Id}/{monthYear.Year}");
            
            DateTime maxDate = monthYear.Month.Id == (int)EnumMonth.BalanceSheetYear
                ? Convert.ToDateTime($"31/12/{monthYear.Year}")
                : DateHelper.GetLastDayOfMonth(minDate);
            
            var accountStatements = _accountStatementRepository.GetByDatePlanPosteReferenceList(poste, planAccounts, planPosteReferences, minDate, maxDate);

            return _mapper.Map<List<AsForTable>>(accountStatements);
        }

        //public Boolean Save(List<AccountStatement> accountStatements)
        //{
        //    return _accountStatementRepository.Save(accountStatements);
        //}

        public AccountStatement Create(AccountStatement accountStatement)
        {
            return Save(accountStatement);
            //if (!_accountStatementRepository.IsDuplicate(accountStatement))
            //    return _accountStatementRepository.Create(accountStatement);

            //return null;
        }

        public List<InternalTransferDto> GetAsInternalTransfer(FilterAsTableSelected filter)
        {
            List<InternalTransferDto> internalTransferDtos = new List<InternalTransferDto>();

            var date = Convert.ToDateTime($"01/{filter.MonthYear.Month.Id}/{filter.MonthYear.Year}");
            var dateMin = DateHelper.GetFirstDayOfMonth(date);
            var dateMax = DateHelper.GetLastDayOfMonth(date);

            var accountStatements = _accountStatementRepository.GetAsInternalTransfer(filter.User.IdUserGroup,filter.IdAccount, dateMin, dateMax);
            var asDtos = _mapper.Map<List<AsForTable>>(accountStatements);
            foreach(var asDtoFirst in asDtos)
            {
                AsForTable asDtoSecond=null; // = new AsForTableDto();
                AccountStatement asCouple = _accountStatementRepository.GetAsInternalTransferCouple(filter.User.IdUserGroup,asDtoFirst.Id);
                if (asCouple != null)
                {
                    var account = _referentialService.AccountService.GetFullById(asCouple.IdAccount);
                    asCouple.Account = account;
                    asDtoSecond = _mapper.Map<AsForTable>(asCouple);
                }

                InternalTransferDto internalTransferDto = new InternalTransferDto() {
                    AsFirst= asDtoFirst,
                    AsSecond = asDtoSecond
                };
                internalTransferDtos.Add(internalTransferDto);

            }

            return internalTransferDtos;
        }

        public List<AsForTable> GetAsInternalTransferOrphan(int idUserGroup)
        {
            List<AccountStatement> asOrphans = _accountStatementRepository.GetAsInternalTransferOrphan(idUserGroup);

            return _mapper.Map<List<AsForTable>>(asOrphans);
        }

        public void CheckAsInternalTransferOrphan(int idUserGroup)
        {
            var bingoUno = 0;
            var noCheck = 0;
            var multipleCheck = 0;
            //recuperer tous les it orphelins (id_account_statement_it null)
            List<AccountStatement> asOrphans = _accountStatementRepository.GetAsInternalTransferOrphan(idUserGroup);
            //pour chaque orphans, on recherche si une ou plusieurs operation sur autre compte le meme jour avec solde inverse
            foreach(var asOrphan in  asOrphans)
            {
                var asCoupleList = _accountStatementRepository.GetAsInternalTransferCouple(asOrphan);
                if (asCoupleList.Count == 1)
                {
                    asOrphan.IdAccountIt = asCoupleList[0].IdAccount;
                    asOrphan.IdAccountStatementIt = asCoupleList[0].Id;

                    _accountStatementRepository.Update(asOrphan);

                    bingoUno = bingoUno + 1;
                }
                else if(asCoupleList.Count == 0){
                    noCheck = noCheck + 1;
                }
                else if (asCoupleList.Count > 1)
                {
                    multipleCheck = multipleCheck + 1;
                }
            }

        }

        public List<int> GetYearAvailable(int idUser, int idAccount)
        {
            return _accountStatementRepository.GetYearAvailable(idUser, idAccount);
        }

        public AsForDetail Update(AsForDetail asForDetail)
        {

            AccountStatement accountStatement = CheckValues(asForDetail);

            //sauvegarde operationDetail
            asForDetail.OperationDetail.Operation = asForDetail.Operation;
            asForDetail.OperationDetail.IdUserGroup = asForDetail.Asi.User.IdUserGroup;
            OperationDetail operationDetail = _referentialService.OperationDetailService.CheckValues(asForDetail.OperationDetail);
            operationDetail = _referentialService.OperationDetailService.Save(operationDetail);

            accountStatement.IdOperationDetail = operationDetail.Id;


            //chargement du accountStatementFile
            //var asif = _accountStatementImportFileRepository.GetById(asifForDetail.Id);

            //mise à jour des données
            //asif.AmountOperation = asifForDetail.AmountOperation;
            //asif.DateIntegration = asifForDetail.DateIntegration.Value.Date;
            //asif.LabelOperation = asifForDetail.LabelOperation;
            //asif.IdOperation = asifForDetail.Operation.Id;
            //asif.IdOperationMethod = asifForDetail.OperationMethod.Id;
            //asif.IdOperationType = asifForDetail.OperationType.Id;
            //asif.IdOperationTypeFamily = asifForDetail.OperationTypeFamily.Id;
            //asif.OperationKeywordTemp = asifForDetail.OperationKeywordTemp;
            //asif.PlaceKeywordTemp = asifForDetail.PlaceKeywordTemp;

            //switch (asifForDetail.OperationPlace.Id)
            //{
            //    case 2:
            //        asifForDetail.OperationDetail.GMapAddress.Id = 2;
            //        asifForDetail.OperationDetail.KeywordPlace = null;
            //        break;
            //    case 3:
            //        asifForDetail.OperationDetail.GMapAddress.Id = 3;
            //        asifForDetail.OperationDetail.KeywordPlace = "--INTERNET--";
            //        break;
            //    default:
            //        break;
            //}


            //Recherche si operation detail existe déjà, sinon creation
            //var idOdUnknown = _referentialService.OperationDetailService.GetUnknown(asifForDetail.User.IdUserGroup).Id;
            //OperationDetail operationDetail = new OperationDetail
            //{
            //    Id = asifForDetail.OperationDetail.Id == idOdUnknown ? 0 : asifForDetail.OperationDetail.Id,
            //    IdUserGroup = asifForDetail.User.IdUserGroup,
            //    IdOperation = asifForDetail.Operation.Id,
            //    IdGMapAddress = asifForDetail.OperationDetail.GMapAddress.Id,
            //    KeywordOperation = asifForDetail.OperationDetail.KeywordOperation,
            //    KeywordPlace = asifForDetail.OperationDetail.KeywordPlace,

            //};
            //operationDetail = _referentialService.OperationDetailService.GetOrCreate(operationDetail);
            //asif.IdOperationDetail = operationDetail.Id;

            //Mise à jour de l'operationTransverse
            if (asForDetail.OperationTransverse != null && asForDetail.OperationTransverse.Count>0)
                _operationTransverseAsService.Update(asForDetail.OperationTransverse, asForDetail.Id);

            //Mise à jour de l'asifState et du duplicate
            //accountStatement = _accountStatementImportFileRepository.UpdateAsifState(asif);

            //sauvegarde as
            accountStatement = Save(accountStatement);// _accountStatementRepository.Update(accountStatement);

            return GetById(accountStatement.Id);

        }

        public AsForTable GetLastAccountStatement(int idAccount)
        {
            var accountStatement = _accountStatementRepository.GetLastAccountStatement(idAccount);
            return _mapper.Map<AsForTable>(accountStatement);// _accountStatementRepository.GetLastAccountStatement(idAccount);
        }

        private AccountStatement Save(AccountStatement accountStatement)
        {
            accountStatement = CheckInternalTransfer(accountStatement);
            if(accountStatement.Id == 0)
            {
                if (!_accountStatementRepository.IsDuplicate(accountStatement))
                    return _accountStatementRepository.Create(accountStatement);
            }
            else
                return _accountStatementRepository.Update(accountStatement);

            return null;
        }

        /// <summary>
        /// Recherche si otf est virement interne: dans ce cas il faut mettre à jour le champs id_as_it de account_statement
        /// </summary>
        /// <param name="accountStatement"></param>
        /// <returns></returns>
        private AccountStatement CheckInternalTransfer(AccountStatement accountStatement)
        {
            var otf = _referentialService.OperationTypeFamilyService.GetById(accountStatement.IdOperationTypeFamily);
            if(otf.Code==EnumOtf.VIRI.ToString())
            {
                //determination du compte source: ID_ACCOUNT_IT via le libellé operation Type
                var ot = _referentialService.OperationTypeService.GetById(accountStatement.IdOperationType);
                var accountNumber = ot.Label.Split('-')[3].Trim();
                var bankSubFamilyCode = ot.Label.Split('-')[2].Replace(">","").Trim();
                var account = _referentialService.AccountService.GetByNumber(accountNumber);
                
                accountStatement.IdAccountIt = account.Id;

                //determination de la ligne relevé source: ID_ACCOUNT_STATEMENT_IT
                var asIt= _accountStatementRepository.SearchInternalTransferCouple(accountStatement);
                accountStatement.IdAccountStatementIt = asIt?.Id;
            }
            else
            {
                accountStatement.IdAccountIt = null;
                accountStatement.IdAccountStatementIt = null;
            }

            return accountStatement;
        }

        private AccountStatement CheckValues(AsForDetail asForDetail)
        {
            var accountStatement = _accountStatementRepository.GetById(asForDetail.Id);

            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Check des données
            if (asForDetail.AmountOperation == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_001));
            }
            else
            {
                accountStatement.AmountOperation = asForDetail.AmountOperation.Value;
            }
            if (asForDetail.DateIntegration == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_002));
            }
            else
            {
                accountStatement.DateIntegration = asForDetail.DateIntegration.Value;
            }
            if (string.IsNullOrEmpty(asForDetail.LabelAs))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_003));
            }
            else
            {
                accountStatement.LabelAs = asForDetail.LabelAs;
            }
            if (asForDetail.Operation == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_004));
            }
            else
            {
                accountStatement.IdOperation = asForDetail.Operation.Id;
            }
            if (asForDetail.OperationMethod == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_005));
            }
            else
            {
                accountStatement.IdOperationMethod = asForDetail.OperationMethod.Id;
            }
            if (asForDetail.OperationType == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_006));
            }
            else
            {
                accountStatement.IdOperationType = asForDetail.OperationType.Id;
            }
            if (asForDetail.OperationTypeFamily == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_007));
            }
            else
            {
                accountStatement.IdOperationTypeFamily = asForDetail.OperationTypeFamily.Id;
            }

            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            return accountStatement;
        }

    }
}
