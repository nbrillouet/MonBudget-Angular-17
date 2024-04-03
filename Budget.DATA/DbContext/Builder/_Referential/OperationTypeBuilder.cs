using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationTypeBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationType>()
                .ToTable("OPERATION_TYPE", "ref");

            modelBuilder.Entity<OperationType>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationType>().Property(x => x.IdOperationTypeFamily)
                .HasColumnName("ID_OPERATION_TYPE_FAMILY");

            modelBuilder.Entity<OperationType>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(200);
            modelBuilder.Entity<OperationType>().Property(x => x.IdUserGroup)
                .HasColumnName("ID_USER_GROUP");
            modelBuilder.Entity<OperationType>().Property(x => x.IsMandatory)
                .HasColumnName("IS_MANDATORY");
            modelBuilder.Entity<OperationType>().Property(x => x.Code)
                .HasColumnName("CODE")
                .HasMaxLength(5);


            modelBuilder.Entity<OperationType>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<OperationType>()
                .HasOne(x => x.OperationTypeFamily)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTypeFamily)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }

//[Column("ID_OPERATION_TYPE_FAMILY")]
//public int IdOperationTypeFamily { get; set; }

//[ForeignKey("IdOperationTypeFamily")]
//public OperationTypeFamily OperationTypeFamily { get; set; }
//[Column("ID_USER_GROUP")]
//public int IdUserGroup { get; set; }
//[Column("IS_MANDATORY")]
//public bool IsMandatory { get; set; }
//[Column("CODE")]
//[StringLength(4)]
//public string Code { get; set; }