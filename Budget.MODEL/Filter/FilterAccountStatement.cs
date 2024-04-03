using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.MODEL.Filter
{
    public class FilterAsMainSelected : FilterAccountMonthYear
    {
        public UserForGroupDto User { get; set; }
        public bool IsWithITransfer { get; set; }
    }
    public class FilterAsTableSelected : FilterAsMainSelected
    {
        public List<Select> OperationMethod { get; set; }
        public List<Select> OperationTypeFamily { get; set; }
        public List<Select> OperationType { get; set; }
        public List<Select> Operation { get; set; }
        public FilterDateRange DateIntegration { get; set; }
        public FilterNumberRange AmountOperation { get; set; }
        
        public Pagination Pagination { get; set; }
    }

    public class FilterAsMainSelection
    {
        public List<Select> Month { get; set; }
        public List<int> Year { get; set; }
    }

    public class FilterAsTableSelection: FilterAsMainSelection
    {
        public List<Select> OperationMethod { get; set; }
        public List<SelectGroupDto> OperationTypeFamily { get; set; }
        public List<SelectGroupDto> OperationType { get; set; }
        public List<Select> Operation { get; set; }
        
        public FilterAsTableSelection()
        {
        }
    }

    public class FilterAsForDetail
    {
        public List<Select> OperationMethod { get; set; }
        public List<SelectCode> OperationTypeFamily { get; set; }
        public List<Select> OperationType { get; set; }
        public List<Select> Operation { get; set; }
        public List<Select> OperationTransverse { get; set; }
        public List<SelectCode> OperationPlace { get; set; }
    }

    //public class FilterAsDetail
    //{
    //    public int? IdAs { get; set; }
    //    //public UserForGroupDto User { get; set; }
    //}


    
}
