using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class InternalTransferDto
    {
        public AsForTable AsFirst { get; set; }
        public AsForTable AsSecond { get; set; }
    }
}
