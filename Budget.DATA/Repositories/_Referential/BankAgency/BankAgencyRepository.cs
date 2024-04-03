using Budget.MODEL.Database;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Repositories
{
    public class BankAgencyRepository : BaseRepository<BankAgency>, IBankAgencyRepository
    {
        public BankAgencyRepository(BudgetContext context) : base(context)
        {
        }

        public List<BankAgency> GetAllOrdering()
        {
            return Context.BankAgency
                .OrderBy(x => x.Label)
                .ToList();
        }

        public List<BankAgency> GetByIdBankSubFamily(int idBankSubFamily)
        {
            return Context.BankAgency
                .Where(x=>x.IdBankSubFamily== idBankSubFamily)
                .Include(x=>x.GMapAddress)
                .OrderBy(x => x.Label)
                .ToList();
        }

    }

}
