using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Builder
{
    public class StateAsifBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateAsif>()
                .ToTable("STATE_ASIF", "ref");

            modelBuilder.Entity<StateAsif>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<StateAsif>().Property(x => x.Label)
                .HasColumnName("LABEL");
        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("LABEL")]
//public string Label { get; set; }