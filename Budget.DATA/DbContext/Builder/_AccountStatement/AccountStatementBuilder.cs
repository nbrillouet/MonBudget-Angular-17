using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AccountStatementBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatement>()
                .ToTable("ACCOUNT_STATEMENT", "as");

            modelBuilder.Entity<AccountStatement>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AccountStatement>().Property(x => x.IdImport)
                .HasColumnName("ID_IMPORT");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdOperationMethod)
                .HasColumnName("ID_OPERATION_METHOD");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdOperation)
                .HasColumnName("ID_OPERATION");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdOperationDetail)
                .HasColumnName("ID_OPERATION_DETAIL");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdOperationType)
                .HasColumnName("ID_OPERATION_TYPE");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdOperationTypeFamily)
                .HasColumnName("ID_OPERATION_TYPE_FAMILY");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdMovement)
                .HasColumnName("ID_MOVEMENT");

            modelBuilder.Entity<AccountStatement>().Property(x => x.DateOperation)
                .HasColumnName("DATE_OPERATION");
            modelBuilder.Entity<AccountStatement>().Property(x => x.LabelAs)
                .HasColumnName("LABEL_AS")
                .HasMaxLength(500);
            modelBuilder.Entity<AccountStatement>().Property(x => x.Reference)
                .HasColumnName("REFERENCE")
                .HasMaxLength(50);
            modelBuilder.Entity<AccountStatement>().Property(x => x.DateIntegration)
                .HasColumnName("DATE_INTEGRATION");
            modelBuilder.Entity<AccountStatement>().Property(x => x.AmountOperation)
                .HasColumnName("AMOUNT_OPERATION");
            modelBuilder.Entity<AccountStatement>().Property(x => x.DateImport)
                .HasColumnName("DATE_IMPORT");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdAccountStatementIt)
                .HasColumnName("ID_ACCOUNT_STATEMENT_IT");
            modelBuilder.Entity<AccountStatement>().Property(x => x.IdAccountIt)
                .HasColumnName("ID_ACCOUNT_IT");

            modelBuilder.Entity<AccountStatement>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.AccountStatementImport)
                .WithMany()
                .HasForeignKey(x => x.IdImport)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.IdAccount)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.OperationMethod)
                .WithMany()
                .HasForeignKey(x => x.IdOperationMethod)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.Operation)
                .WithMany()
                .HasForeignKey(x => x.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.OperationDetail)
                .WithMany()
                .HasForeignKey(x => x.IdOperationDetail)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.OperationType)
                .WithMany()
                .HasForeignKey(x => x.IdOperationType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.OperationTypeFamily)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTypeFamily)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatement>()
                .HasOne(x => x.Movement)
                .WithMany()
                .HasForeignKey(x => x.IdMovement)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
