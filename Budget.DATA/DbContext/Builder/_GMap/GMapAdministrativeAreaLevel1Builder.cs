using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapAdministrativeAreaLevel1Builder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapAdministrativeAreaLevel1>()
                .ToTable("GMAP_ADMINISTRATIVE_AREA_LEVEL_1", "gmap");

            GenericSelectBuilder.CreateTable<GMapAdministrativeAreaLevel1>(modelBuilder);

        }
    }
}
