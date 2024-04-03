using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PlanBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
                .ToTable("PLAN", "plan");

            modelBuilder.Entity<Plan>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Plan>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(100);
            modelBuilder.Entity<Plan>().Property(x => x.Year)
                .HasColumnName("YEAR");
            modelBuilder.Entity<Plan>().Property(x => x.Color)
                .HasColumnName("COLOR");

            modelBuilder.Entity<Plan>()
               .HasKey(x => x.Id);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//[StringLength(100)]
//public string Label { get; set; }

//[Column("YEAR")]
//public int Year { get; set; }

//[Column("COLOR")]
//public string Color { get; set; }