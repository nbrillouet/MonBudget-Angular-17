using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class AccountForTable
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
        public BankAgencyForDetail BankAgency { get; set; }
        public double StartAmount { get; set; }
        public Select AccountType { get; set; }
        public double AlertThreshold { get; set; }
        public List<Select> LinkedUsers { get; set; }
        public double Solde { get; set; }
        public EnumActivationCode EnumActivationCode { get; set; }
    }

    public class AccountForLabelDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
    }

    public class AccountForDetail
    {
        public int Id { get; set; }
        public int IdUserOwner { get; set; }
        public UserForGroupDto User { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
        public SelectGMapAddress BankAgency { get; set; }
        public Select BankSubFamily { get; set; }
        public SelectCodeUrl BankFamily { get; set; }
        public Select AccountType { get; set; }
        public List<Select> LinkedUsers { get; set; }
        public double StartAmount { get; set; }
        public double AlertThreshold { get; set; }
        
    }

    public class AccountForList: AccountForDetail
    {
        public Solde Solde { get; set; }
    }

    public class AccountOwnerDto
    {
        public UserForLabelDto UserCaller { get; set; }
        public UserForLabelDto UserOwner { get; set; }
        public AccountForLabelDto Account { get; set; }
        public EnumActivationCode EnumActivationCode { get; set; }
    }

}
