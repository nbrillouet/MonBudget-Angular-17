using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapRouteBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapRoute>()
                .ToTable("GMAP_ROUTE", "gmap");

            GenericSelectBuilder.CreateTable<GMapRoute>(modelBuilder);

        }
    }
}
