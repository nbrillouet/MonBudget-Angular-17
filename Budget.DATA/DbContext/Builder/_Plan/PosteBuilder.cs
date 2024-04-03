using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class PosteBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poste>()
                .ToTable("POSTE", "plan");

            modelBuilder.Entity<Poste>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<Poste>().Property(x => x.IdMovement)
                    .HasColumnName("ID_MOVEMENT");

            modelBuilder.Entity<Poste>().Property(x => x.Label)
                    .HasColumnName("LABEL");

            modelBuilder.Entity<Poste>()
                   .HasKey(x => x.Id);

            modelBuilder.Entity<Poste>()
                    .HasOne(x => x.Movement)
                    .WithMany()
                    .HasForeignKey(x => x.IdMovement)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//public string Label { get; set; }

//[Column("ID_MOVEMENT")]
//public int IdMovement { get; set; }

//[ForeignKey("IdMovement")]
//public Movement Movement { get; set; }