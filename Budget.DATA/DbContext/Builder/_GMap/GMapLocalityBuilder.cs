using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GMapLocalityBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GMapLocality>()
                .ToTable("GMAP_LOCALITY", "gmap");

            GenericSelectBuilder.CreateTable<GMapLocality>(modelBuilder);

        }
    }
}
