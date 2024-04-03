using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL
{

    public class FilterAsiTableSelection
    {
        public List<BankAgencyDto> BankAgencies { get; set; }
        //public FilterAsiTableSelected Selected { get; set; }

        public FilterAsiTableSelection()
        {
            //Selected = new FilterAsiTableSelected();
        }
    }

    public class FilterAsiTableSelected
    {
        public UserForGroupDto User { get; set; }
        public int? IdBankAgency { get; set; }
        public int? IndexTabBankAgency { get; set; }
        public Pagination Pagination { get; set; }

        public FilterAsiTableSelected()
        {

        }
    }
}
