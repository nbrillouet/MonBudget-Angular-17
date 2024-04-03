using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class UserForDetail: UserForLogged
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateLastActive { get; set; }
        public int IdGMapAddress { get; set; }
        public GMapAddressDto GMapAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? ActivationDateSend { get; set; }
        public string Token { get; set; }
    }

    
}
