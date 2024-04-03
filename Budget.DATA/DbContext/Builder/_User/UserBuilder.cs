using Budget.MODEL;
using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("USER", "user");

            modelBuilder.Entity<User>().Property(x => x.Id)
                .HasColumnName("ID");
            modelBuilder.Entity<User>().Property(x => x.IdGMapAddress)
                .HasColumnName("ID_GMAP_ADDRESS");
            modelBuilder.Entity<User>().Property(x => x.IdUserPreference)
                .HasColumnName("ID_USER_PREFERENCE");

            modelBuilder.Entity<User>().Property(x => x.UserName)
                .HasColumnName("USER_NAME");
            modelBuilder.Entity<User>().Property(x => x.LastName)
                .HasColumnName("LAST_NAME");
            modelBuilder.Entity<User>().Property(x => x.FirstName)
                .HasColumnName("FIRST_NAME");
            modelBuilder.Entity<User>().Property(x => x.PasswordHash)
                .HasColumnName("PASSWORD_HASH");
            modelBuilder.Entity<User>().Property(x => x.PasswordSalt)
                .HasColumnName("PASSWORD_SALT");
            modelBuilder.Entity<User>().Property(x => x.Gender)
                .HasColumnName("GENDER");
            modelBuilder.Entity<User>().Property(x => x.DateOfBirth)
                .HasColumnName("BIRTH_DATE");
            modelBuilder.Entity<User>().Property(x => x.DateCreated)
                .HasColumnName("CREATION_DATE");
            modelBuilder.Entity<User>().Property(x => x.DateLastActive)
                .HasColumnName("LAST_ACTIVE_DATE");
            modelBuilder.Entity<User>().Property(x => x.IdUserGroup)
                .HasColumnName("ID_USER_GROUP");
            modelBuilder.Entity<User>().Property(x => x.Email)
                .HasColumnName("MAIL_ADDRESS");
            modelBuilder.Entity<User>().Property(x => x.ActivationCode)
                .HasColumnName("ACTIVATION_CODE");
            modelBuilder.Entity<User>().Property(x => x.ActivationDateSend)
                .HasColumnName("ACTIVATION_DATE_SEND");
            modelBuilder.Entity<User>().Property(x => x.ActivationIsConfirmed)
                .HasColumnName("ACTIVATION_IS_CONFIRMED");
            modelBuilder.Entity<User>().Property(x => x.Role)
                .HasColumnName("ROLE");


            modelBuilder.Entity<User>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasOne(x => x.GMapAddress)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAddress)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(x => x.UserPreference)
                .WithMany()
                .HasForeignKey(x => x.IdUserPreference)
                .OnDelete(DeleteBehavior.NoAction);
        }
            

    }
}
