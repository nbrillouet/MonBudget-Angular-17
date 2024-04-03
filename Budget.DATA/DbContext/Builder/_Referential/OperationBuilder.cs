using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .ToTable("OPERATION", "ref");

            modelBuilder.Entity<Operation>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Operation>().Property(x => x.IdOperationMethod)
                .HasColumnName("ID_OPERATION_METHOD");
            modelBuilder.Entity<Operation>().Property(x => x.IdOperationType)
                .HasColumnName("ID_OPERATION_TYPE");

            modelBuilder.Entity<Operation>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(255);
            modelBuilder.Entity<Operation>().Property(x => x.Reference)
                .HasColumnName("REFERENCE")
                .HasMaxLength(20);
            modelBuilder.Entity<Operation>().Property(x => x.IdUserGroup)
                .HasColumnName("ID_USER_GROUP");
            modelBuilder.Entity<Operation>().Property(x => x.IsMandatory)
                .HasColumnName("IS_MANDATORY");

            //PK
            modelBuilder.Entity<Operation>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<Operation>()
                .HasOne(x => x.OperationMethod)
                .WithMany()
                .HasForeignKey(x => x.IdOperationMethod)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Operation>()
                .HasOne(x => x.OperationType)
                .WithMany()
                .HasForeignKey(x => x.IdOperationType)
                .OnDelete(DeleteBehavior.NoAction);

            //index
            modelBuilder.Entity<Operation>()
                .HasIndex("Label", "IdOperationMethod", "IdOperationType")
                .HasDatabaseName("IX_OperationKey")
                .IsUnique();

        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Required]
//[Column("LABEL")]
//[StringLength(255)]
//public string Label { get; set; }

//[Column("REFERENCE")]
//[StringLength(20)]
//public string Reference { get; set; }

//[Column("ID_OPERATION_METHOD")]
//public int IdOperationMethod { get; set; }

//[ForeignKey("IdOperationMethod")]
//public OperationMethod OperationMethod { get; set; }

//[Column("ID_OPERATION_TYPE")]
//public int IdOperationType { get; set; }

//[ForeignKey("IdOperationType")]
//public OperationType OperationType { get; set; }
//[Column("ID_USER_GROUP")]
//public int IdUserGroup { get; set; }
//[Column("IS_MANDATORY")]
//public bool IsMandatory { get; set; }

//List<OperationDetail> OperationDetails { get; set; }
