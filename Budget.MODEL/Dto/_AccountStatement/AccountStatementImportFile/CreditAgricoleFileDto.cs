﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Dto
{
    public class CreditAgricoleFileDto
    {
        public string LabelAs { get; set; }
        public string AmountDebitOperation { get; set; }
        public string AmountCreditOperation { get; set; }
        public string DateIntegration { get; set; }
        public string AccountNumber { get; set; }
    }
}
