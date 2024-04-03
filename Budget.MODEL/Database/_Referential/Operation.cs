using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION", Schema = "ref")]
    public class Operation
    {
        public int Id { get; set; }

        public int IdOperationMethod { get; set; }
        public OperationMethod OperationMethod { get; set; }
        public int IdOperationType { get; set; }
        public OperationType OperationType { get; set; }

        public string Label { get; set; }
        public string Reference { get; set; }
        public int IdUserGroup { get; set; }
        public bool IsMandatory { get; set; }


        //[Column("ID")]
        //public int Id { get; set; }

        //[Required]
        //[Column("LABEL")]
        //[StringLength(255)]
        //public string Label { get; set; }

        //[Column("REFERENCE")]
        //[StringLength(20)]
        //public string Reference { get; set; }

        //[Column("ID_OPERATION_METHOD")]
        //public int IdOperationMethod { get; set; }

        //[ForeignKey("IdOperationMethod")]
        //public OperationMethod OperationMethod { get; set; }

        //[Column("ID_OPERATION_TYPE")]
        //public int IdOperationType { get; set; }

        //[ForeignKey("IdOperationType")]
        //public OperationType OperationType { get; set; }
        //[Column("ID_USER_GROUP")]
        //public int IdUserGroup { get; set; }
        //[Column("IS_MANDATORY")]
        //public bool IsMandatory { get; set; }

        //List<OperationDetail> OperationDetails { get; set; }

    }

    //public enum EnumOperation
    //{
    //    Inconnu = 1,
    //    RemiseCheque = 2,
    //    RetraitDab = 3,

    //}
}
