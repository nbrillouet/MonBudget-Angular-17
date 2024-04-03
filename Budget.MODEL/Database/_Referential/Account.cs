using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{

    public class Account
    {
        public int Id { get; set; }

        public int IdUserOwner { get; set; }
        public User UserOwner { get; set; }
        public int IdBankAgency { get; set; }
        public BankAgency BankAgency { get; set; }
        public int IdAccountType { get; set; }
        public AccountType AccountType { get; set; }

        public string Number { get; set; }
        public string Label { get; set; }
        public double StartAmount { get; set; }
        public double AlertThreshold { get; set; }
    }


}
