using Budget.MODEL.Dto.GMap;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;

namespace Budget.MODEL.Dto
{
    public class AsForTable
    {
        public int Id { get; set; }
        public Select Operation { get; set; }
        public Select OperationMethod { get; set; }
        public Select OperationType { get; set; }
        public Select OperationTypeFamily { get; set; }
        public DateTime? DateIntegration { get; set; }
        public double AmountOperation { get; set; }
        public string LabelAs { get; set; }
        public List<SelectCode> Plans { get; set; }
        public Select Account { get; set; }
        public Select BankAgency { get; set; }
    }

    public class AsForDetail
    {
        public int Id { get; set; }
        public AsiForDetail Asi { get; set; }
        public AccountForDetail Account { get; set; }
        public OperationDetailDto OperationDetail { get; set; }
        public Select Operation { get; set; }
        public Select OperationMethod { get; set; }
        public Select OperationType { get; set; }
        public SelectCode OperationTypeFamily { get; set; }
        public List<Select> OperationTransverse { get; set; }
        public double? AmountOperation { get; set; }
        public string LabelAs { get; set; }
        public DateTime? DateIntegration { get; set; }
        public DateTime? DateImport { get; set; }
        public DateTime? DateOperation { get; set; }
        public bool IsDuplicated { get; set; }
        public int IdMovement { get; set; }
        public string Reference { get; set; }
        

    }
   

}
