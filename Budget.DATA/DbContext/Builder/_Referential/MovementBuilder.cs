using Budget.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class MovementBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movement>()
                .ToTable("MOVEMENT", "ref");

            modelBuilder.Entity<Movement>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Movement>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);

            modelBuilder.Entity<Movement>()
               .HasKey(x => x.Id);

        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }
