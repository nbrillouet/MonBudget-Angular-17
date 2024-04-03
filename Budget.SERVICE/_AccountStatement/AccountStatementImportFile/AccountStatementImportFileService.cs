using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Budget.MODEL.Dto;
using AutoMapper;
using System.Linq;
using Budget.MODEL;
using Budget.MODEL.Filter;
using System.Threading.Tasks;
using Budget.SERVICE.GMap;
using Budget.SERVICE._Helpers;
using Budget.MODEL.Dto.GMap;
using Budget.MODEL.Enum;

namespace Budget.SERVICE
{
    public class AccountStatementImportFileService : IAccountStatementImportFileService
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IAccountStatementService _accountStatementService;
        private readonly IOperationTransverseAsifService _operationTransverseAsifService;
        private readonly IOperationTransverseAsService _operationTransverseAsService;
        private readonly IGMapAddressService _gMapAddressService;
        private readonly ReferentialService _referentialService;
        private readonly IUserService _userService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;

        private readonly IAccountStatementImportRepository _accountStatementImportRepository;
        private readonly IAccountStatementImportFileRepository _accountStatementImportFileRepository;

        public AccountStatementImportFileService(
            IAccountStatementImportFileRepository accountStatementImportFileRepository,
            IAccountService accountService,
            IMapper mapper,
            IAccountStatementService accountStatementService,
            IOperationTransverseAsifService operationTransverseAsifService,
            IOperationTransverseAsService operationTransverseAsService,
            IGMapAddressService gMapAddressService,
            IUserService userService,
            IBusinessExceptionMessageService businessExceptionMessageService,

            IAccountStatementImportRepository accountStatementImportRepository,
            ReferentialService referentialService
            )
        {
            _accountStatementImportFileRepository = accountStatementImportFileRepository;
            _mapper = mapper;
            _accountService = accountService;
            _accountStatementService = accountStatementService;
            _operationTransverseAsifService = operationTransverseAsifService;
            _operationTransverseAsService = operationTransverseAsService;
            _gMapAddressService = gMapAddressService;
            _userService = userService;
            _businessExceptionMessageService = businessExceptionMessageService;

            _accountStatementImportRepository = accountStatementImportRepository;
            _referentialService = referentialService;
        }

        public PagedList<AsifForTable> GetAsifTable(FilterAsifTableSelected filter)
        {
            var pagedList = _accountStatementImportFileRepository.GetAsifTable(filter);

            var result = new PagedList<AsifForTable>(_mapper.Map<List<AsifForTable>>(pagedList.Datas), pagedList.Pagination);

            return result;
        }

        public AsForDetail GetForDetail(int idAsif)
        {
            AsForDetail asForDetail = GetById(idAsif);

            return asForDetail;
        }

        private AsForDetail GetById(int idAsif)
        {
            AccountStatementImportFile asif = _accountStatementImportFileRepository.GetForDetail(idAsif);

            var asifForDetail = _mapper.Map<AsifForDetail>(asif);
            //var asifForDetail = _mapper.Map<AsifForDetail>(asif);

            //asifForDetail.User = _mapper.Map<UserForGroupDto>(_accountStatementImportRepository.GetUser(asif.IdImport));
            asifForDetail.Asi = _mapper.Map<AsiForDetail>(_accountStatementImportRepository.GetByIdForDetail(asif.IdImport));
            asifForDetail.Account = _mapper.Map<AccountForDetail>(_referentialService.AccountService.GetForDetail(asif.IdAccount));
            asifForDetail.OperationDetail = asif.IdOperationDetail.HasValue 
                ? _mapper.Map<OperationDetailDto>(_referentialService.OperationDetailService.GetForDetail(asif.IdOperationDetail.Value))
                : null;
            asifForDetail.OperationTransverse = _operationTransverseAsService.GetOperationTransverseSelectList(idAsif, EnumSelectType.Empty);

            if(asifForDetail.OperationDetail == null)
            {
                asifForDetail.OperationDetail = new OperationDetailDto
                {
                    Id = 0,
                    GMapAddress = null,
                    KeywordOperation = asif.OdOperationKeyword,
                    KeywordPlace = asif.OdPlaceKeyword,
                    Operation = asifForDetail.Operation,
                    OperationLabel = asif.OdOperationLabel,
                    OperationPlace = GetOperationPlaceByDefault(asifForDetail),
                    PlaceLabel = asif.OdPlaceLabel
                };
            }
            else
            {
                EnumLanguage enumLanguage = _userService.GetUserPreference(asifForDetail.Asi.User.Id).Language.ToEnum<EnumLanguage>();
                asifForDetail.OperationDetail.GMapAddress = asif.OperationDetail.IdGMapAddress.HasValue ? _gMapAddressService.GetById(asif.OperationDetail.IdGMapAddress.Value, enumLanguage) : null;
            }

            return _mapper.Map<AsForDetail>(asifForDetail);
        }

        public List<AccountStatementImportFile> GetByIdImport(int idImport)
        {
            return _accountStatementImportFileRepository.GetByIdImport(idImport);
        }

        public List<string> GetDistinctAccountNumber(int idImport)
        {
            return _accountStatementImportFileRepository.GetDistinctAccountNumber(idImport);
        }

        public void SaveWithTran(List<AccountStatementImportFile> accountStatementImportFiles)
        {
            _accountStatementImportFileRepository.SaveWithTran(accountStatementImportFiles);
        }

        private SelectCode GetOperationPlaceByDefault(AsifForDetail asifForDetail)
        {
            //operationPlace = NA si operation method pas retrait ou paiement par carte
            if (asifForDetail.OperationMethod.Id == (int)EnumOperationMethod.PaiementCarte)
                return null;
            if (asifForDetail.OperationMethod.Id == (int)EnumOperationMethod.RetraitCarte)
                return null;

            //retour operationplace de type NA
            return _referentialService.OperationPlaceService.GetSelectById((int)EnumOperationPlace.NA);
        }

        //public AccountStatementImportFile InitForImport(int idUserGroup)
        //{
        //    var accountStatementImportFile = new AccountStatementImportFile();
        //    UnknownId unknownId = GetUnknownIds(idUserGroup);
        //    accountStatementImportFile.UnknownId = unknownId;

        //    accountStatementImportFile.IdAccount = unknownId.IdAccount;
        //    accountStatementImportFile.IdOperationMethod = unknownId.IdOperationMethod;
        //    accountStatementImportFile.IdOperation = unknownId.IdOperation;
        //    accountStatementImportFile.IdOperationDetail = unknownId.IdOperationDetail;
        //    accountStatementImportFile.IdOperationTypeFamily = unknownId.IdOperationTypeFamily;
        //    accountStatementImportFile.IdOperationType = unknownId.IdOperationType;

        //    return accountStatementImportFile;
        //}

        //private UnknownId GetUnknownIds(int idUserGroup)
        //{
        //    return new UnknownId
        //    {
        //        IdAccount = (int)EnumAccount.Inconnu,
        //        IdOperationMethod = (int)EnumOperationMethod.Inconnu,
        //        IdOperation = _referentialService.OperationService.GetUnknown(idUserGroup).Id,
        //        IdOperationDetail = _referentialService.OperationDetailService.GetUnknown(idUserGroup).Id,
        //        IdOperationTypeFamily = _referentialService.OperationTypeFamilyService.GetByCodeUserGroupForSelect(EnumOtf.INCO, idUserGroup).Id,
        //        IdOperationType = _referentialService.OperationTypeService.GetUnknown(idUserGroup).Id
        //    };
        //}

        /// <summary>
        /// Nettoie le label operation provenant dun fichier
        /// </summary>
        /// <param name="operationLabel"></param>
        /// <returns></returns>
        public string GetOperationLabelWork(string operationLabel)
        {
            string trimOperationLabel = operationLabel.ToUpper();

            trimOperationLabel = FileHelper.ExcludeForbiddenChars(trimOperationLabel);
            trimOperationLabel = trimOperationLabel.Replace(" ", "");

            return trimOperationLabel;
        }

        public AsifGroupByAccounts GetListDto(int idImport)
        {
            AsifGroupByAccounts asifGroupByAccounts = new AsifGroupByAccounts
            {
                IdImport = idImport,
                Accounts = GetAccounts(idImport)
            };

            return asifGroupByAccounts;
        }

        private List<Account> GetAccounts(int idImport)
        {
            //selectionner les account number distincts dans l'import
            List<Account> accounts = new List<Account>();
            var accountNumbers = GetDistinctAccountNumber(idImport);
            foreach (string accountNumber in accountNumbers)
            {
                accounts.Add(_accountService.GetByNumber(accountNumber));
            }

            return accounts;
        }

        public List<Select> GetAccountSelectListByIdImport(int idImport)
        {
            List<Select> accounts = new List<Select>();
            var accountNumbers = GetDistinctAccountNumber(idImport);
            foreach (string accountNumber in accountNumbers)
            {
                accounts.Add(_mapper.Map<Select>(_accountService.GetByNumber(accountNumber)));
            }

            return accounts;
        }

        public List<Select> GetAsifStates(int idImport, int idAccount)
        {
            return _accountStatementImportFileRepository.GetAsifStates(idImport, idAccount);
        }

        public bool SaveInAccountStatement(int idImport)
        {
            //Chargement des AccountStatementFile
            var asifs = GetByIdImport(idImport);

            if (asifs == null || asifs.Count == 0)
                return false;
            

            foreach(var asif in asifs)
            {
                //Mise à jour des state et des duplicate
                _accountStatementImportFileRepository.Save(asif);
            }

            //controler si tous les enregistrements sont complets
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            if (!IsSaveableInAccountStatement(idImport))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_001));
                throw new BusinessException(businessExceptionMessages);
            }

            //recuperer les accountStatementImportFiles
            var accountStatementImportFiles = GetAsifsWithoutDuplicate(idImport);

            foreach(var accountStatementImportFile in accountStatementImportFiles)
            {
                var accountStatement = _mapper.Map<AccountStatement>(accountStatementImportFile);
                accountStatement = _accountStatementService.Create(accountStatement);
                if(accountStatement!=null)
                {
                    //Recherche si operation transverse a enregistrer
                    var operationTranserveAsifs = _operationTransverseAsifService.GetByIdAsif(accountStatementImportFile.Id);
                    foreach(var operationTranserveAsif in operationTranserveAsifs)
                    {
                        var operationTransverseAs = new OperationTransverseAs
                        {
                            Id = 0,
                            IdAccountStatement = accountStatement.Id,
                            IdOperationTransverse = operationTranserveAsif.IdOperationTransverse
                        };
                        _operationTransverseAsService.Save(operationTransverseAs);

                    }
                }
            }
            //sauvegarder dans accountStatement
            return true;
 

        }

        /// <summary>
        /// renvoie les lignes a sauvegarder dans accountStatement (pas de doublons)
        /// </summary>
        /// <param name="idImport"></param>
        /// <returns></returns>
        private List<AccountStatementImportFile> GetAsifsWithoutDuplicate(int idImport)
        {
            var accountStatementImports = _accountStatementImportFileRepository.GetAsifsWithoutDuplicate(idImport);

            return accountStatementImports;
        }

        /// <summary>
        /// controler si tous les enregistrements sont complets
        /// </summary>
        /// <param name="idImport"></param>
        /// <returns></returns>
        public bool IsSaveableInAccountStatement(int idImport)
        {
            return _accountStatementImportFileRepository.IsAccountStatementSaveable(idImport);
        }

        public AsForDetail SaveAsifDetail(AsForDetail asForDetail)
        {
            AccountStatementImportFile asif = CheckValues(asForDetail);

            //sauvegarde operationDetail
            asForDetail.OperationDetail.Operation = asForDetail.Operation;
            asForDetail.OperationDetail.IdUserGroup = asForDetail.Asi.User.IdUserGroup;
            OperationDetail operationDetail = _referentialService.OperationDetailService.CheckValues(asForDetail.OperationDetail);
            operationDetail = _referentialService.OperationDetailService.Save(operationDetail);

            asif.IdOperationDetail = operationDetail.Id;

            //Mise à jour de l'operationTransverse
            if (asForDetail.OperationTransverse != null && asForDetail.OperationTransverse.Count>0)
                _operationTransverseAsService.Update(asForDetail.OperationTransverse, asForDetail.Id);

            //Mise à jour de l'asifState et du duplicate
            asif = _accountStatementImportFileRepository.UpdateAsifState(asif);

            //sauvegarde asif
            asif = _accountStatementImportFileRepository.Save(asif);

            return GetById(asif.Id);

        }

        private AccountStatementImportFile CheckValues(AsForDetail asForDetail)
        {
            var asif = _accountStatementImportFileRepository.GetById(asForDetail.Id);

            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Check des données
            if (asForDetail.AmountOperation==null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_001));
            }
            else
            {
                asif.AmountOperation = asForDetail.AmountOperation.Value;
            }
            if (asForDetail.DateIntegration == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_002));
            }
            else
            {
                asif.DateIntegration = asForDetail.DateIntegration.Value;
            }
            if (string.IsNullOrEmpty(asForDetail.LabelAs))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_003));
            }
            else
            {
                asif.LabelAs = asForDetail.LabelAs;
            }
            if (asForDetail.Operation==null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_004));
            }
            else
            {
                asif.IdOperation = asForDetail.Operation.Id;
            }
            if (asForDetail.OperationMethod == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_005));
            }
            else
            {
                asif.IdOperationMethod = asForDetail.OperationMethod.Id;
            }
            if (asForDetail.OperationType == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_006));
            }
            else
            {
                asif.IdOperationType = asForDetail.OperationType.Id;
            }
            if (asForDetail.OperationTypeFamily == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AS_ERR_007));
            }
            else
            {
                asif.IdOperationTypeFamily = asForDetail.OperationTypeFamily.Id;
            }
            
            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            return asif;
        }

        public OperationDetail GetOperationDetail(AsifForDetail asifForDetail)
        {
            OperationDetail operationDetail=null;
            if(asifForDetail.OperationMethod!=null)
            {
                if (asifForDetail.OperationMethod.Id == (int)EnumOperationMethod.PaiementCarte || asifForDetail.OperationMethod.Id == (int)EnumOperationMethod.RetraitCarte)
                {
                    operationDetail = _referentialService.OperationDetailService.GetByKeywords(asifForDetail.Asi.User.IdUserGroup, asifForDetail.LabelAsWork, asifForDetail.OperationMethod.Id, (EnumMovement)asifForDetail.IdMovement);
                }
                else
                {
                    operationDetail = _referentialService.OperationDetailService.GetByKeywordOperation(asifForDetail.Asi.User.IdUserGroup, asifForDetail.LabelAsWork, asifForDetail.OperationMethod.Id, (EnumMovement)asifForDetail.IdMovement);
                }
            }

            return operationDetail;
        }

        public void DeleteByIdImport(int idImport)
        {
            List<AccountStatementImportFile> accountStatementImportFiles = _accountStatementImportFileRepository.GetByIdImport(idImport);
            foreach(var accountStatementImportFile in accountStatementImportFiles)
            {
                _accountStatementImportFileRepository.Delete(accountStatementImportFile);
            }
        }


    }
}
