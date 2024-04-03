using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AccountStatementPlanBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatementPlan>()
                .ToTable("ACCOUNT_STATEMENT_PLAN", "as");

            modelBuilder.Entity<AccountStatementPlan>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AccountStatementPlan>().Property(x => x.IdAccountStatement)
                .HasColumnName("ID_ACCOUNT_STATEMENT");
            modelBuilder.Entity<AccountStatementPlan>().Property(x => x.IdPlan)
                .HasColumnName("ID_PLAN");

            //PK
            modelBuilder.Entity<AccountStatementPlan>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<AccountStatementPlan>()
                .HasOne(x => x.AccountStatement)
                .WithMany()
                .HasForeignKey(x => x.IdAccountStatement)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountStatementPlan>()
                .HasOne(x => x.Plan)
                .WithMany()
                .HasForeignKey(x => x.IdPlan)
                .OnDelete(DeleteBehavior.NoAction);

            //INDEX
            modelBuilder.Entity<AccountStatementPlan>()
                .HasIndex(p => new { p.IdAccountStatement, p.IdPlan })
                .HasDatabaseName("IX_ASP_IdAccountStatement_IdPlan")
                .IsUnique();
        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_ACCOUNT_STATEMENT")]
//public int IdAccountStatement { get; set; }

//[ForeignKey("IdAccountStatement")]
//public AccountStatement AccountStatement { get; set; }

//[Column("ID_PLAN")]
//public int IdPlan { get; set; }

//[ForeignKey("IdPlan")]
//public Plan Plan { get; set; }