using Budget.MODEL.Database;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IVPlanGlobalRepository
    {
        List<VPlanGlobal> Get(FilterPlanFollowUpSelected filter);
        List<VPlanGlobal> GetByIdPlan(int IdPlan);
        List<VPlanGlobal> GetByIdAccountStatement(int idAs);
    }
}
