using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class BankAgencyBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAgency>()
                .ToTable("BANK_AGENCY", "ref");

            modelBuilder.Entity<BankAgency>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<BankAgency>().Property(x => x.IdBankSubFamily)
                .HasColumnName("ID_BANK_SUB_FAMILY");
            modelBuilder.Entity<BankAgency>().Property(x => x.IdGMapAddress)
                .HasColumnName("ID_GMAP_ADDRESS");

            modelBuilder.Entity<BankAgency>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(100);

            modelBuilder.Entity<BankAgency>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<BankAgency>()
                .HasOne(x => x.BankSubFamily)
                .WithMany()
                .HasForeignKey(x => x.IdBankSubFamily)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BankAgency>()
                .HasOne(x => x.GMapAddress)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAddress)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
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