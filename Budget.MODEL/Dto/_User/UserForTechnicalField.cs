using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Dto
{
    public class UserForTechnicalField
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastActive { get; set; }
        public int IdUserGroup { get; set; }
        public string ActivationCode { get; set; }
        public DateTime? ActivationDateSend { get; set; }
        public bool ActivationIsConfirmed { get; set; }
        public string Role { get; set; }
    }
}
