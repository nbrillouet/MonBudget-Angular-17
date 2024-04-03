using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationDetailBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationDetail>()
                .ToTable("OPERATION_DETAIL", "ref");

            modelBuilder.Entity<OperationDetail>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationDetail>().Property(x => x.IdOperation)
                .HasColumnName("ID_OPERATION");
            modelBuilder.Entity<OperationDetail>().Property(x => x.IdGMapAddress)
                .HasColumnName("ID_GMAP_ADDRESS");
            modelBuilder.Entity<OperationDetail>().Property(x => x.IdOperationPlace)
                .HasColumnName("ID_OPERATION_PLACE");

            modelBuilder.Entity<OperationDetail>().Property(x => x.KeywordOperation)
                .HasColumnName("KEYWORD_OPERATION");
            modelBuilder.Entity<OperationDetail>().Property(x => x.KeywordPlace)
                .HasColumnName("KEYWORD_PLACE");
            modelBuilder.Entity<OperationDetail>().Property(x => x.OperationLabel)
                .HasColumnName("OPERATION_LABEL");
            modelBuilder.Entity<OperationDetail>().Property(x => x.PlaceLabel)
                .HasColumnName("PLACE_LABEL");

            modelBuilder.Entity<OperationDetail>().Property(x => x.IdUserGroup)
                .HasColumnName("ID_USER_GROUP");
            modelBuilder.Entity<OperationDetail>().Property(x => x.IsMandatory)
                .HasColumnName("IS_MANDATORY");
            //modelBuilder.Entity<OperationDetail>().Property(x => x.IsMandatory)
            //    .HasColumnName("ID_MOVEMENT");

            //PK
            modelBuilder.Entity<OperationDetail>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<OperationDetail>()
                .HasOne(x => x.Operation)
                .WithMany()
                .HasForeignKey(x => x.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationDetail>()
                .HasOne(x => x.GMapAddress)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAddress)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationDetail>()
                .HasOne(x => x.OperationPlace)
                .WithMany()
                .HasForeignKey(x => x.IdOperationPlace)
                .OnDelete(DeleteBehavior.NoAction);

            //INDEX
            modelBuilder.Entity<OperationDetail>()
                .HasIndex(p => new { p.KeywordOperation, p.KeywordPlace, p.IdUserGroup })
                .HasDatabaseName("IX_Keyword")
                .IsUnique();
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_OPERATION")]
//public int IdOperation { get; set; }

//[ForeignKey("IdOperation")]
//public Operation Operation { get; set; }

//[Column("KEYWORD_OPERATION")]
//public string KeywordOperation { get; set; }

//[Column("KEYWORD_PLACE")]
//public string KeywordPlace { get; set; }

//[Column("ID_GMAP_ADDRESS")]
//public int IdGMapAddress { get; set; }

//[ForeignKey("IdGMapAddress")]
//public GMapAddress GMapAddress { get; set; }
//[Column("ID_USER_GROUP")]
//public int IdUserGroup { get; set; }
//[Column("IS_MANDATORY")]
//public bool IsMandatory { get; set; }