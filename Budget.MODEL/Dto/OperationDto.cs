using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class OperationDto
    {
        public int Id { get; set; }
        public int IdOperationMethod { get; set; }
        public int IdOperationType { get; set; }
        public string Keyword { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
    }
}
