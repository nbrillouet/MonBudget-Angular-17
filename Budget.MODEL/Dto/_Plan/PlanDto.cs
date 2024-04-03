using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{

    public class PlanForTableComboFilter
    {
        public ComboSimple<Select> Years { get; set; }
    }

    public class PlanForDetailDto
    {
        public Plan Plan { get; set; }
        public ComboMultiple<SelectGroupDto> Accounts { get; set; }
        public ComboMultiple<Select> Users { get; set; }
        public int PlanNotAsCount { get; set; }
        //public List<PlanPosteDto> PlanPostes { get; set; }

        public PlanForDetailDto()
        {
            Users = new ComboMultiple<Select>();
            //PlanPostes = new List<PlanPosteDto>();
            //Postes = new PostesDto();
        }
    }
}
