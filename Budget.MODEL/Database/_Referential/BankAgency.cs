using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("BANK_AGENCY", Schema = "ref")]
    public class BankAgency
    {
        public int Id { get; set; }

        public int IdBankSubFamily { get; set; }
        public BankSubFamily BankSubFamily { get; set; }
        public int IdGMapAddress { get; set; }
        public GMapAddress GMapAddress { get; set; }

        public string Label { get; set; }



        //public List<Account> Accounts { get; set; }
        //public BankAgency()
        //{
        //    Accounts = new List<Account>();
        //}

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("LABEL")]
        //[StringLength(100)]
        //public string Label { get; set; }

        //[Column("ID_BANK_SUB_FAMILY")]
        //public int IdBankSubFamily { get; set; }

        //[ForeignKey("IdBankSubFamily")]
        //public BankSubFamily BankSubFamily { get; set; }

        //[Column("ID_GMAP_ADDRESS")]
        //public int IdGMapAddress { get; set; }

        //[ForeignKey("IdGMapAddress")]
        //public GMapAddress GMapAddress { get; set; }

        //public List<Account> Accounts { get; set; }
        //public BankAgency()
        //{
        //    Accounts = new List<Account>();
        //}

    }
}
