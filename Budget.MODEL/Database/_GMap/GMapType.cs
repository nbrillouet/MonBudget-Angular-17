using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("GMAP_TYPE", Schema = "gmap")]
    public class GMapType
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("KEYWORD")]
        public string Keyword { get; set; }

        //[Column("LABEL_FR")]
        //public string LabelFr { get; set; }
    }
}
