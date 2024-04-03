using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("PLAN_USER", Schema = "plan")]
    public class PlanUser
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdPlan { get; set; }
        public Plan Plan { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_USER")]
        //public int IdUser { get; set; }

        //[ForeignKey("IdUser")]
        //public User User { get; set; }

        //[Column("ID_PLAN")]
        //public int IdPlan { get; set; }

        //[ForeignKey("IdPlan")]
        //public Plan Plan { get; set; }
    }
}
