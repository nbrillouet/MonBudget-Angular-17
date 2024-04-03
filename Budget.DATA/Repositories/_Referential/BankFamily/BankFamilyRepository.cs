using Budget.MODEL.Database;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Repositories
{
    public class BankFamilyRepository : BaseRepository<BankFamily>, IBankFamilyRepository
    {
        public BankFamilyRepository(BudgetContext context) : base(context)
        {
        }

        public List<BankFamily> GetAllOrdering()
        {
            return Context.BankFamily
                .Include(x=>x.Asset)
                .OrderBy(x => x.Label)
                .ToList();
        }

        public BankFamily GetByCode(string code)
        {
            return Context.BankFamily
                .Include(x => x.Asset)
                .Where(x=>x.Code==code)
                .FirstOrDefault();
        }

    }


}
