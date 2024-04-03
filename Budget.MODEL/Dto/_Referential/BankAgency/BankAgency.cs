using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{

    public class BankAgencyDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public SelectCodeUrl BankSubFamily {get;set;}
        public SelectCodeUrl BankFamily { get; set; }
    }

    public class BankAgencyWithAccountsDto : BankAgencyDto
    {
        public List<AccountForDetail> Accounts { get; set; }
    }

    public class BankAgencyForListDto: BankAgencyDto
    {

    }

    public class BankAgencyForDetail: Select
    {
        public BankSubFamilyForDetail BankSubFamily { get; set; }
    }

    public class BankAgencyForList : Select
    {
        public List<AccountForList> AccountList { get; set; }
    }



}
