using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;


namespace Budget.DATA.Builder
{
    public class ParameterBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameter>()
                .ToTable("PARAMETER", "gen");

            modelBuilder.Entity<Parameter>().Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Parameter>().Property(x => x.IdUser)
                .HasColumnName("ID_USER");

            modelBuilder.Entity<Parameter>().Property(x => x.ImportFileDir)
                .HasColumnName("IMPORT_FILE_DIR")
                .HasMaxLength(100);

            modelBuilder.Entity<Parameter>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Parameter>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
//[Column("ID")]
//public int Id { get; set; }

//[Column("IMPORT_FILE_DIR")]
//[StringLength(100)]
//public string ImportFileDir { get; set; }

//[Column("ID_USER")]
//public int IdUser { get; set; }
//[ForeignKey("IdUser")]
//public User User { get; set; }