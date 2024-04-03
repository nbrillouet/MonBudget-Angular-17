using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace Budget.MODEL.Database
{
    //[Table("ACCOUNT_STATEMENT_IMPORT", Schema = "as")]
    public class AccountStatementImport
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdBankAgency { get; set; }
        public BankAgency BankAgency { get; set; }

        public string FileImport { get; set; }
        public DateTime DateImport { get; set; }
        public StreamReader File { get; set; }

        //[Column("ID")]
        //public int Id { get; set; }
        //[Column("ID_USER")]
        //public int IdUser { get; set; }
        //[ForeignKey("IdUser")]
        //public User User { get; set; }

        //[Column("ID_BANK_AGENCY")]
        //public int IdBankAgency { get; set; }

        //[ForeignKey("IdBankAgency")]
        //public BankAgency BankAgency { get; set; }

        //[Column("FILE_IMPORT")]
        //public string FileImport { get; set; }

        //[Column("DATE_IMPORT")]
        //public DateTime DateImport { get; set; }

        //[NotMapped]
        //public StreamReader File { get; set; }

        //public virtual List<AccountStatementImportFile> AccountStatementImportFiles { get; set; }

        //public AccountStatementImport()
        //{
        //    AccountStatementImportFiles = new List<AccountStatementImportFile>();
        //}
    }
}
