using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class BankFileDefinitionBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankFileDefinition>()
                .ToTable("BANK_FILE_DEFINITION", "ref");

            modelBuilder.Entity<BankFileDefinition>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<BankFileDefinition>().Property(x => x.IdBankFamily)
                .HasColumnName("ID_BANK_FAMILY");

            modelBuilder.Entity<BankFileDefinition>().Property(x => x.LabelField)
                .HasColumnName("LABEL_FIELD")
                .HasMaxLength(50);
            modelBuilder.Entity<BankFileDefinition>().Property(x => x.LabelOrder)
                .HasColumnName("LABEL_ORDER");

            modelBuilder.Entity<BankFileDefinition>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<BankFileDefinition>()
                .HasOne(x => x.BankFamily)
                .WithMany()
                .HasForeignKey(x => x.IdBankFamily)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
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