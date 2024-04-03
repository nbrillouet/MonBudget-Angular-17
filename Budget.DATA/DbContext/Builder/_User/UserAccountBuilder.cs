using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserAccountBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .ToTable("USER_ACCOUNT", "user");

            modelBuilder.Entity<UserAccount>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<UserAccount>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");
            modelBuilder.Entity<UserAccount>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");

            modelBuilder.Entity<UserAccount>().Property(x => x.ActivationCode)
                .HasColumnName("ACTIVATION_CODE");

            modelBuilder.Entity<UserAccount>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<UserAccount>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<UserAccount>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.IdAccount)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }

}
