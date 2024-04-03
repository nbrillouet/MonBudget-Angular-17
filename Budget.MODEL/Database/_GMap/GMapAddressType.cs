using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("GMAP_ADDRESS_TYPE", Schema = "gmap")]
    public class GMapAddressType
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_GMAP_ADDRESS")]
        public int IdGMapAddress { get; set; }

        [ForeignKey("IdGMapAddress")]
        public GMapAddress GMapAddress { get; set; }

        [Column("ID_GMAP_TYPE")]
        public int IdGMapType { get; set; }
        [ForeignKey("IdGMapType")]
        public GMapType GMapType { get; set; }
    }
}
