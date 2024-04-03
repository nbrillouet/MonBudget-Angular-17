using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION_TRANSVERSE_AS", Schema = "as")]
    public class OperationTransverseAs
    {
        public int Id { get; set; }

        public int IdOperationTransverse { get; set; }
        public OperationTransverse OperationTransverse { get; set; }

        public int IdAccountStatement { get; set; }
        public AccountStatement AccountStatement { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_OPERATION_TRANSVERSE")]
        //public int IdOperationTransverse { get; set; }
        //[ForeignKey("IdOperationTransverse")]
        //public OperationTransverse OperationTransverse { get; set; }

        //[Column("ID_ACCOUNT_STATEMENT")]
        //public int IdAccountStatement { get; set; }
        //[ForeignKey("IdAccountStatement")]
        //public AccountStatement AccountStatement { get; set; }

    }

}
