using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Budget.MODEL;
using Budget.MODEL.Database;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using Budget.MODEL.Dto;
using Budget.DATA.Repositories.ContextTransaction;
using AutoMapper;
using Budget.MODEL.Enum;

namespace Budget.SERVICE
{
    public class AccountStatementImportService : IAccountStatementImportService
    {
        private readonly IMapper _mapper;
        private readonly IAccountStatementImportRepository _accountStatementImportRepository;
        private readonly IBankFileDefinitionService _bankFileDefinitionService;
        private readonly IAccountStatementImportFileService _accountStatementImportFileService;
        private readonly IAccountService _accountService;
        private readonly IParameterService _parameterService;
        private readonly IContextTransaction _contextTransaction;
        private readonly IBanquePopulaireImportFileService _banquePopulaireImportFileService;
        private readonly ICreditAgricoleImportFileService _creditAgricoleImportFileService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IAccountStatementCheckReferentialService _accountStatementCheckReferentialService;

        public AccountStatementImportService(
            IMapper mapper,
            IAccountStatementImportRepository accountStatementImportRepository,
            IBankFileDefinitionService bankFileDefinitionService,
            IAccountStatementImportFileService accountStatementImportFileService,
            IAccountService accountService,
            IParameterService parameterService,
            IContextTransaction contextTransaction,
            IBanquePopulaireImportFileService banquePopulaireImportFileService,
            ICreditAgricoleImportFileService creditAgricoleImportFileService,
            IBusinessExceptionMessageService businessExceptionMessageService,
            IAccountStatementCheckReferentialService accountStatementCheckReferentialService
            )
        {
            _mapper = mapper;
            _accountStatementImportRepository = accountStatementImportRepository;
            _bankFileDefinitionService = bankFileDefinitionService;
            _accountStatementImportFileService = accountStatementImportFileService;
            _accountService = accountService;
            _parameterService = parameterService;
            _contextTransaction = contextTransaction;
            _banquePopulaireImportFileService = banquePopulaireImportFileService;
            _creditAgricoleImportFileService = creditAgricoleImportFileService;
            _businessExceptionMessageService = businessExceptionMessageService;
            _accountStatementCheckReferentialService = accountStatementCheckReferentialService;
        }

        private List<BankAgency> GetDistinctBankAgencies(int idUser)
        {
            return _accountStatementImportRepository.GetDistinctBankAgencies(idUser);
        }

        public PagedList<AsiForTableDto> GetAsiTable(FilterAsiTableSelected filter)
        {
            var pagedList = _accountStatementImportRepository.GetAsiTable(filter);

            var result = new PagedList<AsiForTableDto>(_mapper.Map<List<AsiForTableDto>>(pagedList.Datas), pagedList.Pagination);

            return result;
        }

        public AsiForList GetAsiForList(int idUser)
        {

            AsiForList asiForList = new AsiForList();
            var bankAgencies = _accountStatementImportRepository.GetDistinctBankAgencies(idUser);
            foreach (var bankAgency in bankAgencies) {
                AsiListByBankAgency asiByBankAgency = new AsiListByBankAgency();
                asiByBankAgency.BankAgency = _mapper.Map<BankAgencyDto>(bankAgency);
                asiByBankAgency.AsiForList = GetByIdBankAgency(bankAgency.Id, idUser);

                asiForList.AsiByBankAgencyList.Add(asiByBankAgency);
            }
            asiForList.CountBankAgency = asiForList.AsiByBankAgencyList.Count();

            var t = asiForList.AsiByBankAgencyList.Sum(x => x.AsiForList.Count());
            asiForList.CountAsiFile = t;

            return asiForList;
        }

        //public ValueTask<AccountStatementImport> GetByIdAsync(int idImport)
        //{
        //    return _accountStatementImportRepository.GetByIdAsync(idImport);
        //}

        public AccountStatementImport GetEagerById (int idImport)
        {
            return _accountStatementImportRepository.GetEagerById(idImport);
        }

        public AsiForTableDto GetByIdForData(int idImport)
        {
            var result = GetEagerById(idImport);
            return _mapper.Map<AsiForTableDto>(result);
        }

        public AsiForListDto GetForDetailById(int idImport)
        {
            var result = _accountStatementImportRepository.GetByIdForDetail(idImport);

            return _mapper.Map<AsiForListDto>(result);
        }

        public AccountStatementImport ImportFile(StreamReader reader, User user)
        {
            //Boolean firstLine = true;

            //verifier en tete fichier selon banque: rejet ou definit la banque
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains(';'))
                {
                    var values = line.Split(';');

                    EnumBankFamily enumBankFamily = GetFileBankType(values);
                    switch (enumBankFamily)
                    {
                        case EnumBankFamily.BanquePopulaire:
                            return ImportFileBanquePopulaire(reader, user);
                        case EnumBankFamily.CreditAgricole:
                            return ImportFileCreditAgricole(reader, user);

                    }
                }
            }
            throw new Exception("Type de fichier incorrect");
        }

        public UserForGroupDto GetUserForGroup(int idImport)
        {
            var user = _accountStatementImportRepository.GetUser(idImport);
            return _mapper.Map<UserForGroupDto>(user);
        }

        private List<AsiForListDto> GetByIdBankAgency(int idBankAgency, int idUser)
        {
            var asiList = _accountStatementImportRepository.GetByIdBankAgency(idBankAgency, idUser);

            return _mapper.Map<List<AsiForListDto>>(asiList);
        }

        private EnumBankFamily GetFileBankType(string[] header)
        {
            if (_banquePopulaireImportFileService.isBanquePopulaireFile(header))
                return EnumBankFamily.BanquePopulaire;
            else if (_creditAgricoleImportFileService.isCreditAgricoleFile(header))
                return EnumBankFamily.CreditAgricole;
            else
                return EnumBankFamily.Inconnu;
        }

        private AccountStatementImport ImportFileBanquePopulaire(StreamReader reader, User user)
        {
            List<string> accountNumbers = GetAccountNumbers(reader,0);

            BankAgency bankAgency = GetImportFileBank(reader, accountNumbers);
            var accountStatementImport = Create(bankAgency, reader, user);
            //accountStatementImport = _accountStatementImportRepository.Create(accountStatementImport);
            
            accountStatementImport = _accountStatementImportRepository.GetByIdForDetail(accountStatementImport.Id);
            var asiForDetail = _mapper.Map<AsiForDetail>(accountStatementImport);

            List<AccountStatementImportFile> accountStatementImportFiles = _banquePopulaireImportFileService.ImportFile(reader, asiForDetail);
            _accountStatementImportFileService.SaveWithTran(accountStatementImportFiles);

            _contextTransaction.Commit();

            return accountStatementImport;
        }

        private AccountStatementImport ImportFileCreditAgricole(StreamReader reader, User user)
        {
            var caReader = _creditAgricoleImportFileService.IsFormatFile(reader)
                ? _creditAgricoleImportFileService.GetFormatFile(reader,user)
                : _creditAgricoleImportFileService.FormatFile(reader, user);
            //var caReader = _creditAgricoleImportFileService.FormatFile(reader, user);
            try
            {
                List<String> accountNumbers = GetAccountNumbers(caReader, 0);

                BankAgency bankAgency = GetImportFileBank(reader, accountNumbers);
                var accountStatementImport = Create(bankAgency, reader, user);
                //accountStatementImport = SaveWithTran(accountStatementImport);
                var asiForDetail = _mapper.Map<AsiForDetail>(accountStatementImport);

                List<AccountStatementImportFile> accountStatementImportFiles = _creditAgricoleImportFileService.ImportFile(caReader, asiForDetail);
                _accountStatementImportFileService.SaveWithTran(accountStatementImportFiles);

                _contextTransaction.Commit();


                return accountStatementImport;
            }
            catch(Exception e)
            {
                caReader.Close();
                caReader.Dispose();
                throw e;
            }
        }

        private AccountStatementImport Create(BankAgency bankAgency, StreamReader reader, User user)
        {
            AccountStatementImport accountStatementImport = new AccountStatementImport
            {
                IdBankAgency = bankAgency.Id,
                FileImport = String.Format("{0}_{1}.csv", DateTime.Now.ToString("yyyyMMdd"), bankAgency.BankSubFamily.Code),
                DateImport = DateTime.Now,
                File = reader,
                IdUser = user.Id,
                User = user
            };
            accountStatementImport = _accountStatementImportRepository.Create(accountStatementImport);

            return accountStatementImport;
        }

        public AccountStatementImport SaveWithTran(AccountStatementImport accountStatementImport)
        {
            //if (accountStatementImport.Id == 0)
            //{
                //Enregistrement
            var asi = _accountStatementImportRepository.CreateWithTran(accountStatementImport);
            accountStatementImport = _accountStatementImportRepository.GetById(asi.Id);

            //Enregistrement du fichier
            //chemin d'enregistrement
            //string dir = _parameterService.GetImportFileDir(accountStatementImport.User.Id);
            //if (String.IsNullOrEmpty(dir))
            //{
            //    throw new Exception($"Veuillez configurer un dossier de sauvegarde des relevés dans Rérérentiel/utilisateur avant de poursuivre.");
            //}
            //dir = dir + accountStatementImport.BankAgency.BankSubFamily.LabelShort + "\\";
            //accountStatementImport.File.DiscardBufferedData();

            //accountStatementImport.File.BaseStream.Seek(0, SeekOrigin.Begin);
            //using (var writer = new StreamWriter(dir + accountStatementImport.FileImport, append: false, encoding: Encoding.GetEncoding(1252)))
            //{
            //    writer.Write(accountStatementImport.File.ReadToEnd());
            //}

            _accountStatementImportRepository.CreateWithTran(accountStatementImport);


           
            //}
            //else
            //    _accountStatementImportRepository.Update(accountStatementImport);

            return accountStatementImport;
        }

        public BankAgency GetImportFileBank(StreamReader reader, List<String> accountNumbers)
        {
            Account firstAccount = _accountService.GetByNumber(accountNumbers[0]);
            if (firstAccount != null)
            {
                foreach (var accountNumber in accountNumbers)
                {
                    var account = _accountService.GetByNumber(accountNumber);
                    if (account == null)
                        throw new Exception($"Compte bancaire inconnu: {accountNumber}");
                    if (account.IdBankAgency != firstAccount.BankAgency.Id)
                        throw new Exception($"Ce compte: {accountNumber}, n'est pas un compte de: {firstAccount.BankAgency.BankSubFamily.Code}");
                }
            }
            else
                throw new Exception($"Compte inconnu: {accountNumbers[0]}");

            return firstAccount.BankAgency;
        }

        private List<string> GetAccountNumbers(StreamReader reader,int indexAccount)
        {
            List<string> accountNumbers = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                accountNumbers.Add(values[indexAccount].ToString());
            }
            var accountNumbersGroups = accountNumbers
                .GroupBy(x => x);

            accountNumbers = new List<string>();
            foreach (var accountNumbersGroup in accountNumbersGroups)
            {
                accountNumbers.Add(accountNumbersGroup.Key);
            }
            return accountNumbers;
        }

        public void DeleteList(List<int> idAsiList)
        {
            CheckForDeleteList(idAsiList);
            foreach (var idAsi in idAsiList)
            {
                _accountStatementImportFileService.DeleteByIdImport(idAsi);
                Delete(idAsi);

            }
        }

        private void CheckForDeleteList(List<int> idAsiList)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            foreach (var idAsi in idAsiList)
            {
                var asi = _accountStatementImportRepository.GetById(idAsi);
                businessExceptionMessages.AddRange(CheckForDelete(asi));
            }

            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private void Delete(AccountStatementImport asi)
        {
            _accountStatementImportRepository.Delete(asi);
        }

        private bool Delete(int idAsi)
        {
            var asi = _accountStatementImportRepository.GetById(idAsi);

            _accountStatementImportRepository.Delete(asi);

            return true;
        }

        private List<BusinessExceptionMessage> CheckForDelete(AccountStatementImport asi)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();

            //Recherche si import utilisé dans account statement file
            if (_accountStatementCheckReferentialService.AsHasAsi(asi.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_ASI_ERR_000));
            }

            return businessExceptionMessages;
        }

    }
}
