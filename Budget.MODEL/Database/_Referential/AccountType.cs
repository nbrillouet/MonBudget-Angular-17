using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("ACCOUNT_TYPE", Schema = "ref")]
    public class AccountType
    {
        public int Id { get; set; }
        public string Label { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("LABEL")]
        //[StringLength(50)]
        //public string Label { get; set; }

    }
}
