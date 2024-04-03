using AutoMapper;
using Budget.DATA;
using Budget.SERVICE.GMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public static class RegistryService
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserShortcutService, UserShortcutService>();
            services.AddScoped<IUserCustomOtfService, UserCustomOtfService>();
            services.AddScoped<IUserPreferenceService, UserPreferenceService>();
            services.AddScoped<IBankFamilyService, BankFamilyService>();
            services.AddScoped<IBankSubFamilyService, BankSubFamilyService>();
            services.AddScoped<IBankAgencyService, BankAgencyService>();
            services.AddScoped<IAccountStatementImportService, AccountStatementImportService>();
            services.AddScoped<IBanquePopulaireImportFileService, BanquePopulaireImportFileService>();
            services.AddScoped<ICreditAgricoleImportFileService, CreditAgricoleImportFileService>();
            services.AddScoped<IBankFileDefinitionService, BankFileDefinitionService>();
            services.AddScoped<IAccountStatementImportFileService, AccountStatementImportFileService>();
            services.AddScoped<IAccountStatementService, AccountStatementService>();
            services.AddScoped<IAsSoldeService, AsSoldeService>();
            services.AddScoped<IAsChartEvolutionService, AsChartEvolutionService>();
            services.AddScoped<IAsChartCategorisationService, AsChartCategorisationService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IOperationMethodService, OperationMethodService>();
            services.AddScoped<IOperationMethodLexicalService, OperationMethodLexicalService>();
            services.AddScoped<IOperationTypeService, OperationTypeService>();
            services.AddScoped<IOperationTypeFamilyService, OperationTypeFamilyService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IOperationDetailService, OperationDetailService>();
            services.AddScoped<IOperationTransverseService, OperationTransverseService>();
            services.AddScoped<IOperationTransverseAsifService, OperationTransverseAsifService>();
            services.AddScoped<IOperationTransverseAsService, OperationTransverseAsService>();
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPlanPosteReferenceService, PlanPosteReferenceService>();
            services.AddScoped<IPlanPosteFrequencyService, PlanPosteFrequencyService>();
            services.AddScoped<IMonthService, MonthService>();
            services.AddScoped<IPlanPosteUserService, PlanPosteUserService>();
            services.AddScoped<IPlanUserService, PlanUserService>();
            services.AddScoped<IPlanAccountService, PlanAccountService>();
            services.AddScoped<IReferenceTableService, ReferenceTableService>();
            services.AddScoped<IPosteService, PosteService>();
            services.AddScoped<IPlanPosteService, PlanPosteService>();
            services.AddScoped<IVPlanGlobalService, VPlanGlobalService>();
            services.AddScoped<IPlanDetailService, PlanDetailService>();
            services.AddScoped<IPlanPosteDetailService, PlanPosteDetailService>();
            services.AddScoped<IPlanFollowUpService, PlanFollowUpService>();
            services.AddScoped<IParameterService, ParameterService>();
            services.AddScoped<IOperationPlaceService, OperationPlaceService>();
            services.AddScoped<IOperationMethodOtfService, OperationMethodOtfService>();

            services.AddScoped<IGMapAddressService, GMapAddressService>();
            services.AddScoped<IGMapAdministrativeAreaLevel1Service, GMapAdministrativeAreaLevel1Service>();
            services.AddScoped<IGMapAdministrativeAreaLevel2Service, GMapAdministrativeAreaLevel2Service>();
            services.AddScoped<IGMapCountryService, GMapCountryService>();
            services.AddScoped<IGMapLocalityService, GMapLocalityService>();
            services.AddScoped<IGMapNeighborhoodService, GMapNeighborhoodService>();
            services.AddScoped<IGMapPostalCodeService, GMapPostalCodeService>();
            services.AddScoped<IGMapRouteService, GMapRouteService>();
            services.AddScoped<IGMapStreetNumberService, GMapStreetNumberService>();
            services.AddScoped<IGMapSublocalityLevel1Service, GMapSublocalityLevel1Service>();
            services.AddScoped<IGMapSublocalityLevel2Service, GMapSublocalityLevel2Service>();
            services.AddScoped<IGMapTypeService, GMapTypeService>();
            services.AddScoped<IGMapTypeLanguageService, GMapTypeLanguageService>();
            services.AddScoped<IGMapAddressTypeService, GMapAddressTypeService>();
            
            services.AddScoped<ISelectService, SelectService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailRegisterValidationService, MailRegisterValidationService>();
            services.AddScoped<IMailPasswordRecoveryService, MailPasswordRecoveryService>();
            services.AddScoped<IMailAskAccountOwnerService, MailAskAccountOwnerService>();
            services.AddScoped<IMailResponseAccountOwnerService, MailResponseAccountOwnerService>();
            services.AddScoped<IUserEventService, UserEventService>();

            services.AddScoped<IFilterTableService, FilterTableService>();
            services.AddScoped<IFilterDetailService, FilterDetailService>();
            services.AddScoped<IFilterMainService, FilterMainService>();
            services.AddScoped<IPlanNotAsService, PlanNotAsService>();
            services.AddScoped<IAccountStatementCheckReferentialService, AccountStatementCheckReferentialService>();
            services.AddScoped<IOperationCheckReferentialService, OperationCheckReferentialService>();
            services.AddScoped<IUserCheckReferentialService, UserCheckReferentialService>();
            services.AddScoped<IOperationTypeCheckReferentialService, OperationTypeCheckReferentialService>();

            services.AddScoped<IBusinessExceptionMessageService, BusinessExceptionMessageService>();
            services.AddScoped<IBusinessExceptionLibraryService, BusinessExceptionLibraryService>();

            services.AddTransient<ReferentialService>();
            services.AddTransient<FilterService>();

            services.AddAutoMapper(typeof(RegistryService));

            services.RegisterData(configuration);

            return services;
        }
    }
}
