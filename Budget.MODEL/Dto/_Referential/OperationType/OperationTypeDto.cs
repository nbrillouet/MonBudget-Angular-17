using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class OtForTableDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Select OperationTypeFamily { get; set; }
        public UserForGroupDto User { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsUsed { get; set; }
    }

    public class OtForDetail
    {
        public int? Id { get; set; }
        public string Label { get; set; }
        public Select OperationTypeFamily { get; set; }
        public UserForGroupDto User { get; set; }
        public bool IsMandatory { get; set; }
    }
}
