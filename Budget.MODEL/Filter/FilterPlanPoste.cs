using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterPlanPosteTableSelected
    {
        //public UserForGroupDto User { get; set; }
        public int IdPlan { get; set; }
        public int IdPoste { get; set; }
        public string Label { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class FilterPlanPosteTableSelection
    {
        //public List<int> Year { get; set; }

        public FilterPlanPosteTableSelection()
        {
        }
    }

    public class FilterPlanPosteForDetail
    {
        //public SelectCode Poste { get; set; }
        //public List<PlanPosteUserForDetailDto> PlanPosteUser { get; set; }
        //public List<PlanPosteFrequencyForDetailDto> PlanPosteFrequencies { get; set; }

        public List<Select> ReferenceTable { get; set; }
        public List<SelectGroupDto> PlanPosteReference { get; set; }

    }
}
