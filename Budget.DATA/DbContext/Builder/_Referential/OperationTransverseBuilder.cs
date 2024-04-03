using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationTransverseBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTransverse>()
                .ToTable("OPERATION_TRANSVERSE", "ref");

            modelBuilder.Entity<OperationTransverse>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationTransverse>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");

            modelBuilder.Entity<OperationTransverse>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(255);

            modelBuilder.Entity<OperationTransverse>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<OperationTransverse>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Required]
//[Column("LABEL")]
//[StringLength(255)]
//public string Label { get; set; }

//[Column("ID_USER")]
//public int IdUser { get; set; }
//[ForeignKey("IdUser")]
//public User User { get; set; }