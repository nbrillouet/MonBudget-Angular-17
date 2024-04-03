using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationTransverseAsBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTransverseAs>()
                .ToTable("OPERATION_TRANSVERSE_AS", "as");

            modelBuilder.Entity<OperationTransverseAs>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationTransverseAs>().Property(x => x.IdOperationTransverse)
                .HasColumnName("ID_OPERATION_TRANSVERSE");
            modelBuilder.Entity<OperationTransverseAs>().Property(x => x.IdAccountStatement)
                .HasColumnName("ID_ACCOUNT_STATEMENT");

            modelBuilder.Entity<OperationTransverseAs>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<OperationTransverseAs>()
                .HasOne(x => x.OperationTransverse)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTransverse)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationTransverseAs>()
                .HasOne(x => x.AccountStatement)
                .WithMany()
                .HasForeignKey(x => x.IdAccountStatement)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_OPERATION_TRANSVERSE")]
//public int IdOperationTransverse { get; set; }
//[ForeignKey("IdOperationTransverse")]
//public OperationTransverse OperationTransverse { get; set; }

//[Column("ID_ACCOUNT_STATEMENT")]
//public int IdAccountStatement { get; set; }
//[ForeignKey("IdAccountStatement")]
//public AccountStatement AccountStatement { get; set; }