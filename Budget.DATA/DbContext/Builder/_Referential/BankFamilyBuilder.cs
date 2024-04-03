using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class BankFamilyBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankFamily>()
                .ToTable("BANK_FAMILY", "ref");

            modelBuilder.Entity<BankFamily>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<BankFamily>().Property(x => x.IdAsset)
                .HasColumnName("ID_ASSET");

            modelBuilder.Entity<BankFamily>().Property(x => x.Code)
                .HasColumnName("CODE")
                .HasMaxLength(4);
            modelBuilder.Entity<BankFamily>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);

            modelBuilder.Entity<BankFamily>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<BankFamily>()
                .HasOne(x => x.Asset)
                .WithMany()
                .HasForeignKey(x => x.IdAsset)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("CODE")]
//[StringLength(4)]
//public string Code { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }
//[Column("ID_ASSET")]
//public int IdAsset { get; set; }
//[ForeignKey("IdAsset")]
//public Asset Asset { get; set; }