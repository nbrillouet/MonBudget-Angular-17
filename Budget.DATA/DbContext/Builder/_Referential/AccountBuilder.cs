using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AccountBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .ToTable("ACCOUNT", "ref");

            modelBuilder.Entity<Account>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Account>().Property(x => x.IdBankAgency)
                .HasColumnName("ID_BANK_AGENCY");
            modelBuilder.Entity<Account>().Property(x => x.IdAccountType)
                .HasColumnName("ID_ACCOUNT_TYPE");
            modelBuilder.Entity<Account>().Property(x => x.IdUserOwner)
                .HasColumnName("ID_USER_OWNER");
            

            modelBuilder.Entity<Account>().Property(x => x.Number)
                .HasColumnName("NUMBER")
                .HasMaxLength(50);
            modelBuilder.Entity<Account>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);
            modelBuilder.Entity<Account>().Property(x => x.StartAmount)
                .HasColumnName("START_AMOUNT");
            modelBuilder.Entity<Account>().Property(x => x.AlertThreshold)
                .HasColumnName("ALERT_THRESHOLD");

            //PK
            modelBuilder.Entity<Account>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<Account>()
                .HasOne(x => x.BankAgency)
                .WithMany()
                .HasForeignKey(x => x.IdBankAgency)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.AccountType)
                .WithMany()
                .HasForeignKey(x => x.IdAccountType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.UserOwner)
                .WithMany()
                .HasForeignKey(x => x.IdUserOwner)
                .OnDelete(DeleteBehavior.NoAction);

            //index
            modelBuilder.Entity<Account>()
                .HasIndex(x => x.Number)
                .HasDatabaseName("IX_AccountNumber")
                .IsUnique();

        }
    }
}
//public virtual List<UserAccount> UserAccounts { get; set; }

//[Column("ID")]
//public int Id { get; set; }

//[Column("NUMBER")]
//[StringLength(50)]
////[Index("IX_AccountNumber", 1, IsUnique = true)]
//public string Number { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }

//[Column("ID_BANK_AGENCY")]
//public int IdBankAgency { get; set; }

//[ForeignKey("IdBankAgency")]
//public BankAgency BankAgency { get; set; }

//[Column("START_AMOUNT")]
//public double StartAmount { get; set; }

//[Column("ID_ACCOUNT_TYPE")]
//public int IdAccountType { get; set; }

//[ForeignKey("IdAccountType")]
//public AccountType AccountType { get; set; }

//[Column("ALERT_THRESHOLD")]
//public double AlertThreshold { get; set; }

//[Column("ID_USER_OWNER")]
//public int IdUserOwner { get; set; }

//[ForeignKey("IdUserOwner")]
//public User UserOwner { get; set; }

//public virtual List<UserAccount> UserAccounts { get; set; }

//public Account()
//{
//    UserAccounts = new List<UserAccount>();
//}