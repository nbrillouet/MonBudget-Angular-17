using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapAddressBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapAddress>()
                .ToTable("GMAP_ADDRESS", "gmap");

            modelBuilder.Entity<GMapAddress>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapAdministrativeAreaLevel1)
                .HasColumnName("ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapAdministrativeAreaLevel2)
                .HasColumnName("ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_2");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapCountry)
                .HasColumnName("ID_GMAP_COUNTRY");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapLocality)
                .HasColumnName("ID_GMAP_LOCALITY");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapNeighborhood)
                .HasColumnName("ID_GMAP_NEIGHBORHOOD");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapPostalCode)
                .HasColumnName("ID_GMAP_POSTAL_CODE");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapRoute)
                .HasColumnName("ID_GMAP_ROUTE");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapStreetNumber)
                .HasColumnName("ID_GMAP_STREET_NUMBER");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapSublocalityLevel1)
                .HasColumnName("ID_GMAP_SUBLOCALITY_LEVEL_1");
            modelBuilder.Entity<GMapAddress>().Property(x => x.IdGMapSublocalityLevel2)
                .HasColumnName("ID_GMAP_SUBLOCALITY_LEVEL_2");

            modelBuilder.Entity<GMapAddress>().Property(x => x.FormattedAddress)
                .HasColumnName("FORMATTED_ADDRESS");
            modelBuilder.Entity<GMapAddress>().Property(x => x.Lat)
                .HasColumnName("LAT");
            modelBuilder.Entity<GMapAddress>().Property(x => x.Lng)
                .HasColumnName("LNG");

            modelBuilder.Entity<GMapAddress>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapAdministrativeAreaLevel1)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAdministrativeAreaLevel1)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapAdministrativeAreaLevel2)
                .WithMany()
                .HasForeignKey(x => x.IdGMapAdministrativeAreaLevel1)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapCountry)
                .WithMany()
                .HasForeignKey(x => x.IdGMapCountry)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapLocality)
                .WithMany()
                .HasForeignKey(x => x.IdGMapLocality)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapNeighborhood)
                .WithMany()
                .HasForeignKey(x => x.IdGMapNeighborhood)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapPostalCode)
                .WithMany()
                .HasForeignKey(x => x.IdGMapPostalCode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapRoute)
                .WithMany()
                .HasForeignKey(x => x.IdGMapRoute)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapStreetNumber)
                .WithMany()
                .HasForeignKey(x => x.IdGMapStreetNumber)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapSublocalityLevel1)
                .WithMany()
                .HasForeignKey(x => x.IdGMapSublocalityLevel1)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GMapAddress>()
                .HasOne(x => x.GMapSublocalityLevel2)
                .WithMany()
                .HasForeignKey(x => x.IdGMapSublocalityLevel2)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

//[Column("ID")]
//public int Id { get; set; }

//[Required]
//[Column("FORMATTED_ADDRESS")]
//public string FormattedAddress { get; set; }

//[Required]
//[Column("LAT")]
//public double Lat { get; set; }

//[Required]
//[Column("LNG")]
//public double Lng { get; set; }

//[Column("ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1")]
//public int idGMapAdministrativeAreaLevel1 { get; set; }

//[ForeignKey("idGMapAdministrativeAreaLevel1")]
//public GMapAdministrativeAreaLevel1 gMapAdministrativeAreaLevel1 { get; set; }

//[Column("ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_2")]
//public int idGMapAdministrativeAreaLevel2 { get; set; }

//[ForeignKey("idGMapAdministrativeAreaLevel2")]
//public GMapAdministrativeAreaLevel2 gMapAdministrativeAreaLevel2 { get; set; }

//[Column("ID_GMAP_COUNTRY")]
//public int idGMapCountry { get; set; }

//[ForeignKey("idGMapCountry")]
//public GMapCountry gMapCountry { get; set; }

//[Column("ID_GMAP_LOCALITY")]
//public int idGMapLocality { get; set; }

//[ForeignKey("idGMapLocality")]
//public GMapLocality gMapLocality { get; set; }

//[Column("ID_GMAP_NEIGHBORHOOD")]
//public int idGMapNeighborhood { get; set; }

//[ForeignKey("idGMapNeighborhood")]
//public GMapNeighborhood gMapNeighborhood { get; set; }

//[Column("ID_GMAP_POSTAL_CODE")]
//public int idGMapPostalCode { get; set; }

//[ForeignKey("idGMapPostalCode")]
//public GMapPostalCode gMapPostalCode { get; set; }

//[Column("ID_GMAP_ROUTE")]
//public int idGMapRoute { get; set; }

//[ForeignKey("idGMapRoute")]
//public GMapRoute gMapRoute { get; set; }
////---
//[Column("ID_GMAP_STREET_NUMBER")]
//public int idGMapStreetNumber { get; set; }

//[ForeignKey("idGMapStreetNumber")]
//public GMapStreetNumber gMapStreetNumber { get; set; }

//[Column("ID_GMAP_SUBLOCALITY_LEVEL_1")]
//public int idGMapSublocalityLevel1 { get; set; }

//[ForeignKey("idGMapSublocalityLevel1")]
//public GMapSublocalityLevel1 gMapSublocalityLevel1 { get; set; }

//[Column("ID_GMAP_SUBLOCALITY_LEVEL_2")]
//public int idGMapSublocalityLevel2 { get; set; }

//[ForeignKey("idGMapSublocalityLevel2")]
//public GMapSublocalityLevel2 gMapSublocalityLevel2 { get; set; }