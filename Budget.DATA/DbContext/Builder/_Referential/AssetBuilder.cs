using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class AssetBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .ToTable("ASSET", "ref");

            modelBuilder.Entity<Asset>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Asset>().Property(x => x.Path)
                .HasColumnName("PATH")
                .HasMaxLength(100);
            modelBuilder.Entity<Asset>().Property(x => x.Label)
                .HasColumnName("LABEL");
            modelBuilder.Entity<Asset>().Property(x => x.Extension)
                .HasColumnName("EXTENSION")
                .HasMaxLength(100);
            modelBuilder.Entity<Asset>().Property(x => x.IdFamily)
                .HasColumnName("ID_FAMILY");


            modelBuilder.Entity<Asset>()
               .HasKey(x => x.Id);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("PATH")]
//[StringLength(100)]
//public string Path { get; set; }

//[Column("NAME")]
//[StringLength(100)]
//public string Name { get; set; }

//[Column("EXTENSION")]
//[StringLength(100)]
//public string Extension { get; set; }

//[Column("ID_FAMILY")]
//public int IdFamily { get; set; }