using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserCustomOtfBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCustomOtf>()
                .ToTable("USER_CUSTOM_OTF", "user");

            modelBuilder.Entity<UserCustomOtf>().Property(x => x.Id)
                .HasColumnName("ID");
            modelBuilder.Entity<UserCustomOtf>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");
            modelBuilder.Entity<UserCustomOtf>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");
            modelBuilder.Entity<UserCustomOtf>().Property(x => x.IdOperationTypeFamily)
                .HasColumnName("ID_OPERATION_TYPE_FAMILY");
            
            //PK
            modelBuilder.Entity<UserCustomOtf>()
               .HasKey(x => x.Id);
            //FK
            modelBuilder.Entity<UserCustomOtf>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserCustomOtf>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.IdAccount)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserCustomOtf>()
                .HasOne(x => x.OperationTypeFamily)
                .WithMany()
                .HasForeignKey(x => x.IdOperationTypeFamily)
                .OnDelete(DeleteBehavior.NoAction);

            //INDEX
            modelBuilder.Entity<UserCustomOtf>()
                .HasIndex(p => new { p.IdOperationTypeFamily, p.IdUser, p.IdAccount })
                .HasDatabaseName("IX_UCO_IdOperationTypeFamily_IdUser_IdAccount")
                .IsUnique();
        }


    }
}
