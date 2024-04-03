using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapAddressTypeBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapAddressType>()
                .ToTable("GMAP_ADDRESS_TYPE", "gmap");

            modelBuilder.Entity<GMapAddressType>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<GMapAddressType>().Property(x => x.IdGMapAddress)
                .HasColumnName("ID_GMAP_ADDRESS");
            modelBuilder.Entity<GMapAddressType>().Property(x => x.IdGMapType)
                .HasColumnName("ID_GMAP_TYPE");

            modelBuilder.Entity<GMapAddressType>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<GMapAddressType>()
                .HasOne(x => x.GMapAddress)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAddress)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddressType>()
                .HasOne(x => x.GMapType)
                .WithMany()
                .HasForeignKey(x => x.IdGMapType)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }
//[Column("ID_GMAP_ADDRESS")]
//public int IdGMapAddress { get; set; }

//[ForeignKey("IdGMapAddress")]
//public GMapAddress GMapAddress { get; set; }

//[Column("ID_GMAP_TYPE")]
//public int IdGMapType { get; set; }
//[ForeignKey("IdGMapType")]
//public GMapType GMapType { get; set; }