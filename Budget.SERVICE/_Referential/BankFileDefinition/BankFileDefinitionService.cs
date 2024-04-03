using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class BankFileDefinitionService : IBankFileDefinitionService
    {
        private readonly IBankFileDefinitionRepository _bankFileDefinitionRepository;

        public BankFileDefinitionService(IBankFileDefinitionRepository bankFileDefinitionRepository)
        {
            _bankFileDefinitionRepository = bankFileDefinitionRepository;
        }

        public BankFileDefinition GetById(int idBankFileDefinition)
        {
            return _bankFileDefinitionRepository.GetById(idBankFileDefinition);
        }

        public List<BankFileDefinition> GetAll()
        {
            return _bankFileDefinitionRepository.GetAll();
        }

        public List<BankFileDefinition> GetAllWithNoUnknown()
        {
            return _bankFileDefinitionRepository.GetAllWithNoUnknown();
        }

        public List<BankFileDefinition> GetByIdBankFamily(int idBankFamily)
        {
            return _bankFileDefinitionRepository.GetByIdBankFamily(idBankFamily);
        }

        //public List<GenericList> GetGenericList()
        //{
        //    return _bankFileDefinitionRepository.GetGenericList();
        //}


    }
}
