
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("BANK_SUB_FAMILY", Schema = "ref")]
    public class BankSubFamily
    {
        public int Id { get; set; }

        public int IdAsset { get; set; }
        public Asset Asset { get; set; }
        public int IdBankFamily { get; set; }
        public BankFamily BankFamily { get; set; }

        public string Code { get; set; }
        public string Label { get; set; }
        

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("CODE")]
        //[StringLength(10)]
        //public string Code { get; set; }

        //[Column("LABEL")]
        //[StringLength(50)]
        //public string Label { get; set; }

        //[Column("ID_ASSET")]
        //public int IdAsset { get; set; }
        //[ForeignKey("IdAsset")]
        //public Asset Asset { get; set; }

        //[Column("ID_BANK_FAMILY")]
        //public int IdBankFamily { get; set; }

        //[ForeignKey("IdBankFamily")]
        //public BankFamily BankFamily { get; set; }
        
    }


}
