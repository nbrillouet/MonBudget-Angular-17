using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanUserRepository : BaseRepository<PlanUser>, IPlanUserRepository
    {
        public PlanUserRepository(BudgetContext context) : base(context)
        {

        }

        public List<PlanUser> GetByIdPlan(int id)
        {
            var planUsers = Context.PlanUser
                .Where(x=>x.IdPlan==id)
                .Include(x=>x.User)
                .ToList();
            return planUsers;
        }

        public List<PlanUser> GetByIdUser(int idUser)
        {
            var planUsers = Context.PlanUser
                .Where(x => x.IdUser == idUser)
                .Include(x => x.Plan)
                .ToList();
            return planUsers;
        }

        public void DeleteByIdPlan(int idPlan)
        {
            var planUsers = Context.PlanUser
                .Where(x => x.IdPlan == idPlan)
                .ToList();

            foreach(var planUser in planUsers)
            {
                Delete(planUser);
            }
        }
    }
}
