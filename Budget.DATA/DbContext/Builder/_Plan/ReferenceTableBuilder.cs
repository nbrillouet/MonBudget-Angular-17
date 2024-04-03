using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class ReferenceTableBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferenceTable>()
                .ToTable("REFERENCE_TABLE", "plan");

            modelBuilder.Entity<ReferenceTable>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<ReferenceTable>().Property(x => x.TableName)
                    .HasColumnName("TABLE_NAME");
            modelBuilder.Entity<ReferenceTable>().Property(x => x.Label)
                    .HasColumnName("LABEL");

            modelBuilder.Entity<ReferenceTable>()
                   .HasKey(x => x.Id);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }
//[Column("TABLE_NAME")]
//public string TableName { get; set; }
//[Column("LABEL")]
//public string Label { get; set; }