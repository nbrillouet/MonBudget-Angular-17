using Budget.DATA.Builder;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA
{

    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
            
        }
        //===================== ACCOUNT STATEMENT =================================//
        public DbSet<AccountStatement> AccountStatement { get; set; }
        public DbSet<AccountStatementImport> AccountStatementImport { get; set; }
        public DbSet<AccountStatementImportFile> AccountStatementImportFile { get; set; }
        public DbSet<AccountStatementPlan> AccountStatementPlan { get; set; }
        public DbSet<OperationTransverseAsif> OperationTransverseAsif { get; set; }
        public DbSet<OperationTransverseAs> OperationTransverseAs { get; set; }

        //===================== GENERIC =================================//
        public DbSet<Month> Month { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        //===================== GMAP =================================//
        public DbSet<GMapAddress> GMapAddress { get; set; }
        public DbSet<GMapAdministrativeAreaLevel1> GMapAdministrativeAreaLevel1 { get; set; }
        public DbSet<GMapAdministrativeAreaLevel2> GMapAdministrativeAreaLevel2 { get; set; }
        public DbSet<GMapCountry> GMapCountry { get; set; }
        public DbSet<GMapLocality> GMapLocality { get; set; }
        public DbSet<GMapNeighborhood> GMapNeighborhood { get; set; }
        public DbSet<GMapPostalCode> GMapPostalCode { get; set; }
        public DbSet<GMapRoute> GMapRoute { get; set; }
        public DbSet<GMapStreetNumber> GMapStreetNumber { get; set; }
        public DbSet<GMapSublocalityLevel1> GMapSublocalityLevel1 { get; set; }
        public DbSet<GMapSublocalityLevel2> GMapSublocalityLevel2 { get; set; }
        public DbSet<GMapType> GMapType { get; set; }
        public DbSet<GMapTypeLanguage> GMapTypeLanguage { get; set; }
        public DbSet<GMapAddressType> GMapAddressType { get; set; }

        //===================== PLAN =================================//
        public DbSet<Plan> Plan { get; set; }
        public DbSet<PlanAccount> PlanAccount { get; set; }
        public DbSet<PlanPoste> PlanPoste { get; set; }
        public DbSet<PlanPosteFrequency> PlanPosteFrequency { get; set; }
        public DbSet<PlanPosteReference> PlanPosteReference { get; set; }
        public DbSet<PlanPosteUser> PlanPosteUser { get; set; }
        public DbSet<PlanUser> PlanUser { get; set; }
        public DbSet<Poste> Poste { get; set; }
        public DbSet<ReferenceTable> ReferenceTable { get; set; }
        public DbSet<VPlanGlobal> VPlanGlobal { get; set; }

        //===================== REFERENTIAL =================================//
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<BankAgency> BankAgency { get; set; }
        public DbSet<BankFamily> BankFamily { get; set; }
        public DbSet<BankFileDefinition> BankFileDefinition { get; set; }
        public DbSet<BankSubFamily> BankSubFamily { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<OperationDetail> OperationDetail { get; set; }
        public DbSet<OperationMethod> OperationMethod { get; set; }
        public DbSet<OperationMethodLexical> OperationMethodLexical { get; set; }
        public DbSet<OperationTransverse> OperationTransverse { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<OperationTypeFamily> OperationTypeFamily { get; set; }
        public DbSet<StateAsif> StateAsif { get; set; }
        public DbSet<OperationPlace> OperationPlace { get; set; }
        public DbSet<OperationMethodOtf> OperationMethodOtf { get; set; }

        //===================== USER =================================//
        public DbSet<User> User { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserCustomOtf> UserCustomOtf { get; set; }
        public DbSet<UserMessage> UserMessage { get; set; }
        public DbSet<UserPreference> UserPreference { get; set; }
        public DbSet<UserShortcut> UserShortcut { get; set; }


        //Procedures NOT MAPPED
        public virtual DbSet<SoldeDto> SoldeDto { get; set; }
        public virtual DbSet<AsEvolutionCdbDto> AsEvolutionDto { get; set; }
        public virtual DbSet<BaseChartData> BaseChartData { get; set; }
        public virtual DbSet<SelectNameValueDto<double>> SelectNameValueDto { get; set; }
        //public DbQuery<VPlanGlobal> VPlanGlobal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-0M47AE3\SQLEXPRESS;Database=Budget;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer(@"Server=PS10;Database=XmlToSwift_Demo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //===================== ACCOUNT STATEMENT =================================//
            AccountStatementBuilder.CreateTable(modelBuilder);
            AccountStatementImportBuilder.CreateTable(modelBuilder);
            AccountStatementImportFileBuilder.CreateTable(modelBuilder);
            AccountStatementPlanBuilder.CreateTable(modelBuilder);
            OperationTransverseAsifBuilder.CreateTable(modelBuilder);
            OperationTransverseAsBuilder.CreateTable(modelBuilder);

            //========== GENERIC =================================//
            MonthBuilder.CreateTable(modelBuilder);
            ParameterBuilder.CreateTable(modelBuilder);

            //========== GMAP =================================//
            GMapAddressBuilder.CreateTable(modelBuilder);
            GMapAdministrativeAreaLevel1Builder.CreateTable(modelBuilder);
            GMapAdministrativeAreaLevel2Builder.CreateTable(modelBuilder);
            GMapCountryBuilder.CreateTable(modelBuilder);
            GMapLocalityBuilder.CreateTable(modelBuilder);
            GMapNeighborhoodBuilder.CreateTable(modelBuilder);
            GMapPostalCodeBuilder.CreateTable(modelBuilder);
            GMapRouteBuilder.CreateTable(modelBuilder);
            GMapStreetNumberBuilder.CreateTable(modelBuilder);
            GMapSublocalityLevel1Builder.CreateTable(modelBuilder);
            GMapSublocalityLevel2Builder.CreateTable(modelBuilder);
            GMapTypeBuilder.CreateTable(modelBuilder);
            GMapTypeLanguageBuilder.CreateTable(modelBuilder);
            GMapAddressTypeBuilder.CreateTable(modelBuilder);

            //========== PLAN =================================//
            PlanBuilder.CreateTable(modelBuilder);
            PlanAccountBuilder.CreateTable(modelBuilder);
            PlanPosteBuilder.CreateTable(modelBuilder);
            PlanPosteFrequencyBuilder.CreateTable(modelBuilder);
            PlanPosteReferenceBuilder.CreateTable(modelBuilder);
            PlanPosteUserBuilder.CreateTable(modelBuilder);
            PlanUserBuilder.CreateTable(modelBuilder);
            PosteBuilder.CreateTable(modelBuilder);
            ReferenceTableBuilder.CreateTable(modelBuilder);
            VPlanGlobalBuilder.CreateTable(modelBuilder);

            //========== REFERENTIAL =================================//
            AccountBuilder.CreateTable(modelBuilder);
            AccountTypeBuilder.CreateTable(modelBuilder);
            AssetBuilder.CreateTable(modelBuilder);
            BankAgencyBuilder.CreateTable(modelBuilder);
            BankFamilyBuilder.CreateTable(modelBuilder);
            BankFileDefinitionBuilder.CreateTable(modelBuilder);
            BankSubFamilyBuilder.CreateTable(modelBuilder);
            MovementBuilder.CreateTable(modelBuilder);
            OperationBuilder.CreateTable(modelBuilder);
            OperationDetailBuilder.CreateTable(modelBuilder);
            OperationMethodBuilder.CreateTable(modelBuilder);
            OperationMethodLexicalBuilder.CreateTable(modelBuilder);
            OperationTransverseBuilder.CreateTable(modelBuilder);
            OperationTypeBuilder.CreateTable(modelBuilder);
            OperationTypeFamilyBuilder.CreateTable(modelBuilder);
            StateAsifBuilder.CreateTable(modelBuilder);
            OperationPlaceBuilder.CreateTable(modelBuilder);
            OperationMethodOtfBuilder.CreateTable(modelBuilder);

            //========== USER =================================//
            UserBuilder.CreateTable(modelBuilder);
            UserAccountBuilder.CreateTable(modelBuilder);
            UserCustomOtfBuilder.CreateTable(modelBuilder);
            UserMessageBuilder.CreateTable(modelBuilder);
            UserPreferenceBuilder.CreateTable(modelBuilder);
            UserShortcutBuilder.CreateTable(modelBuilder);

            //Procedures NOT MAPPED
            modelBuilder.Entity<SoldeDto>().HasNoKey();
            //modelBuilder.Ignore<SoldeDto>();

            //        NOT MAPPED
            // l DbSet<SoldeDto> SoldeDto { get; set; }
            //        l DbSet<AsEvolutionCdbDto> AsEvolutionDto { get; set; }
            //        l DbSet<BaseChartData> BaseChartData { get; set; }
            //        l DbSet<SelectNameValueDto< double >> SelectNameValueDto { get; set; }



            //        DeviseBuilder.CreateTable(modelBuilder);
            //HistoriqueDeviseBuilder.CreateTable(modelBuilder);
            //DeviseHierarchieBuilder.CreateTable(modelBuilder);
            //GroupeBuilder.CreateTable(modelBuilder);
            //GroupeDeviseBuilder.CreateTable(modelBuilder);
            //LimiteTypeBuilder.CreateTable(modelBuilder);
            //OptionStopLossBuilder.CreateTable(modelBuilder);
            //OptionPositionBuilder.CreateTable(modelBuilder);
            //OptionPeriodeBuilder.CreateTable(modelBuilder);
            //LimiteHeureBuilder.CreateTable(modelBuilder);
            //LimiteBuilder.CreateTable(modelBuilder);
            //GroupeLimiteBuilder.CreateTable(modelBuilder);
            //CalendrierDeviseBuilder.CreateTable(modelBuilder);

            ////Procedures NOT MAPPED
            ////modelBuilder.Ignore<SoldeDto>();

            //modelBuilder.Entity<Account>()
            //    .HasIndex(b => b.Number)
            //    .HasName("IX_AccountNumber")
            //    .IsUnique();

            //modelBuilder.Entity<Operation>()
            //    .HasIndex("Label", "IdOperationMethod", "IdOperationType")
            //    .HasName("IX_OperationKey")
            //    .IsUnique();

            //modelBuilder.Entity<OperationDetail>()
            //    .HasIndex(p => new { p.KeywordOperation, p.KeywordPlace, p.IdUserGroup })
            //    .HasName("IX_Keyword")
            //    .IsUnique();

            ////modelBuilder.Entity<OperationDetail>()
            ////    .HasIndex(p => new { p.KeywordOperation, p.KeywordPlace,p.IdUser})
            ////    .HasName("IX_Keyword")
            ////    .IsUnique();

            //modelBuilder.Entity<PlanUser>()
            //    .HasIndex(p => new { p.IdPlan, p.IdUser })
            //    .HasName("IX_PlanUser")
            //    .IsUnique();

            //modelBuilder.Entity<OperationTypeFamily>()
            //    .HasIndex(i => new { i.Id, i.IdMovement })
            //    .HasName("IX_OTF_Id_IdMovement")
            //    .IsUnique();

            //modelBuilder.Entity<AccountStatementPlan>()
            //    .HasIndex(p => new { p.IdAccountStatement, p.IdPlan })
            //    .HasName("IX_ASP_IdAccountStatement_IdPlan")
            //    .IsUnique();

            //modelBuilder.Entity<UserCustomOtf>()
            //    .HasIndex(p => new { p.IdOperationTypeFamily, p.IdUser, p.IdAccount })
            //    .HasName("IX_UCO_IdOperationTypeFamily_IdUser_IdAccount")
            //    .IsUnique();
            ////modelBuilder
            ////    .Query<VPlanGlobal>().ToView("V_PLAN_GLOBAL");



            ////Clef composite pour (une clef primaire ne suffit pas pour les proc stock: dans EF meme clef, meme resultat)
            //modelBuilder.Entity<BaseChartData>()
            //    .HasKey(a => new { a.Id, a.Amount });

            //////Entity<SoldeDto>.
            //modelBuilder.Entity<SoldeDto>().HasNoKey();
        }
    }
}
