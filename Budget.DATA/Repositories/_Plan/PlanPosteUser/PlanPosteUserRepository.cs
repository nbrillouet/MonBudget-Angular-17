using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanPosteUserRepository : BaseRepository<PlanPosteUser>, IPlanPosteUserRepository
    {
        public PlanPosteUserRepository(BudgetContext context) : base(context)
        {

        }

        public List<PlanPosteUser> GetByIdPlanPoste(int idPlanPoste)
        {
            var planPosteUsers = Context.PlanPosteUser
                .Where(x => x.IdPlanPoste == idPlanPoste)
                .Include(x => x.PlanUser.User)
                .ToList();
            return planPosteUsers;
        }

        public List<PlanPosteUser> UserNotInForPlan(int idPlan, List<int> idUserList)
        {
            var planPosteUsers = Context.PlanPosteUser
                .Where(x => !idUserList.Contains(x.PlanUser.IdUser) && x.PlanUser.Plan.Id == idPlan)
                .Include(x=>x.PlanUser.User)
                .ToList();

            return planPosteUsers;
        }

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            var results = Context.PlanPosteUser
                .Where(x => x.IdPlanPoste == idPlanPoste)
                .ToList();

            foreach (var result in results)
            {
                Delete(result);
            }
        }
    }


}
