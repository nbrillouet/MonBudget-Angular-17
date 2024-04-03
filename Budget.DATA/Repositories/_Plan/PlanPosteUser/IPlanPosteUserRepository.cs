using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanPosteUserRepository : IBaseRepository<PlanPosteUser>
    {
        List<PlanPosteUser> GetByIdPlanPoste(int idPlanPoste);
        List<PlanPosteUser> UserNotInForPlan(int idPlan, List<int> idUserList);
        void DeleteByIdPlanPoste(int idPlanPoste);

    }

}
