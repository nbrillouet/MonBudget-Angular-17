using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapAdministrativeAreaLevel2Builder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapAdministrativeAreaLevel2>()
                .ToTable("GMAP_ADMINISTRATIVE_AREA_LEVEL_2", "gmap");

            GenericSelectBuilder.CreateTable<GMapAdministrativeAreaLevel2>(modelBuilder);

        }
    }
}
