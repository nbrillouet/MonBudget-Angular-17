using Budget.MODEL.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class GenericSelectBuilder
    {
        public static void CreateTable<T>(ModelBuilder modelBuilder) where T : Select
        {

            modelBuilder.Entity<T>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<T>().Property(x => x.Label)
                .HasColumnName("LABEL");

            modelBuilder.Entity<T>()
               .HasKey(x => x.Id);
        }
    }
}
