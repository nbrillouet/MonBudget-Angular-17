using Budget.MODEL.Database;
using System;
using System.Collections.Generic;

namespace Budget.MODEL.Dto
{
    public class AsifGroupByAccounts
    {
        public List<Account> Accounts { get; set; }
        public int IdImport { get; set; }
        //public Account Account { get; set; }
        //public AsifGroup AsifGroup { get; set; }
        public AsifGroupByAccounts()
        {
            //AsifGroup = new AsifGroup();
            Accounts = new List<Account>();
        }
    }


}
