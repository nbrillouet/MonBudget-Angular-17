using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        public PlanRepository(BudgetContext context) : base(context)
        {

        }

        public PagedList<Plan> GetPlanTable(FilterPlanTableSelected filter)
        {
            var plans = Context.PlanUser
                .Include(x=>x.Plan)
                .Include(x=>x.User)
                .AsQueryable();

            plans = plans.Where(x => x.IdUser == filter.User.Id);
            plans = plans.Where(x => x.Plan.Year == filter.Year);
            var plan = plans.Select(x => x.Plan).AsQueryable();

            //plans = GenericTableFilter.GetGenericFilters(plans, filter);

            return PagedListRepository<Plan>.Create(plan, filter.Pagination);
            //return null;
            //return PagedListRepository<Plan>.Create(plans, filter.Pagination);
        }

        public List<Int32> GetDistinctYears()
        {
            var results = Context.Plan
                .Select(x => x.Year)
                .Distinct()
                .ToList();

            return results;
        }

        public new int Create(Plan plan)
        {
            Context.Set<Plan>().Add(plan);

            Context.SaveChanges();

            return plan.Id;
        }
    }
}
