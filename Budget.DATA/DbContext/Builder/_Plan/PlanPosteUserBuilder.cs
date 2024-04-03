using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanPosteUserBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanPosteUser>()
                .ToTable("PLAN_POSTE_USER", "plan");

            modelBuilder.Entity<PlanPosteUser>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<PlanPosteUser>().Property(x => x.IdPlanPoste)
                    .HasColumnName("ID_PLAN_POSTE");
            modelBuilder.Entity<PlanPosteUser>().Property(x => x.IdPlanUser)
                    .HasColumnName("ID_PLAN_USER");

            modelBuilder.Entity<PlanPosteUser>().Property(x => x.IsSalaryEstimatedPart)
                    .HasColumnName("IS_SALARY_ESTIMATED_PART");
            modelBuilder.Entity<PlanPosteUser>().Property(x => x.PercentagePart)
                    .HasColumnName("PERCENTAGE_PART");


            modelBuilder.Entity<PlanPosteUser>()
                   .HasKey(x => x.Id);

            modelBuilder.Entity<PlanPosteUser>()
                    .HasOne(x => x.PlanPoste)
                    .WithMany()
                    .HasForeignKey(x => x.IdPlanPoste)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanPosteUser>()
                    .HasOne(x => x.PlanUser)
                    .WithMany()
                    .HasForeignKey(x => x.IdPlanUser)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_PLAN_POSTE")]
//public int IdPlanPoste { get; set; }

//[ForeignKey("IdPlanPoste")]
//public PlanPoste PlanPoste { get; set; }

//[Column("ID_PLAN_USER")]
//public int IdPlanUser { get; set; }

//[ForeignKey("IdPlanUser")]
//public PlanUser PlanUser { get; set; }

//[Column("IS_SALARY_ESTIMATED_PART")]
//public int IsSalaryEstimatedPart { get; set; }
//[Column("PERCENTAGE_PART")]
//public double PercentagePart { get; set; }