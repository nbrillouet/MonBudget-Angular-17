using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationMethodLexicalBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationMethodLexical>()
                .ToTable("OPERATION_METHOD_LEXICAL", "ref");

            modelBuilder.Entity<OperationMethodLexical>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationMethodLexical>().Property(x => x.IdBankFamily)
                .HasColumnName("ID_BANK_FAMILY");
            modelBuilder.Entity<OperationMethodLexical>().Property(x => x.IdOperationMethod)
                .HasColumnName("ID_OPERATION_METHOD");

            modelBuilder.Entity<OperationMethodLexical>().Property(x => x.Keyword)
                .HasColumnName("KEYWORD")
                .HasMaxLength(50);
            modelBuilder.Entity<OperationMethodLexical>().Property(x => x.OrderId)
                .HasColumnName("ORDER_ID");

            modelBuilder.Entity<OperationMethodLexical>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<OperationMethodLexical>()
                .HasOne(x => x.BankFamily)
                .WithMany()
                .HasForeignKey(x => x.IdBankFamily)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationMethodLexical>()
                .HasOne(x => x.OperationMethod)
                .WithMany()
                .HasForeignKey(x => x.IdOperationMethod)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_BANK_FAMILY")]
//public int IdBankFamily { get; set; }

////[ForeignKey("IdBank")]
////public Bank Bank { get; set; }

//[Column("ID_OPERATION_METHOD")]
//public int IdOperationMethod { get; set; }

//[ForeignKey("IdOperationMethod")]
//public OperationMethod OperationMethod { get; set; }

//[StringLength(50)]
//[Column("KEYWORD")]
//public string Keyword { get; set; }

//[Column("ORDER_ID")]
//public int OrderId { get; set; }