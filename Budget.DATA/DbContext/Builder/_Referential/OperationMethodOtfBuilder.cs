using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationMethodOtfBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationMethodOtf>()
                .ToTable("OPERATION_METHOD_OTF", "ref");

            modelBuilder.Entity<OperationMethodOtf>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationMethodOtf>().Property(x => x.IdOperationMethod)
                .HasColumnName("ID_OPERATION_METHOD");
            modelBuilder.Entity<OperationMethodOtf>().Property(x => x.IdOperationTypeFamily)
                .HasColumnName("ID_OPERATION_TYPE_FAMILY");

            //PK
            modelBuilder.Entity<OperationMethodOtf>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<OperationMethodOtf>()
                .HasOne(x => x.OperationMethod)
                .WithMany()
                .HasForeignKey(x => x.IdOperationMethod)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationMethodOtf>()
                .HasOne(x => x.OperationTypeFamily)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTypeFamily)
                .OnDelete(DeleteBehavior.NoAction);


            //INDEX
            modelBuilder.Entity<OperationMethodOtf>()
                .HasIndex(p => new { p.IdOperationMethod, p.IdOperationTypeFamily })
                .HasDatabaseName("IX_PK_UNICITY")
                .IsUnique();
        }
    }
}
