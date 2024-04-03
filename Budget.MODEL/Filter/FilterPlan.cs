using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterPlanTableSelected
    {
        public UserForGroupDto User { get; set; }
        public int Year { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class FilterPlanTableSelection
    {
        public List<int> Year { get; set; }

        public FilterPlanTableSelection()
        {
        }
    }

    public class FilterPlanFollowUpSelected
    {
        public UserForGroupDto User { get; set; }
        public Plan Plan { get; set; }
        public MonthYear MonthYear { get; set; }
        //public int? Year { get; set; }
        //public Select Month { get; set; }
    }

    public class FilterPlanFollowUpSelection
    {
        public List<Select> Month { get; set; }
        public List<int> Year { get; set; }
        public List<Plan> Plan { get; set; }

        public FilterPlanFollowUpSelection()
        {
        }
    }

    

}
