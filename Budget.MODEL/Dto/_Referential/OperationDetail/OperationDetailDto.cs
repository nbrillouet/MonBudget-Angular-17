using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class OperationDetailDto
    {
        public int Id { get; set; }
        public int IdUserGroup { get; set; }
        public Select Operation { get; set; }
        public string KeywordOperation { get; set; }
        public string KeywordPlace { get; set; }
        public string OperationLabel { get; set; }
        public string PlaceLabel { get; set; }
        public SelectCode OperationPlace { get; set; }
        public GMapAddressDto GMapAddress { get; set; }
    }
}
