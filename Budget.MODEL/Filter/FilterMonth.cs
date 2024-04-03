using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class MonthYear
    {
        public Select Month { get; set; }
        public int? Year { get; set; }
    }
}
