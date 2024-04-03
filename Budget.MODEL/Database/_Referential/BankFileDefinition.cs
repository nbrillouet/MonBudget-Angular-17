using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("BANK_FILE_DEFINITION", Schema = "ref")]
    public class BankFileDefinition
    {
        public int Id { get; set; }

        public int IdBankFamily { get; set; }

        public BankFamily BankFamily { get; set; }
        
        public string LabelField { get; set; }
        public int LabelOrder { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("ID_BANK_FAMILY")]
        //public int IdBankFamily { get; set; }

        //[ForeignKey("IdBankFamily")]
        //public BankFamily BankFamily { get; set; }
        //[Column("LABEL_FIELD")]
        //[StringLength(50)]
        //public string LabelField { get; set; }
        //[Column("LABEL_ORDER")]
        //public int LabelOrder { get; set; }
    }

    //public enum EnumFileBankType
    //{
    //    Inconnu,
    //    BanquePopulaire,
    //    CreditAgricole
    //}
}
