using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationTypeFamilyBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTypeFamily>()
                .ToTable("OPERATION_TYPE_FAMILY", "ref");

            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.IdMovement)
                .HasColumnName("ID_MOVEMENT");
            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.IdAsset)
                .HasColumnName("ID_ASSET");

            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);
            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.IdUserGroup)
                .HasColumnName("ID_USER_GROUP");
            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.IsMandatory)
                .HasColumnName("IS_MANDATORY")
                .HasMaxLength(4);
            modelBuilder.Entity<OperationTypeFamily>().Property(x => x.Code)
                .HasColumnName("CODE")
                .HasMaxLength(4);

            //PK
            modelBuilder.Entity<OperationTypeFamily>()
               .HasKey(x => x.Id);

            //FK
            modelBuilder.Entity<OperationTypeFamily>()
                .HasOne(x => x.Movement)
                .WithMany()
                .HasForeignKey(x => x.IdMovement)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationTypeFamily>()
                .HasOne(x => x.Asset)
                .WithMany()
                .HasForeignKey(x => x.IdAsset)
                .OnDelete(DeleteBehavior.NoAction);

            //INDEX
            modelBuilder.Entity<OperationTypeFamily>()
                .HasIndex(i => new { i.Id, i.IdMovement })
                .HasDatabaseName("IX_OTF_Id_IdMovement")
                .IsUnique();
        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }

//[Column("ID_MOVEMENT")]
//public int IdMovement { get; set; }
//[ForeignKey("IdMovement")]
//public Movement Movement { get; set; }

////[Column("LOGO_CLASS_NAME")]
////[StringLength(30)]
////public string LogoClassName { get; set; }

//[Column("ID_USER_GROUP")]
//public int IdUserGroup { get; set; }

//[Column("IS_MANDATORY")]
//public bool IsMandatory { get; set; }
//[Column("CODE")]
//[StringLength(4)]
//public string Code { get; set; }

//[Column("ID_ASSET")]
//public int IdAsset { get; set; }
//[ForeignKey("IdAsset")]
//public Asset Asset { get; set; }