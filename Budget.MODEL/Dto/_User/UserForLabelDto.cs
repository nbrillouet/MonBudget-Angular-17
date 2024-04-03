using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class UserForLabelDto
    {
        public int Id { get; set; }
        public int IdUserGroup { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MailAddress { get; set; }
    }
}
