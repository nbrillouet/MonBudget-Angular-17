using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationTransverseAsifBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTransverseAsif>()
                .ToTable("OPERATION_TRANSVERSE_ASIF", "as");

            modelBuilder.Entity<OperationTransverseAsif>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationTransverseAsif>().Property(x => x.IdOperationTransverse)
                .HasColumnName("ID_OPERATION_TRANSVERSE");
            modelBuilder.Entity<OperationTransverseAsif>().Property(x => x.IdAccountStatementImportFile)
                .HasColumnName("ID_ACCOUNT_STATEMENT_IMPORT_FILE");

            modelBuilder.Entity<OperationTransverseAsif>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<OperationTransverseAsif>()
                .HasOne(x => x.OperationTransverse)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTransverse)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationTransverseAsif>()
                .HasOne(x => x.AccountStatementImportFile)
                .WithMany()
                .HasForeignKey(x => x.IdAccountStatementImportFile)
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

//[Column("ID_ACCOUNT_STATEMENT_IMPORT_FILE")]
//public int IdAccountStatementImportFile { get; set; }
//[ForeignKey("IdAccountStatementImportFile")]
//public AccountStatementImportFile AccountStatementImportFile { get; set; }
