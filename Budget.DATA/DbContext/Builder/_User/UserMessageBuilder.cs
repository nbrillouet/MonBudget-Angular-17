using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserMessageBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>()
                .ToTable("USER_MESSAGE", "user");

            modelBuilder.Entity<UserMessage>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<UserMessage>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");

            modelBuilder.Entity<UserMessage>().Property(x => x.From)
                .HasColumnName("MESSAGE_FROM");
            modelBuilder.Entity<UserMessage>().Property(x => x.DateSent)
                .HasColumnName("MESSAGE_DATE_SENT");
            modelBuilder.Entity<UserMessage>().Property(x => x.Subject)
                .HasColumnName("MESSAGE_SUBJECT");
            modelBuilder.Entity<UserMessage>().Property(x => x.Body)
                .HasColumnName("MESSAGE_BODY");
            modelBuilder.Entity<UserMessage>().Property(x => x.IsRead)
                .HasColumnName("IS_READ");


            modelBuilder.Entity<UserMessage>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<UserMessage>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

