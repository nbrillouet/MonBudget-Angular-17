using Budget.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserShortcutBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserShortcut>()
                .ToTable("USER_SHORTCUT", "user");

            modelBuilder.Entity<UserShortcut>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<UserShortcut>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");

            modelBuilder.Entity<UserShortcut>().Property(x => x.Title)
                .HasColumnName("TITLE");
            modelBuilder.Entity<UserShortcut>().Property(x => x.Type)
                .HasColumnName("TYPE");
            modelBuilder.Entity<UserShortcut>().Property(x => x.Icon)
                .HasColumnName("ICON");
            modelBuilder.Entity<UserShortcut>().Property(x => x.Url)
                .HasColumnName("URL");


            modelBuilder.Entity<UserShortcut>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<UserShortcut>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
