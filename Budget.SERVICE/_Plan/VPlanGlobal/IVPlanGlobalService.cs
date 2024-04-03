using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IVPlanGlobalService
    {
        List<VPlanGlobal> Get(FilterPlanFollowUpSelected filter);
        List<VPlanGlobal> GetByIdPlan(int IdPlan);
        List<VPlanGlobal> GetByIdAccountStatement(int idAs);
    }


}
