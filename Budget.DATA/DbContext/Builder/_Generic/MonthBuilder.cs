using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class MonthBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>()
                .ToTable("MONTH", "gen");

            modelBuilder.Entity<Month>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Month>().Property(x => x.Number)
                .HasColumnName("NUMBER");
            modelBuilder.Entity<Month>().Property(x => x.LanguageCode)
                .HasColumnName("LANGUAGE_CODE");
            modelBuilder.Entity<Month>().Property(x => x.LabelLong)
                .HasColumnName("LABEL_LONG");
            modelBuilder.Entity<Month>().Property(x => x.LabelShort)
                .HasColumnName("LABEL_SHORT");

            modelBuilder.Entity<Month>()
               .HasKey(x => x.Id);
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }
//[Column("NUMBER")]
//public string Number { get; set; }
//[Column("LANGUAGE_CODE")]
//public string LanguageCode { get; set; }
//[Column("LABEL_LONG")]
//public string LabelLong { get; set; }
//[Column("LABEL_SHORT")]
//public string LabelShort { get; set; }