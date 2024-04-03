using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Builder
{
    public class VPlanGlobalBuilder
    {
        public static void CreateTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VPlanGlobal>()
                .ToTable("V_PLAN_GLOBAL", "plan");

            modelBuilder.Entity<VPlanGlobal>().Property(x => x.Id)
                    .HasColumnName("ID");

            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdAccountStatement)
                .HasColumnName("ID_ACCOUNT_STATEMENT");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdAccount)
                .HasColumnName("ID_ACCOUNT");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdMovement)
                .HasColumnName("ID_MOVEMENT");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.DateIntegration)
                    .HasColumnName("DATE_INTEGRATION");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.AmountOperation)
                    .HasColumnName("AMOUNT_OPERATION");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.PreviewAmount)
                    .HasColumnName("PREVIEW_AMOUNT");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdPlan)
                    .HasColumnName("ID_PLAN");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdPlanPoste)
                    .HasColumnName("ID_PLAN_POSTE");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.PlanPosteLabel)
                    .HasColumnName("PLAN_POSTE_LABEL");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdPoste)
                    .HasColumnName("ID_POSTE");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.IdReference)
                    .HasColumnName("ID_REFERENCE");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.LabelReference)
                    .HasColumnName("LABEL_REFERENCE");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.Month)
                    .HasColumnName("MONTH");
            modelBuilder.Entity<VPlanGlobal>().Property(x => x.Year)
                    .HasColumnName("YEAR");

        }
    }
}