using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL
{
    public class UserEventDto
    {
        public EnumUserEventSection Section { get; set; }
        public EnumUserEventCategory Category { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public EnumUserEventWarning Warning { get; set; }
        public string Link { get; set; }

    }

}
