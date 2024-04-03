using Budget.MODEL;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IBankFileDefinitionRepository : IBaseRepository<BankFileDefinition>
    {
        List<BankFileDefinition> GetAllWithNoUnknown();
        List<BankFileDefinition> GetByIdBankFamily(int idBankFamily);

    }
}
