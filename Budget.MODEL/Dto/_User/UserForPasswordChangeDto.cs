using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL
{
    public class UserForPasswordChange
    {
        public string IdCrypted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
