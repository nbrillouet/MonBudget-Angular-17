using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanPosteFrequencyBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanPosteFrequency>()
                .ToTable("PLAN_POSTE_FREQUENCY", "plan");

            modelBuilder.Entity<PlanPosteFrequency>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<PlanPosteFrequency>().Property(x => x.IdPlanPoste)
                    .HasColumnName("ID_PLAN_POSTE");
            modelBuilder.Entity<PlanPosteFrequency>().Property(x => x.IdFrequency)
                    .HasColumnName("ID_FREQUENCY");

            modelBuilder.Entity<PlanPosteFrequency>().Property(x => x.PreviewAmount)
                    .HasColumnName("PREVIEW_AMOUNT");

            modelBuilder.Entity<PlanPosteFrequency>()
                   .HasKey(x => x.Id);

            modelBuilder.Entity<PlanPosteFrequency>()
                    .HasOne(x => x.PlanPoste)
                    .WithMany()
                    .HasForeignKey(x => x.IdPlanPoste)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanPosteFrequency>()
                    .HasOne(x => x.Frequency)
                    .WithMany()
                    .HasForeignKey(x => x.IdFrequency)
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

//[Column("ID_FREQUENCY")]
//public int IdFrequency { get; set; }

//[ForeignKey("IdFrequency")]
//public Month Frequency { get; set; }

//[Column("PREVIEW_AMOUNT")]
//public double PreviewAmount { get; set; }