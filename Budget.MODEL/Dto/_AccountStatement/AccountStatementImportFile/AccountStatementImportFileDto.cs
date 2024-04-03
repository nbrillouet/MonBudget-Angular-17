using Budget.MODEL.Database;
using Budget.MODEL.Dto.GMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class AsifForTable
    {
        public int Id { get; set; }
        public Select Operation { get; set; }
        public Select OperationMethod { get; set; }
        public Select OperationType { get; set; }
        public Select OperationTypeFamily { get; set; }
        public DateTime? DateIntegration { get; set; }
        public double? AmountOperation { get; set; }
        public string LabelAs { get; set; }
        public bool IsDuplicated { get; set; }
    }


    public class AsifForDetail: AsForDetail
    {
        public string LabelAsCopy { get; set; }
        public string LabelAsWork { get; set; }
        public string OdOperationKeyword { get; set; }
        public string OdPlaceKeyword { get; set; }
        public string OdOperationLabel { get; set; }
        public string OdPlaceLabel { get; set; }

    }

}
