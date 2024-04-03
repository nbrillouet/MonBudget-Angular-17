using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION_TYPE_FAMILY", Schema = "ref")]
    public class OperationTypeFamily
    {

        public int Id { get; set; }

        public int IdMovement { get; set; }
        public Movement Movement { get; set; }
        public int IdAsset { get; set; }
        public Asset Asset { get; set; }

        public string Label { get; set; }
        public int IdUserGroup { get; set; }
        public bool IsMandatory { get; set; }
        public string Code { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("LABEL")]
        //[StringLength(50)]
        //public string Label { get; set; }

        //[Column("ID_MOVEMENT")]
        //public int IdMovement { get; set; }
        //[ForeignKey("IdMovement")]
        //public Movement Movement { get; set; }

        ////[Column("LOGO_CLASS_NAME")]
        ////[StringLength(30)]
        ////public string LogoClassName { get; set; }

        //[Column("ID_USER_GROUP")]
        //public int IdUserGroup { get; set; }

        //[Column("IS_MANDATORY")]
        //public bool IsMandatory { get; set; }
        //[Column("CODE")]
        //[StringLength(4)]
        //public string Code { get; set; }

        //[Column("ID_ASSET")]
        //public int IdAsset { get; set; }
        //[ForeignKey("IdAsset")]
        //public Asset Asset { get; set; }

    }


    //public enum EnumOperationTypeFamily
    //{
    //    Inconnu = 1
    //}


}
