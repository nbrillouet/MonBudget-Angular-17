using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterUserTableSelected
    {
        public string Keyword { get; set; }
        public Pagination Pagination { get; set; }

        public FilterUserTableSelected()
        {

        }

    }

    public class FilterUserTableSelection
    {
        //public FilterUserTableSelected Selected { get; set; }

        public FilterUserTableSelection()
        {
            //Selected = new FilterUserTableSelected();
        }
    }

}
