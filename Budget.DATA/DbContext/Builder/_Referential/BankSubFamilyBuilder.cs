using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class BankSubFamilyBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankSubFamily>()
                .ToTable("BANK_SUB_FAMILY", "ref");

            modelBuilder.Entity<BankSubFamily>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<BankSubFamily>().Property(x => x.IdAsset)
                .HasColumnName("ID_ASSET");
            modelBuilder.Entity<BankSubFamily>().Property(x => x.IdBankFamily)
                .HasColumnName("ID_BANK_FAMILY");


            modelBuilder.Entity<BankSubFamily>().Property(x => x.Code)
                .HasColumnName("CODE")
                .HasMaxLength(10);
            modelBuilder.Entity<BankSubFamily>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);

            modelBuilder.Entity<BankSubFamily>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<BankSubFamily>()
                .HasOne(x => x.Asset)
                .WithMany()
                .HasForeignKey(x => x.IdAsset)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BankSubFamily>()
                .HasOne(x => x.BankFamily)
                .WithMany()
                .HasForeignKey(x => x.IdBankFamily)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }

    //[Column("ID")]
    //public int Id { get; set; }

    //[Column("CODE")]
    //[StringLength(10)]
    //public string Code { get; set; }

    //[Column("LABEL")]
    //[StringLength(50)]
    //public string Label { get; set; }

    //[Column("ID_ASSET")]
    //public int IdAsset { get; set; }
    //[ForeignKey("IdAsset")]
    //public Asset Asset { get; set; }

    //[Column("ID_BANK_FAMILY")]
    //public int IdBankFamily { get; set; }

    //[ForeignKey("IdBankFamily")]
    //public BankFamily BankFamily { get; set; }
}
