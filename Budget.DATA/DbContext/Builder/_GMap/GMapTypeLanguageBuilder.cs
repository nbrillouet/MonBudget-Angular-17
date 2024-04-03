using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapTypeLanguageBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapTypeLanguage>()
                .ToTable("GMAP_TYPE_LANGUAGE", "gmap");

            modelBuilder.Entity<GMapTypeLanguage>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<GMapTypeLanguage>().Property(x => x.IdGMapType)
                .HasColumnName("ID_GMAP_TYPE");

            modelBuilder.Entity<GMapTypeLanguage>().Property(x => x.CountryCode)
                .HasColumnName("LANGUAGE_CODE");
            modelBuilder.Entity<GMapTypeLanguage>().Property(x => x.Label)
                .HasColumnName("LABEL");

            modelBuilder.Entity<GMapTypeLanguage>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<GMapTypeLanguage>()
                .HasOne(x => x.GMapType)
                .WithMany()
                .HasForeignKey(x => x.IdGMapType)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("ID_GMAP_TYPE")]
//public int IdGMapType { get; set; }

//[ForeignKey("IdGMapType")]
//public GMapType GMapType { get; set; }

//[Required]
//[Column("LANGUAGE_CODE")]
//public string CountryCode { get; set; }

//[Column("LABEL")]
//public string Label { get; set; }