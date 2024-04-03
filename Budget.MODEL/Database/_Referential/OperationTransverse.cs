using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("OPERATION_TRANSVERSE", Schema = "ref")]
    public class OperationTransverse
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public string Label { get; set; }


        //[Column("ID")]
        //public int Id { get; set; }

        //[Required]
        //[Column("LABEL")]
        //[StringLength(255)]
        //public string Label { get; set; }

        //[Column("ID_USER")]
        //public int IdUser { get; set; }
        //[ForeignKey("IdUser")]
        //public User User { get; set; }
    }
}
