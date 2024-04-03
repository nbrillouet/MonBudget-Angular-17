using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanPosteBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanPoste>()
                .ToTable("PLAN_POSTE", "plan");

            modelBuilder.Entity<PlanPoste>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PlanPoste>().Property(x => x.IdPlan)
                .HasColumnName("ID_PLAN");
            modelBuilder.Entity<PlanPoste>().Property(x => x.IdPoste)
                .HasColumnName("ID_POSTE");
            modelBuilder.Entity<PlanPoste>().Property(x => x.IdReferenceTable)
                .HasColumnName("ID_REFERENCE_TABLE");

            modelBuilder.Entity<PlanPoste>().Property(x => x.Label)
                .HasColumnName("LABEL");

            modelBuilder.Entity<PlanPoste>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<PlanPoste>()
                .HasOne(x => x.Plan)
                .WithMany()
                .HasForeignKey(x => x.IdPlan)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanPoste>()
                .HasOne(x => x.Poste)
                .WithMany()
                .HasForeignKey(x => x.IdPoste)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanPoste>()
                .HasOne(x => x.ReferenceTable)
                .WithMany()
                .HasForeignKey(x => x.IdReferenceTable)
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

//[Column("ID_POSTE")]
//public int IdPoste { get; set; }

//[ForeignKey("IdPoste")]
//public Poste Poste { get; set; }

//[Column("ID_REFERENCE_TABLE")]
//public int IdReferenceTable { get; set; }

//[ForeignKey("IdReferenceTable")]
//public ReferenceTable ReferenceTable { get; set; }

//[Column("LABEL")]
//public string Label { get; set; }