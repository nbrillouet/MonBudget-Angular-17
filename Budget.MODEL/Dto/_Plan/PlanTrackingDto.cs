using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class PlanForFollowUp : PlanForFollowUpValue
    {
        public Plan Plan { get; set; }
        //public double AmountReal { get; set; }
        //public double AmountPreview { get; set; }

        public List<PosteForFollowUp> Postes { get; set; }
    }

    public class PlanFollowUpAmountStore : PlanForFollowUpValue
    {
        public int Id { get; set; }
        public string Label { get; set; }
        //public double Amount { get; set; }
        //public double AmountPreview { get; set; }
    }

    public class PlanPosteForFollowUp : PlanForFollowUpPlanPosteValue
    {
        public int IdPlanPoste { get; set; }
        public string Label { get; set; }
        public List<PlanPosteUserForFollowUp> PlanPosteUsers { get; set; }
    }

    public class PlanPosteUserForFollowUp : PlanForFollowUpValue
    {
        public string FirstName { get; set; }
        public double PercentagePart { get; set; }
    }

    public class PosteForFollowUp : PlanForFollowUpValue
    {
        public Select Poste { get; set; }
        public List<PlanPosteForFollowUp> PlanPostes { get; set; }
    }

    public class PlanForFollowUpPlanPosteValue : PlanForFollowUpValue
    {
        public bool IsAnnualPreview { get; set; }
    }

    public class PlanForFollowUpValue
    {
        public double AmountReal { get; set; }
        public double AmountPreview { get; set; }
        public double GaugeValue { get; set; }
    }

    

}
