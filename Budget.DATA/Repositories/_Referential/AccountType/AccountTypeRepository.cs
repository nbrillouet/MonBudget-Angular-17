using Budget.MODEL.Database;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(BudgetContext context) : base(context)
        {
        }

        public List<AccountType> GetAllOrdering()
        {
            return Context.AccountType
                .OrderBy(x => x.Label)
                .ToList();
        }
    }
}
