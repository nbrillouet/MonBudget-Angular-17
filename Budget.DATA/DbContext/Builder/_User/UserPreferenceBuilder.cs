using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class UserPreferenceBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPreference>()
                .ToTable("USER_PREFERENCE", "user");

            modelBuilder.Entity<UserPreference>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<UserPreference>().Property(x => x.Theme)
                .HasColumnName("THEME");
            modelBuilder.Entity<UserPreference>().Property(x => x.Scheme)
                .HasColumnName("SCHEME");
            modelBuilder.Entity<UserPreference>().Property(x => x.Layout)
                .HasColumnName("LAYOUT");
            modelBuilder.Entity<UserPreference>().Property(x => x.Language)
                .HasColumnName("LANGUAGE");
            modelBuilder.Entity<UserPreference>().Property(x => x.AvatarUrl)
                .HasColumnName("AVATAR_URL");
            modelBuilder.Entity<UserPreference>().Property(x => x.BannerUrl)
                .HasColumnName("BANNER_URL");
            modelBuilder.Entity<UserPreference>().Property(x => x.Status)
                .HasColumnName("STATUS");

            modelBuilder.Entity<UserPreference>()
                .HasKey(x => x.Id);

        }
    }
}
