using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    public class OperationMethod
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string KeywordWork { get; set; }
    }
}
