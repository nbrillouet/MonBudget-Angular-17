using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("PLAN_POSTE", Schema = "plan")]
    public class PlanPoste
    {
        public int Id { get; set; }

        public int IdPlan { get; set; }
        public Plan Plan { get; set; }
        public int IdPoste { get; set; }
        public Poste Poste { get; set; }
        public int IdReferenceTable { get; set; }
        public ReferenceTable ReferenceTable { get; set; }

        public string Label { get; set; }
        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_PLAN")]
        //public int IdPlan { get; set; }

        //[ForeignKey("IdPlan")]
        //public Plan Plan { get; set; }

        //[Column("ID_POSTE")]
        //public int IdPoste { get; set; }

        //[ForeignKey("IdPoste")]
        //public Poste Poste { get; set; }

        //[Column("ID_REFERENCE_TABLE")]
        //public int IdReferenceTable { get; set; }

        //[ForeignKey("IdReferenceTable")]
        //public ReferenceTable ReferenceTable { get; set; }

        //[Column("LABEL")]
        //public string Label { get; set; }
    }
}
