using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanAccountBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanAccount>()
                .ToTable("PLAN_ACCOUNT", "plan");

            modelBuilder.Entity<PlanAccount>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PlanAccount>().Property(x => x.IdPlan)
                .HasColumnName("ID_PLAN");
            modelBuilder.Entity<PlanAccount>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");

            modelBuilder.Entity<PlanAccount>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<PlanAccount>()
                .HasOne(x => x.Plan)
                .WithMany()
                .HasForeignKey(x => x.IdPlan)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanAccount>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.IdAccount)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }
//[Column("ID_PLAN")]
//public int IdPlan { get; set; }

//[ForeignKey("IdPlan")]
//public Plan Plan { get; set; }

//[Column("ID_ACCOUNT")]
//public int IdAccount { get; set; }

//[ForeignKey("IdAccount")]
//public Account Account { get; set; }