using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL
{
    //[Table("USER_SHORTCUT", Schema = "user")]
    public class UserShortcut
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }




        //[Key]
        //[Column("ID")]
        //public int Id { get; set; }
        //[Column("TITLE")]
        //public string Title { get; set; }
        //[Column("TYPE")]
        //public string Type { get; set; }
        //[Column("ICON")]
        //public string Icon { get; set; }
        //[Column("URL")]
        //public string Url { get; set; }

        //[ForeignKey("IdUser")]
        //public User User { get; set; }
        //[Column("ID_USER")]
        //public int IdUser { get; set; }
    }
}
