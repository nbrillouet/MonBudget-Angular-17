using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Builder
{
    public class OperationMethodBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationMethod>()
                .ToTable("OPERATION_METHOD", "ref");

            modelBuilder.Entity<OperationMethod>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationMethod>().Property(x => x.Label)
                .HasColumnName("LABEL")
                .HasMaxLength(50);

            modelBuilder.Entity<OperationMethod>().Ignore(x => x.KeywordWork);

            modelBuilder.Entity<OperationMethod>()
               .HasKey(x => x.Id);

            

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//[StringLength(50)]
//public string Label { get; set; }

//[NotMapped]
//public string KeywordWork { get; set; }