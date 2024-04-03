using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapNeighborhoodBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapNeighborhood>()
                .ToTable("GMAP_NEIGHBORHOOD", "gmap");

            GenericSelectBuilder.CreateTable<GMapNeighborhood>(modelBuilder);

        }
    }
}
