using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("USER_ACCOUNT", Schema = "user")]
    public class UserAccount
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdAccount { get; set; }
        public Account Account { get; set; }

        public string ActivationCode { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_USER")]
        //public int IdUser { get; set; }

        //[ForeignKey("IdUser")]
        //public User User { get; set; }

        //[Column("ID_ACCOUNT")]
        //public int IdAccount { get; set; }

        //[ForeignKey("IdAccount")]
        //public Account Account { get; set; }

        //[Column("ACTIVATION_CODE")]
        //public string ActivationCode { get; set; }


    }
}
