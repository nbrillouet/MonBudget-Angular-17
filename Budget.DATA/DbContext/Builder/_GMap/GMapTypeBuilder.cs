using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapTypeBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapType>()
                .ToTable("GMAP_TYPE", "gmap");

            modelBuilder.Entity<GMapType>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<GMapType>().Property(x => x.Keyword)
                .HasColumnName("KEYWORD");

            modelBuilder.Entity<GMapType>()
               .HasKey(x => x.Id);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Required]
//[Column("KEYWORD")]
//public string Keyword { get; set; }