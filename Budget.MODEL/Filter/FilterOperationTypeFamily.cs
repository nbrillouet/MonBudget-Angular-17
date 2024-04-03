using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterOtfTableSelected
    {
        public UserForGroupDto User { get; set; }
        public string Label { get; set; }
        public List<Select> Movement { get; set; }
        public Pagination Pagination { get; set; }

        public FilterOtfTableSelected()
        {
            Pagination = new Pagination();
        }

    }

    public class FilterOtfTableSelection
    {
        public List<Select> Movement { get; set; }

        //public FilterOtfTableSelected Selected { get; set; }

        public FilterOtfTableSelection()
        {
            //Selected = new FilterOtfTableSelected();
        }
    }

    public class FilterOtfForDetail
    {
        public List<Select> Movement { get; set; }
        public List<SelectCode> Asset { get; set; }
    }

}
