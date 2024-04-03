using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budget.MODEL
{
    
    public class AsChartEvolution
    {
        public AsChartEvolutionCdb Brut { get; set; }
        public AsChartEvolutionCdb NoIntTransfer { get; set; }
        public AsChartEvolutionCustomOtf CustomOtfs { get; set; }
    }

    public class AsChartEvolutionCdb
    {
        public WidgetCardChartBar Debit { get; set; }
        public WidgetCardChartBar Credit { get; set; }
        public WidgetCardChartBar Balance { get; set; }
    }

    public class AsChartEvolutionCustomOtf
    {
        public AsChartEvolutionCustomOtfFilter Filter { get; set; }
        public List<WidgetCardChartBar> WidgetCardChartBars { get; set; }
    }

    public class AsChartEvolutionCustomOtfFilter
    {
        public AsChartEvolutionCustomOtfFilterSelected Selected { get; set; }
        public List<SelectGroupDto> OperationTypeFamilies { get; set; }
        
    }

    public class AsChartEvolutionCustomOtfFilterSelected
    {
        public UserForGroupDto User { get; set; }
        public int? IdAccount { get; set; }
        public MonthYear MonthYear { get; set; }
        public List<Select> OperationTypeFamilies { get; set; }
    }

    public class AsEvolutionCdbDto
    {
        [Key]
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public double Balance { get; set; }
    }

    
}
