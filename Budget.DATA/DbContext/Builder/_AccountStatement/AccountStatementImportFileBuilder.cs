using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AccountStatementImportFileBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatementImportFile>()
                .ToTable("ACCOUNT_STATEMENT_IMPORT_FILE", "as");

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdImport)
                .HasColumnName("ID_IMPORT");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdOperationMethod)
                .HasColumnName("ID_OPERATION_METHOD");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdOperation)
                .HasColumnName("ID_OPERATION");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdOperationDetail)
                .HasColumnName("ID_OPERATION_DETAIL");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdOperationType)
                .HasColumnName("ID_OPERATION_TYPE");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdOperationTypeFamily)
                .HasColumnName("ID_OPERATION_TYPE_FAMILY");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdMovement)
                .HasColumnName("ID_MOVEMENT");

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IdState)
                .HasColumnName("ID_STATE");
                        

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.DateOperation)
                .HasColumnName("DATE_OPERATION");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.LabelAs)
                 .HasColumnName("LABEL_AS")
                 .HasMaxLength(500);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.Reference)
                .HasColumnName("REFERENCE")
                .HasMaxLength(50);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.DateIntegration)
                .HasColumnName("DATE_INTEGRATION");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.AmountOperation)
                .HasColumnName("AMOUNT_OPERATION");
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.DateImport)
                .HasColumnName("DATE_IMPORT");

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.OdOperationKeyword)
                .HasColumnName("OD_OPERATION_KEYWORD")
                .HasMaxLength(100);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.OdPlaceKeyword)
                .HasColumnName("OD_PLACE_KEYWORD")
                .HasMaxLength(100);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.OdOperationLabel)
                .HasColumnName("OD_OPERATION_LABEL")
                .HasMaxLength(100);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.OdPlaceLabel)
                .HasColumnName("OD_PLACE_LABEL")
                .HasMaxLength(100);

            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.LabelAsWork)
                .HasColumnName("LABEL_OPERATION_WORK")
                .HasMaxLength(500);
            modelBuilder.Entity<AccountStatementImportFile>().Property(x => x.IsDuplicated)
                .HasColumnName("IS_DUPLICATED");

            modelBuilder.Entity<AccountStatementImportFile>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.AccountStatementImport)
                .WithMany()
                .HasForeignKey(x => x.IdImport)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.IdAccount)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.OperationMethod)
                .WithMany()
                .HasForeignKey(x => x.IdOperationMethod)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.Operation)
                .WithMany()
                .HasForeignKey(x => x.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.OperationDetail)
                .WithMany()
                .HasForeignKey(x => x.IdOperationDetail)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.OperationType)
                .WithMany()
                .HasForeignKey(x => x.IdOperationType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.OperationTypeFamily)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTypeFamily)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.Movement)
                .WithMany()
                .HasForeignKey(x => x.IdMovement)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementImportFile>()
                .HasOne(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.IdState)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
