using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Database
{
    public class UserPreference
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Scheme { get; set; }
        public string Layout { get; set; }
        public string Language { get; set; }
        public string AvatarUrl { get; set; }
        public string BannerUrl { get; set; }
        public string Status { get; set; }

    }
}
