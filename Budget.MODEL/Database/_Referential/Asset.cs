using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("ASSET", Schema = "ref")]
    public class Asset
    {
        public int Id { get; set; }

        public string Path { get; set; }
        public string Label { get; set; }
        public string Extension { get; set; }
        public int IdFamily { get; set; }
    }

}
