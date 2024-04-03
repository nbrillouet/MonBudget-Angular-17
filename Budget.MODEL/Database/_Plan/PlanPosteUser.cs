using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("PLAN_POSTE_USER", Schema = "plan")]
    public class PlanPosteUser
    {
        public int Id { get; set; }

        public int IdPlanPoste { get; set; }
        public PlanPoste PlanPoste { get; set; }
        public int IdPlanUser { get; set; }
        public PlanUser PlanUser { get; set; }

        public int IsSalaryEstimatedPart { get; set; }
        public double PercentagePart { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_PLAN_POSTE")]
        //public int IdPlanPoste { get; set; }

        //[ForeignKey("IdPlanPoste")]
        //public PlanPoste PlanPoste { get; set; }

        //[Column("ID_PLAN_USER")]
        //public int IdPlanUser { get; set; }

        //[ForeignKey("IdPlanUser")]
        //public PlanUser PlanUser { get; set; }

        //[Column("IS_SALARY_ESTIMATED_PART")]
        //public int IsSalaryEstimatedPart { get; set; }
        //[Column("PERCENTAGE_PART")]
        //public double PercentagePart { get; set; }
    }
}
