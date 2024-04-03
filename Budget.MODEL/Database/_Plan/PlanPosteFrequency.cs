using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("PLAN_POSTE_FREQUENCY", Schema = "plan")]
    public class PlanPosteFrequency
    {
        public int Id { get; set; }

        public int IdPlanPoste { get; set; }
        public PlanPoste PlanPoste { get; set; }
        public int IdFrequency { get; set; }
        public Month Frequency { get; set; }

        public double PreviewAmount { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_PLAN_POSTE")]
        //public int IdPlanPoste { get; set; }

        //[ForeignKey("IdPlanPoste")]
        //public PlanPoste PlanPoste { get; set; }

        //[Column("ID_FREQUENCY")]
        //public int IdFrequency { get; set; }

        //[ForeignKey("IdFrequency")]
        //public Month Frequency { get; set; }

        //[Column("PREVIEW_AMOUNT")]
        //public double PreviewAmount { get; set; }
    }
}
