using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanUserBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanUser>()
                .ToTable("PLAN_USER", "plan");

            modelBuilder.Entity<PlanUser>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<PlanUser>().Property(x => x.IdUser)
                    .HasColumnName("ID_USER");
            modelBuilder.Entity<PlanUser>().Property(x => x.IdPlan)
                    .HasColumnName("ID_PLAN");

            //PK
            modelBuilder.Entity<PlanUser>()
                   .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<PlanUser>()
                    .HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.IdUser)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanUser>()
                    .HasOne(x => x.Plan)
                    .WithMany()
                    .HasForeignKey(x => x.IdPlan)
                    .OnDelete(DeleteBehavior.NoAction);

            //INDEX
            modelBuilder.Entity<PlanUser>()
                .HasIndex(p => new { p.IdPlan, p.IdUser })
                .HasDatabaseName("IX_PlanUser")
                .IsUnique();
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_USER")]
//public int IdUser { get; set; }

//[ForeignKey("IdUser")]
//public User User { get; set; }

//[Column("ID_PLAN")]
//public int IdPlan { get; set; }

//[ForeignKey("IdPlan")]
//public Plan Plan { get; set; }