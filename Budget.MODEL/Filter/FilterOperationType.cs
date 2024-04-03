using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.MODEL.Filter
{
    public class FilterOtTableSelected
    {
        public UserForGroupDto User { get; set; }
        public string Label { get; set; }
        public Select OperationTypeFamily { get; set; }
        public Pagination Pagination { get; set; }

        public FilterOtTableSelected()
        {
            //Pagination = new Pagination();
        }

    }

    public class FilterOtTableSelection
    {
        public List<Select> OperationTypeFamily { get; set; }

        public FilterOtTableSelection()
        {

        }
    }

    public class FilterOtForDetail
    {
        public List<SelectGroupDto> OperationTypeFamily { get; set; }
    }

}
