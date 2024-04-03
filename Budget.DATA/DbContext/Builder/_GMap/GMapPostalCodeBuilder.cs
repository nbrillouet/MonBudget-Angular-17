using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapPostalCodeBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapPostalCode>()
                .ToTable("GMAP_POSTAL_CODE", "gmap");

            GenericSelectBuilder.CreateTable<GMapPostalCode>(modelBuilder);

        }
    }
}
