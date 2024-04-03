using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterFixedPlanNotAsTableSelected
    {
        public int IdPlan { get; set; }
        public int IdUserGroup { get; set; }
        public int Year { get; set; }
        public int IdInternalTransfert { get; set; }
        public List<int> AsInPlan { get; set; }
        public List<int> Accounts { get; set; }
    }

    public class FilterPlanNotAsTableSelected: FilterAsTableSelected
    {

    }

    public class FilterPlanNotAsTableGroupSelected
    {
        public FilterPlanNotAsTableSelected FilterPlanNotAsTableSelected { get; set; }
        public FilterFixedPlanNotAsTableSelected FilterFixedPlanNotAsTableSelected { get; set; }
    }

    public class FilterPlanNotAsTableSelection : FilterAsTableSelection
    {
        public FilterPlanNotAsTableSelection() { }
    }

}
