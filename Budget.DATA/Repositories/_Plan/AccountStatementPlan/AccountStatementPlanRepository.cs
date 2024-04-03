//using Budget.MODEL.Database;
//using Budget.MODEL.Filter;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Budget.DATA.Repositories
//{
//    public class AccountStatementPlanRepository : BaseRepository<AccountStatementPlan>, IAccountStatementPlanRepository
//    {
//        public AccountStatementPlanRepository(BudgetContext context) : base(context)
//        {

//        }

//        public List<AccountStatementPlan> GetByIdPlan(int IdPlan)
//        {
//            var accountStatementPlans = Context.AccountStatementPlan
//                .Where(x => x.IdPlan == IdPlan)
//                .ToList();

//            return accountStatementPlans;
//        }

//        public List<AccountStatementPlan> GetPlansByIdAccountStatement(int IdAccountStatement, int year)
//        {
//            var accountStatementPlans = Context.AccountStatementPlan
//                .Where(x => x.IdAccountStatement == IdAccountStatement
//                    && x.Plan.Year == year)
//                .Include(x => x.Plan)
//                .ToList();

//            return accountStatementPlans;
//        }

        

//    }

//}
