using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.MODEL.Filter
{
    public class FilterOperationTableSelected
    {
        public UserForGroupDto User { get; set; }
        public string Label { get; set; }
        public Select OperationMethod { get; set; }
        public Select OperationType { get; set; }
        public Pagination Pagination { get; set; }

        public FilterOperationTableSelected()
        {

        }

    }

    public class FilterOperationTableSelection
    {
        public List<Select> OperationMethod { get; set; }
        public List<SelectGroupDto> OperationType { get; set; }
        
        public FilterOperationTableSelection()
        {

        }
    }

    public class FilterOperationForDetail
    {
        public List<Select> OperationMethod { get; set; }
        public List<SelectGroupDto> OperationType { get; set; }
    }
   
}
