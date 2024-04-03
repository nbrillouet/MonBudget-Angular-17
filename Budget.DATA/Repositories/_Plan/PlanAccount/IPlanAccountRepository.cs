using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanAccountRepository : IBaseRepository<PlanAccount>
    {
        List<Account> GetSelectAccountByIdPlan(int idPlan);
        List<PlanAccount> GetByIdPlan(int idPlan);
    }

}
