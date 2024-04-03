using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Filter
{
    public class FilterAccountTableSelected
    {
        public UserForGroupDto User { get; set; }
        public List<Select> BankFamily { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
        public Pagination Pagination { get; set; }

        public FilterAccountTableSelected()
        {
            //Pagination = new Pagination();
        }
    }

    public class FilterAccountTableSelection
    {
        public List<SelectCodeUrl> BankFamily { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }

        public FilterAccountTableSelection()
        {
        }
    }

    public class FilterAccountForDetail
    {
        public List<SelectGMapAddress> BankAgency { get; set; }
        public List<Select> BankSubFamily { get; set; }
        public List<SelectCodeUrl> BankFamily { get; set; }
        public List<Select> AccountType { get; set; }
    }

}
