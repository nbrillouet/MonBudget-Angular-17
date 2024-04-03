using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanAccountRepository : BaseRepository<PlanAccount>, IPlanAccountRepository
    {
        public PlanAccountRepository(BudgetContext context) : base(context)
        {

        }

        public List<Account> GetSelectAccountByIdPlan(int idPlan)
        {
            var results = Context.PlanAccount
                .Where(x => x.IdPlan == idPlan)
                .Select(x => x.Account)
                .ToList();

            return results;
        }

        public List<PlanAccount> GetByIdPlan(int idPlan)
        {
            var results = Context.PlanAccount
                .Where(x => x.IdPlan == idPlan)
                .ToList();

            return results;
        }


    }

}
