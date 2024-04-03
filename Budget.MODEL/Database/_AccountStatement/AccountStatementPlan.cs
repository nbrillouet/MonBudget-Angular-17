using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("ACCOUNT_STATEMENT_PLAN", Schema = "as")]
    public class AccountStatementPlan
    {
        public int Id { get; set; }

        public int IdAccountStatement { get; set; }
        public AccountStatement AccountStatement { get; set; }

        public int IdPlan { get; set; }
        public Plan Plan { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_ACCOUNT_STATEMENT")]
        //public int IdAccountStatement { get; set; }

        //[ForeignKey("IdAccountStatement")]
        //public AccountStatement AccountStatement { get; set; }

        //[Column("ID_PLAN")]
        //public int IdPlan { get; set; }

        //[ForeignKey("IdPlan")]
        //public Plan Plan { get; set; }
    }
}
