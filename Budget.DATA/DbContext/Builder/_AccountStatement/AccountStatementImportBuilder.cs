using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AccountStatementImportBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatementImport>()
                .ToTable("ACCOUNT_STATEMENT_IMPORT", "as");

            modelBuilder.Entity<AccountStatementImport>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AccountStatementImport>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");
            modelBuilder.Entity<AccountStatementImport>().Property(x => x.IdBankAgency)
                .HasColumnName("ID_BANK_AGENCY");

            modelBuilder.Entity<AccountStatementImport>().Property(x => x.FileImport)
                .HasColumnName("FILE_IMPORT");
            modelBuilder.Entity<AccountStatementImport>().Property(x => x.DateImport)
                .HasColumnName("DATE_IMPORT");
            modelBuilder.Entity<AccountStatementImport>().Ignore(c => c.File);

            modelBuilder.Entity<AccountStatementImport>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<AccountStatementImport>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImport>()
                .HasOne(x => x.BankAgency)
                .WithMany()
                .HasForeignKey(x => x.IdBankAgency)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
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