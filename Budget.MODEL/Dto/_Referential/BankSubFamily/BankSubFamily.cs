using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL
{
    public class BankSubFamilyForDetail: Select
    {
        public SelectCode BankFamily { get; set; }
    }

    public class BankSubFamilyForList: Select
    {
        public List<BankAgencyForList> BankAgency { get; set; }
    }
}
