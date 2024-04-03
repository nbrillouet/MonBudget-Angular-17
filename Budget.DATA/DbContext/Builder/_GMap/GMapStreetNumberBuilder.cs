using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapStreetNumberBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapStreetNumber>()
                .ToTable("GMAP_STREET_NUMBER", "gmap");

            GenericSelectBuilder.CreateTable<GMapStreetNumber>(modelBuilder);

        }
    }
}
