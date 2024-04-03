using Budget.DATA.Repositories;
using Budget.DATA.Repositories.ContextTransaction;
using Budget.DATA.Repositories.GMap;
using Budget.HELPER;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA
{
    public static class RegistryData
    {
        public static IServiceCollection RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserShortcutRepository, UserShortcutRepository>();
            services.AddScoped<IUserCustomOtfRepository, UserCustomOtfRepository>();
            services.AddScoped<IUserPreferenceRepository, UserPreferenceRepository>();
            services.AddScoped<IBankFamilyRepository, BankFamilyRepository>();
            services.AddScoped<IBankSubFamilyRepository, BankSubFamilyRepository>();
            services.AddScoped<IBankAgencyRepository, BankAgencyRepository>();
            services.AddScoped<IAccountStatementImportRepository, AccountStatementImportRepository>();
            services.AddScoped<IBankFileDefinitionRepository, BankFileDefinitionRepository>();
            services.AddScoped<IAccountStatementImportFileRepository, AccountStatementImportFileRepository>();
            services.AddScoped<IAccountStatementRepository, AccountStatementRepository>();
            services.AddScoped<IAsChartEvolutionRepository, AsChartEvolutionRepository>();
            services.AddScoped<IAsChartCategorisationRepository, AsChartCategorisationRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IOperationMethodRepository, OperationMethodRepository>();
            services.AddScoped<IOperationMethodLexicalRepository, OperationMethodLexicalRepository>();
            services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();
            services.AddScoped<IOperationTypeFamilyRepository, OperationTypeFamilyRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IOperationDetailRepository, OperationDetailRepository>();
            services.AddScoped<IOperationTransverseRepository, OperationTransverseRepository>();
            services.AddScoped<IOperationTransverseAsifRepository, OperationTransverseAsifRepository>();
            services.AddScoped<IOperationTransverseAsRepository, OperationTransverseAsRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IOperationPlaceRepository, OperationPlaceRepository>();
            services.AddScoped<IOperationMethodOtfRepository, OperationMethodOtfRepository>();

            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanPosteReferenceRepository, PlanPosteReferenceRepository>();
            services.AddScoped<IPlanPosteFrequencyRepository, PlanPosteFrequencyRepository>();
            services.AddScoped<IMonthRepository, MonthRepository>();
            services.AddScoped<IPlanPosteUserRepository, PlanPosteUserRepository>();
            services.AddScoped<IPlanUserRepository, PlanUserRepository>();
            services.AddScoped<IPlanAccountRepository, PlanAccountRepository>();
            services.AddScoped<IReferenceTableRepository, ReferenceTableRepository>();
            services.AddScoped<IPosteRepository, PosteRepository>();
            services.AddScoped<IPlanPosteRepository, PlanPosteRepository>();
            services.AddScoped<IVPlanGlobalRepository, VPlanGlobalRepository>();

            services.AddScoped<IParameterRepository, ParameterRepository>();

            services.AddScoped<IGMapAddressRepository, GMapAddressRepository>();
            services.AddScoped<IGMapAdministrativeAreaLevel1Repository, GMapAdministrativeAreaLevel1Repository>();
            services.AddScoped<IGMapAdministrativeAreaLevel2Repository, GMapAdministrativeAreaLevel2Repository>();
            services.AddScoped<IGMapCountryRepository, GMapCountryRepository>();
            services.AddScoped<IGMapLocalityRepository, GMapLocalityRepository>();
            services.AddScoped<IGMapNeighborhoodRepository, GMapNeighborhoodRepository>();
            services.AddScoped<IGMapPostalCodeRepository, GMapPostalCodeRepository>();
            services.AddScoped<IGMapRouteRepository, GMapRouteRepository>();
            services.AddScoped<IGMapStreetNumberRepository, GMapStreetNumberRepository>();
            services.AddScoped<IGMapSublocalityLevel1Repository, GMapSublocalityLevel1Repository>();
            services.AddScoped<IGMapSublocalityLevel2Repository, GMapSublocalityLevel2Repository>();
            services.AddScoped<IGMapTypeRepository, GMapTypeRepository>();
            services.AddScoped<IGMapTypeLanguageRepository, GMapTypeLanguageRepository>();
            services.AddScoped<IGMapAddressTypeRepository, GMapAddressTypeRepository>();
            services.AddScoped<IVPlanGlobalRepository, VPlanGlobalRepository>();

            services.AddScoped<IContextTransaction, ContextTransaction>();

            var defaultconnection = CryptoHelper.Decrypt(configuration.GetConnectionString("DefaultConnexion"));
            //Add context DB
            services.AddDbContext<BudgetContext>(options =>
            {
                options.UseSqlServer(defaultconnection);
            });

            return services;
            //services.AddDbContext<BudgetContext>(options =>
            //    options.UseSqlServer(CryptoHelper.Decrypt(Configuration.GetConnectionString("DefaultConnexion"))));
        }
    }
}
