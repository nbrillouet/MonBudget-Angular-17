using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapCountryBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapCountry>()
                .ToTable("GMAP_COUNTRY", "gmap");

            GenericSelectBuilder.CreateTable<GMapCountry>(modelBuilder);

        }
    }
}
