using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION_METHOD_LEXICAL", Schema = "ref")]
    public class OperationMethodLexical
    {
        public int Id { get; set; }

        public int IdBankFamily { get; set; }
        public BankFamily BankFamily { get; set; }
        public int IdOperationMethod { get; set; }
        public OperationMethod OperationMethod { get; set; }

        public string Keyword { get; set; }
        public int OrderId { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_BANK_FAMILY")]
        //public int IdBankFamily { get; set; }

        ////[ForeignKey("IdBank")]
        ////public Bank Bank { get; set; }

        //[Column("ID_OPERATION_METHOD")]
        //public int IdOperationMethod { get; set; }

        //[ForeignKey("IdOperationMethod")]
        //public OperationMethod OperationMethod { get; set; }

        //[StringLength(50)]
        //[Column("KEYWORD")]
        //public string Keyword { get; set; }

        //[Column("ORDER_ID")]
        //public int OrderId { get; set; }
    }
}
