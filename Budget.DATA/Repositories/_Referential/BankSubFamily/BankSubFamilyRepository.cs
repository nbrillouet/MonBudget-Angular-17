using Budget.MODEL.Database;
using System.Collections.Generic;
using System.Linq;

namespace Budget.DATA.Repositories
{
    public class BankSubFamilyRepository : BaseRepository<BankSubFamily>, IBankSubFamilyRepository
    {
        public BankSubFamilyRepository(BudgetContext context) : base(context)
        {
        }

        public List<BankSubFamily> GetAllOrdering()
        {
            return Context.BankSubFamily
                .OrderBy(x => x.Label)
                .ToList();
        }

        public List<BankSubFamily> GetByIdBankFamily(int idBankFamily)
        {
            return Context.BankSubFamily
                .Where(x=>x.IdBankFamily== idBankFamily)
                .OrderBy(x => x.Label)
                .ToList();
        }

    }
}
