using Budget.HELPER;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class VPlanGlobalRepository : BaseRepository<VPlanGlobal>, IVPlanGlobalRepository
    {
        public VPlanGlobalRepository(BudgetContext context) : base(context)
        {

        }

        public List<VPlanGlobal> Get(FilterPlanFollowUpSelected filter)
        {
            var planGlobals = Context.VPlanGlobal
                .AsQueryable();

            planGlobals = planGlobals.Where(x => x.IdPlan == filter.Plan.Id);

            //if (filter.MonthYear != null && filter.MonthYear.Month.Id!= (int)EnumMonth.BalanceSheetYear)
            //{
            //ajout systématique du mois 13 (prevision annuelle)
            planGlobals = planGlobals
                .Where(x => x.Year == filter.Plan.Year);
                    //.Where(x => (x.Month == (int)EnumMonth.BalanceSheetYear || x.Month == filter.MonthYear.Month.Id));
            //}
            
            var results = planGlobals.ToList();
            return results;
        }

        public List<VPlanGlobal> GetByIdPlan(int IdPlan)
        {
            var planGlobals = Context.VPlanGlobal
                .Where(x => x.IdPlan == IdPlan && x.IdAccountStatement!=null)
                .ToList();

            return planGlobals;
        }

        public List<VPlanGlobal> GetByIdAccountStatement(int idAs)
        {
            var results = Context.VPlanGlobal
                .Where(x => x.IdAccountStatement == idAs)
                .ToList();

            return results;
        }
    }
}
