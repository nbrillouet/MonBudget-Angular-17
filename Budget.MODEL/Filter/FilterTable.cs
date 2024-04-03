using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterTableSelected
    {
        public EnumFilterTableSelectedType EnumFilterTableSelectedType { get; set; }
        public Pagination Pagination { get; set; }

        public FilterTableSelected()
        {
            //Pagination = new Pagination();
        }
    }

    public enum EnumFilterTableSelectedType
    {
        accountStatement = 0,
        ASIF = 1
    }

}
