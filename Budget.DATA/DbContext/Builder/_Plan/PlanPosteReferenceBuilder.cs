using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanPosteReferenceBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanPosteReference>()
                .ToTable("PLAN_POSTE_REFERENCE", "plan");

            modelBuilder.Entity<PlanPosteReference>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<PlanPosteReference>().Property(x => x.IdPlanPoste)
                    .HasColumnName("ID_PLAN_POSTE");
            modelBuilder.Entity<PlanPosteReference>().Property(x => x.IdReferenceTable)
                    .HasColumnName("ID_REFERENCE_TABLE");

            modelBuilder.Entity<PlanPosteReference>().Property(x => x.IdReference)
                    .HasColumnName("ID_REFERENCE");

            modelBuilder.Entity<PlanPosteReference>()
                   .HasKey(x => x.Id);

            modelBuilder.Entity<PlanPosteReference>()
                    .HasOne(x => x.PlanPoste)
                    .WithMany()
                    .HasForeignKey(x => x.IdPlanPoste)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanPosteReference>()
                    .HasOne(x => x.ReferenceTable)
                    .WithMany()
                    .HasForeignKey(x => x.IdReferenceTable)
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

//[Column("ID_REFERENCE_TABLE")]
//public int IdReferenceTable { get; set; }

//[ForeignKey("IdReferenceTable")]
//public ReferenceTable ReferenceTable { get; set; }


//[Column("ID_REFERENCE")]
//public int IdReference { get; set; }