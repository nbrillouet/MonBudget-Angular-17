using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class OtfForTableDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Select Movement { get; set; }
        public SelectCode Asset { get; set; }
        public UserForGroupDto User { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsUsed { get; set; }
    }

    public class OtfForDetail
    {
        public int? Id { get; set; }
        public string Label { get; set; }
        public Select Movement { get; set; }
        public SelectCode Asset { get; set; }
        public UserForGroupDto User { get; set; }
        public bool IsMandatory { get; set; }
    }

}
