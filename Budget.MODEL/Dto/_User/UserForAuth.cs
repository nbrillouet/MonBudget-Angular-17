using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class UserForAuth: UserForMinimal
    {
        public string Token { get; set; }
        
    }
}
