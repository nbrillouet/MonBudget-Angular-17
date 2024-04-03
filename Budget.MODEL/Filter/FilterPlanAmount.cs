using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class PlanFollowUpAmountRealFilter
    {
        public MonthYear MonthYear { get; set; }
        public int? IdPlanPoste { get; set; }
        public int? IdPlan { get; set; }
        public int? IdPoste { get; set; }
    }
}
