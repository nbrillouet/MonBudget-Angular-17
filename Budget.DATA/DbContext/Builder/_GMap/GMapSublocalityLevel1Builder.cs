using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapSublocalityLevel1Builder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapSublocalityLevel1>()
                .ToTable("GMAP_SUBLOCALITY_LEVEL_1", "gmap");

            GenericSelectBuilder.CreateTable<GMapSublocalityLevel1>(modelBuilder);

        }
    }
}
