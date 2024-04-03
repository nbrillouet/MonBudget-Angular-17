using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System.Collections.Generic;


namespace Budget.MODEL.Dto
{
    public class PlanPosteDto
    {
        public Select Poste { get; set; }
        public List<PlanPosteForTableDto> List { get; set; }

        public PlanPosteDto()
        {
            List = new List<PlanPosteForTableDto>();
        }
    }
       

    public class PlanPosteForTableDto
    {
        public int Id { get; set; }
        public int IdPlan { get; set; }
        public int IdPoste { get; set; }
        public string Label { get; set; }
    }

    public class PlanPosteForDetail
    {
        public int Id { get; set; }
        public int IdPlan { get; set; }
        public int IdPoste { get; set; }
        public string Label { get; set; }
        public SelectCode Poste { get; set; }
        public Select ReferenceTable { get; set; }
        public List<PlanPosteUserForDetailDto> PlanPosteUser {get;set;}
        public List<Select> PlanPosteReference { get; set; }
        public PlanPosteFrequencies PlanPosteFrequencies { get; set; }
        //public List<PlanPosteFrequencyForDetailDto> PlanPosteFrequencies { get; set; }

        public PlanPosteForDetail()
        {
        }
    }
    
    public class PlanPosteFrequencies
    {
        public bool IsYearly { get; set; }
        public List<PlanPosteFrequencyForDetailDto> Yearly { get; set; }
        public List<PlanPosteFrequencyForDetailDto> Monthly { get; set; }
    }

    public class PlanPosteUserForDetailDto
    {
        public int Id { get; set; }
        public int IdPlanUser { get; set; }
        public UserForLabelDto User { get; set; }
        public bool IsSalaryEstimatedPart { get; set; }
        public int PercentagePart { get; set; }
    }

    public class PlanPosteFrequencyForDetailDto
    {
        public int Id { get; set; }
        public Month Frequency { get; set; }
        public double PreviewAmount { get; set; }
    }

    
}
