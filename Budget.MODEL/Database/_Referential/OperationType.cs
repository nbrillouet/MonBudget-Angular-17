using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION_TYPE", Schema = "ref")]
    public class OperationType
    {
        public int Id { get; set; }

        public int IdOperationTypeFamily { get; set; }
        public OperationTypeFamily OperationTypeFamily { get; set; }

        public string Label { get; set; }
        public int IdUserGroup { get; set; }
        public bool IsMandatory { get; set; }
        public string Code { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("LABEL")]
        //[StringLength(50)]
        //public string Label { get; set; }

        //[Column("ID_OPERATION_TYPE_FAMILY")]
        //public int IdOperationTypeFamily { get; set; }

        //[ForeignKey("IdOperationTypeFamily")]
        //public OperationTypeFamily OperationTypeFamily { get; set; }
        //[Column("ID_USER_GROUP")]
        //public int IdUserGroup { get; set; }
        //[Column("IS_MANDATORY")]
        //public bool IsMandatory { get; set; }
        //[Column("CODE")]
        //[StringLength(4)]
        //public string Code { get; set; }


    }


}
