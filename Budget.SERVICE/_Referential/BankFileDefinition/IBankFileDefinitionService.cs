using Budget.MODEL;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IBankFileDefinitionService
    {
        List<BankFileDefinition> GetByIdBankFamily(int idBankFamily);
        BankFileDefinition GetById(int idBankFileDefinition);
        List<BankFileDefinition> GetAll();
        List<BankFileDefinition> GetAllWithNoUnknown();
        //List<GenericList> GetGenericList();
    }
}
