using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Dto
{
    public class UserForLogged: UserForInfo
    {
        public List<UserShortcutDto> Shortcuts { get; set; }
        public List<BankAgencyWithAccountsDto> BankAgencies { get; set; }
        public List<UserEventDto> UserEvents { get; set; }
        public UserPreference UserPreference { get; set; }
    }
}
