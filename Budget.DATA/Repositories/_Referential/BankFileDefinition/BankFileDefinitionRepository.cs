using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class BankFileDefinitionRepository : BaseRepository<BankFileDefinition>, IBankFileDefinitionRepository
    {
        public BankFileDefinitionRepository(BudgetContext context) : base(context)
        {
        }

        public List<BankFileDefinition> GetAllWithNoUnknown()
        {
            return Context.BankFileDefinition.Where(x => x.Id != (int)EnumBankFamily.Inconnu).ToList();
        }
        
        public List<BankFileDefinition> GetByIdBankFamily(int idBankFamily)
        {
            return Context.BankFileDefinition
                .Where(x => x.IdBankFamily == idBankFamily)
                .OrderBy(x => x.LabelOrder)
                .ToList();
        }

    }
}
