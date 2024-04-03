using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanFollowUpService
    {
        PlanForFollowUp Get(FilterPlanFollowUpSelected filter);
        List<AsForTable> GetPlanFollowUpAmountReal(PlanFollowUpAmountRealFilter filter);
    }
}
