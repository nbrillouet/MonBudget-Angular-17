using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanUserRepository : IBaseRepository<PlanUser>
    {
        List<PlanUser> GetByIdPlan(int id);
        List<PlanUser> GetByIdUser(int idUser);
        void DeleteByIdPlan(int idPlan);


    }

}
