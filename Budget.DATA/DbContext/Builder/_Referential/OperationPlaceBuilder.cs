using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Builder
{
    public class OperationPlaceBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationPlace>()
                .ToTable("OPERATION_PLACE", "ref");

            modelBuilder.Entity<OperationPlace>().Property(x => x.Id)
                    .HasColumnName("ID");


            modelBuilder.Entity<OperationPlace>().Property(x => x.Label)
                    .HasColumnName("LABEL")
                    .HasMaxLength(100);

            modelBuilder.Entity<OperationPlace>().Property(x => x.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100);

            modelBuilder.Entity<OperationPlace>()
                   .HasKey(x => x.Id);
        }
    }
}
