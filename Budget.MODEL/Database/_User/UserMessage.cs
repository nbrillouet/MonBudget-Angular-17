using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Database
{
    //[Table("USER_MESSAGE", Schema = "user")]
    public class UserMessage
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public string From { get; set; }
        public DateTime DateSent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_USER")]
        //public int IdUser { get; set; }

        //[ForeignKey("IdUser")]
        //public User User { get; set; }

        //[Column("MESSAGE_FROM")]
        //public string From { get; set; }

        //[Column("MESSAGE_DATE_SENT")]
        //public DateTime DateSent { get; set; }
        //[Column("MESSAGE_SUBJECT")]
        //public string Subject { get; set; }
        //[Column("MESSAGE_BODY")]
        //public string Body { get; set; }
        //[Column("IS_READ")]
        //public bool IsRead { get; set; }
    }
}
