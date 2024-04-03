using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class AccountStatementCheckReferentialService: IAccountStatementCheckReferentialService
    {
        //private readonly IMapper _mapper;
        private readonly IAccountStatementRepository _accountStatementRepository;
        private readonly IAccountStatementImportFileRepository _accountStatementImportFileRepository;


        public AccountStatementCheckReferentialService(
            //IMapper mapper,
            IAccountStatementRepository accountStatementRepository,
            IAccountStatementImportFileRepository accountStatementImportFileRepository
            )
        {
            //_mapper = mapper;
            _accountStatementRepository = accountStatementRepository;
            _accountStatementImportFileRepository = accountStatementImportFileRepository;
        }

        public bool AsifHasOperation(int idOperation)
        {
            return _accountStatementImportFileRepository.HasOperation(idOperation);
        }

        public bool AsHasOperation(int idOperation)
        {
            return _accountStatementRepository.HasOperation(idOperation);
        }

        public bool AsifHasOt(int idOt)
        {
            return _accountStatementImportFileRepository.HasOt(idOt);
        }

        public bool AsHasOt(int idOt)
        {
            return _accountStatementRepository.HasOt(idOt);
        }
        public bool AsifHasOtf(int idOtf)
        {
            return _accountStatementImportFileRepository.HasOtf(idOtf);
        }
        public bool AsHasOtf(int idOtf)
        {
            return _accountStatementRepository.HasOtf(idOtf);
        }

        public bool AsHasAsi(int idAsi)
        {
            return _accountStatementRepository.HasAsi(idAsi);
        }
    }
}
