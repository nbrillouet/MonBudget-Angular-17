using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;

namespace Budget.SERVICE._Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SelectCode, Select>()
            .ReverseMap()
                .ForMember(d => d.Code, o => o.Ignore());

            CreateMap<User, Select>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.FirstName + " " + s.LastName));
            CreateMap<User, UserForMinimal>();
            
            //CreateMap<UserForRegister, User>()
            //    .ForMember(d => d.UserName, o => o.MapFrom(s => s.Name))
            //    .ForMember(d => d.MailAddress, o => o.MapFrom(s => s.Email))
            //    .ForAllOtherMembers(o => o.Ignore());
            CreateMap<UserPreference, UserPreferenceDto>()
                .ReverseMap();

            CreateMap<User, UserForRegister>()
                //.ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                //.ForMember(d => d.Name, o => o.MapFrom(s => s.UserName))
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.PasswordConfirm, o => o.Ignore())
            .ReverseMap();
                //.ForMember(d => d.UserName, o => o.MapFrom(s => s.Name))
                //.ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                //Todo a tester (enlever)
                //.ForAllOtherMembers(o => o.Ignore());



            CreateMap<User, UserForListDto>()
                //trouver l'age a partir de la date de naissance
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                    //opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForTableDto>()
                //trouver l'age a partir de la date de naissance
                .ForMember(dest => dest.Age, opt =>
                {
                    //opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });


            CreateMap<User, UserForDetail>()
                //trouver l'age a partir de la date de naissance
                .ForMember(dest => dest.Age, opt =>
                {
                    //opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                })
                .ForMember(d => d.BankAgencies, o => o.Ignore())
                .ForMember(d => d.Token, o => o.Ignore())
            .ReverseMap()
                .ForMember(d => d.IdUserPreference, o => o.MapFrom(s=>s.UserPreference.Id))
                .ForMember(d => d.IdGMapAddress, o => o.MapFrom(s => s.GMapAddress.Id))
                //.ForMember(d => d.PasswordHash, o => o.Ignore())
                //.ForMember(d => d.PasswordSalt, o => o.Ignore())
                .ForMember(d => d.GMapAddress, o => o.Ignore())
                .ForMember(d => d.UserPreference, o => o.Ignore());
                //.ForMember(d => d.UserAccounts, o => o.Ignore());

            CreateMap<UserForDetail, UserForLogged>();

            CreateMap<UserForLogged, User>()
                .ReverseMap();

            CreateMap<User, UserForTechnicalField>();


            CreateMap<UserForAvatarCreationDto, User>();
            //CreateMap<UserForLabelDto, User>();
            CreateMap<User, UserForLabelDto>()
                .ReverseMap();
            CreateMap<UserForGroupDto, User>()
                .ReverseMap();

            //CreateMap<User, UserForConnection>()
            //    .ForMember(d => d.Token, o => o.Ignore());

            CreateMap<UserShortcut, UserShortcutDto>();
            CreateMap<UserShortcutDto, UserShortcut>();
            
            CreateMap<Account, AccountForLabelDto>();
            CreateMap<Account, AccountForTable>()
                .ForMember(d => d.LinkedUsers, o => o.Ignore())
                .ForMember(d => d.EnumActivationCode, o => o.Ignore());
            //.ForMember(d => d.LinkedUsers, o => o.MapFrom(s => s.UserAccounts));


            CreateMap<Account, AccountForDetail>()
                .ForMember(d => d.BankAgency, o => o.MapFrom(s => s.BankAgency))
                .ForMember(d => d.BankSubFamily, o => o.MapFrom(s => s.BankAgency.BankSubFamily))
                .ForMember(d => d.BankFamily, o => o.MapFrom(s => s.BankAgency.BankSubFamily.BankFamily))
                .ForMember(d => d.LinkedUsers, o => o.Ignore())
            .ReverseMap()
                .ForMember(d => d.IdAccountType, o => o.MapFrom(s => s.AccountType.Id))
                .ForMember(d => d.IdBankAgency, o => o.MapFrom(s => s.BankAgency.Id))
                .ForMember(d => d.AccountType, o => o.Ignore())
                .ForMember(d => d.BankAgency, o => o.Ignore());

            CreateMap<Account, AccountForList>()
                .ForMember(d => d.BankAgency, o => o.MapFrom(s => s.BankAgency))
                .ForMember(d => d.BankSubFamily, o => o.MapFrom(s => s.BankAgency.BankSubFamily))
                .ForMember(d => d.BankFamily, o => o.MapFrom(s => s.BankAgency.BankSubFamily.BankFamily))
                .ForMember(d => d.LinkedUsers, o => o.Ignore())
            .ReverseMap()
                .ForMember(d => d.IdAccountType, o => o.MapFrom(s => s.AccountType.Id))
                .ForMember(d => d.IdBankAgency, o => o.MapFrom(s => s.BankAgency.Id))
                .ForMember(d => d.AccountType, o => o.Ignore())
                .ForMember(d => d.BankAgency, o => o.Ignore());

            CreateMap<Account, Select>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Number + " - " + s.Label));

            CreateMap<AccountForList, Select>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Number + " - " + s.Label));

            CreateMap<AccountType, Select>();

            //Mapping vers USER pour Select
            CreateMap<UserAccount, Select>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.IdUser))
                .ForMember(d => d.Label, o => o.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

            CreateMap<BankFamily, Select>();

            CreateMap<BankFamily, SelectCode>();

            CreateMap<BankFamily, SelectCodeUrl>()
                .ForMember(d => d.Url, o => o.MapFrom(s => $"\\assets\\{s.Asset.Path}\\{s.Asset.Label}.{s.Asset.Extension}"));
            
            CreateMap<BankSubFamily, Select>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Label));

            CreateMap<BankFamilyForList, SelectCodeUrl>()
                .ReverseMap()
                //.ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                //.ForMember(d => d.Label, o => o.MapFrom(s => s.Label))
                .ForMember(d => d.BankSubFamily, o => o.Ignore());

            CreateMap<BankSubFamily, SelectCodeUrl>();

            CreateMap < BankSubFamilyForList, BankSubFamily>()
                .ReverseMap()
                .ForMember(d => d.BankAgency, o => o.Ignore());

            CreateMap<BankAgency, Select>();

            CreateMap<BankAgency, SelectGMapAddress>();
                //.ForMember(d => d.GMapAddress, o => o.MapFrom(s => s.))

            CreateMap<BankSubFamily, BankSubFamilyForDetail>();

            CreateMap<BankAgency, BankAgencyDto>()
                .ForMember(d => d.BankFamily, o => o.MapFrom(s => s.BankSubFamily.BankFamily))
                .ForMember(d => d.BankSubFamily, o => o.MapFrom(s => s.BankSubFamily));
            CreateMap<BankAgency, BankAgencyForDetail>()
            .ReverseMap()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForPath(d => d.IdBankSubFamily, o => o.MapFrom(s => s.BankSubFamily.Id));
                //.ForPath(d => d., o => o.MapFrom(s => s.BankSubFamily.BankFamily.Id))
                //.ForAllOtherMembers(o => o.Ignore());

            CreateMap<BankAgency, BankAgencyWithAccountsDto>()
                .ForMember(d => d.BankFamily, o => o.MapFrom(s => s.BankSubFamily.BankFamily));

            CreateMap<BankAgency, BankAgencyForList>()
                .ForMember(d => d.AccountList, o => o.Ignore());


            CreateMap<StateAsif, Select>()
                .ReverseMap();

            CreateMap<BankAgency, BankAgencyForListDto>();

            CreateMap<AccountStatementImportFile, AsifForTable>();

            CreateMap<AccountStatement, AsForTable>()
                .ForMember(d => d.OperationTypeFamily, o => o.MapFrom(s => s.OperationType.OperationTypeFamily))
                .ForMember(d => d.BankAgency, o => o.MapFrom(s => s.Account.BankAgency));

            CreateMap<AccountStatement, AsForDetail>()
                .ForMember(d => d.Asi, o => o.MapFrom(s => s.AccountStatementImport));
                //.ForMember(d => d.Asset, opt => opt.MapFrom(source => source.OperationTypeFamily.Asset));
                //.ForMember(d => d.Operation, o => o.MapFrom(s => s.))
                //.ForMember(d => d.OperationMethod, o => o.Ignore())
                //.ForMember(d => d.OperationType, o => o.Ignore())
                //.ForMember(d => d.OperationTypeFamily, o => o.Ignore());

            CreateMap<Movement, Select>();
            CreateMap<SoldeDto, Solde>();

            CreateMap<OperationMethod, Select>();
            CreateMap<Operation, Select>();
            CreateMap<OperationTypeFamily, Select>();
            CreateMap<OperationPlace, SelectCode>();
            
            CreateMap<Movement, Select>();
            
            CreateMap<OperationTypeFamily, OtfForTableDto>()
            .ReverseMap()
                .ForMember(d => d.Movement, o => o.Ignore())
                .ForMember(d => d.Asset, o => o.Ignore())
                .ForMember(d => d.IdMovement, o => o.MapFrom(s => s.Movement.Id))
                .ForMember(d => d.IdUserGroup, o => o.MapFrom(s => s.User.IdUserGroup))
                .ForMember(d => d.IdAsset, o => o.MapFrom(s => s.Asset.Id));

            CreateMap<OperationTypeFamily, OtfForDetail>()
            .ReverseMap()
                .ForMember(d => d.Movement, o => o.Ignore())
                .ForMember(d => d.Asset, o => o.Ignore())
                .ForMember(d => d.IdMovement, o => o.MapFrom(s => s.Movement.Id))
                .ForMember(d => d.IdUserGroup, o => o.MapFrom(s => s.User.IdUserGroup))
                .ForMember(d => d.IdAsset, o => o.MapFrom(s => s.Asset.Id));

            CreateMap<OperationTypeFamily, SelectCode>()
                .ForMember(d => d.Code, o => o.MapFrom(s => $"\\assets\\{s.Asset.Path}\\[theme]\\{s.Asset.Label}.{s.Asset.Extension}"));

            CreateMap<Asset, SelectCode>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Label))
                .ForMember(d => d.Code, o => o.MapFrom(s => $"\\assets\\{s.Path}\\[theme]\\{s.Label}.{s.Extension}"))

            .ReverseMap()
                .ForMember(d => d.Extension, o => o.Ignore())
                .ForMember(d => d.IdFamily, o => o.Ignore())
                .ForMember(d => d.Label, o => o.Ignore())
                .ForMember(d => d.Path, o => o.Ignore());

            CreateMap<OperationType, OtForTableDto>()
            .ReverseMap()
                .ForMember(d => d.IdOperationTypeFamily, o => o.MapFrom(s => s.OperationTypeFamily.Id))
                .ForMember(d => d.OperationTypeFamily, o => o.Ignore());
            CreateMap<OperationType, Select>()
                .ReverseMap();


            CreateMap<OperationType, OtForDetail>()
            .ReverseMap()
               .ForMember(d => d.OperationTypeFamily, o => o.Ignore())
               .ForMember(d => d.IdOperationTypeFamily, o => o.MapFrom(s => s.OperationTypeFamily.Id))
               .ForMember(d => d.IdUserGroup, o => o.MapFrom(s => s.User.IdUserGroup));

            CreateMap<Operation, OperationForTableDto>()
            .ReverseMap()
                .ForMember(d => d.OperationType, o => o.Ignore())
                .ForMember(d => d.OperationMethod, o => o.Ignore())
                .ForMember(d => d.IdOperationType, o => o.MapFrom(s => s.OperationType.Id))
                .ForMember(d => d.IdOperationMethod, o => o.MapFrom(s => s.OperationMethod.Id))
                .ForMember(d => d.IdUserGroup, o => o.MapFrom(s => s.User.IdUserGroup));

            CreateMap<Operation, OperationForDetail>()
            .ReverseMap()
                .ForMember(d => d.OperationType, o => o.Ignore())
                .ForMember(d => d.OperationMethod, o => o.Ignore())
                .ForMember(d => d.IdOperationType, o => o.MapFrom(s => s.OperationType.Id))
                .ForMember(d => d.IdOperationMethod, o => o.MapFrom(s => s.OperationMethod.Id))
                .ForMember(d => d.IdUserGroup, o => o.MapFrom(s => s.User.IdUserGroup));

            CreateMap<OperationDetail, OperationDetailDto>()
            .ReverseMap()
                .ForMember(d => d.IdGMapAddress, o => o.MapFrom(s => s.GMapAddress.Id))
                .ForMember(d => d.GMapAddress, o => o.Ignore())
                .ForMember(d => d.IdOperationPlace, o => o.MapFrom(s => s.OperationPlace.Id))
                .ForMember(d => d.OperationPlace, o => o.Ignore())
                .ForMember(d => d.IdOperation, o => o.MapFrom(s => s.Operation.Id))
                .ForMember(d => d.Operation, o => o.Ignore());

            CreateMap<AccountStatementImport, AsiForListDto>();
            CreateMap<AccountStatementImport, AsiForTableDto>();
            CreateMap<AccountStatementImport, AsiForDetail>();

            CreateMap<AccountStatementImportFile, AccountStatement>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AccountStatementImportFile, AsifForDetail>()
                //.ForMember(d => d.Asset, o => o.MapFrom(s => s.OperationTypeFamily.Asset))
            .ReverseMap()
                .ForMember(d => d.IdAccount, o => o.MapFrom(s => s.Account.Id))
                .ForMember(d => d.IdImport, o => o.MapFrom(s => s.Asi.Id))
                .ForMember(d => d.IdOperation, o => o.MapFrom(s => s.Operation.Id))
                .ForMember(d => d.IdOperationDetail, o => o.MapFrom(s => s.OperationDetail.Id))
                .ForMember(d => d.IdOperationMethod, o => o.MapFrom(s => s.OperationMethod.Id))
                .ForMember(d => d.IdOperationType, o => o.MapFrom(s => s.OperationType.Id))
                .ForMember(d => d.IdOperationTypeFamily, o => o.MapFrom(s => s.OperationTypeFamily.Id))
                .ForMember(d => d.Account, o => o.Ignore())
                .ForMember(d => d.AccountStatementImport, o => o.Ignore())
                .ForMember(d => d.Movement, o => o.Ignore())
                .ForMember(d => d.OperationMethod, o => o.Ignore())
                .ForMember(d => d.Operation, o => o.Ignore())
                .ForMember(d => d.OperationType, o => o.Ignore())
                .ForMember(d => d.OperationTypeFamily, o => o.Ignore())
                .ForMember(d => d.OperationDetail, o => o.Ignore());

            CreateMap<OperationTransverse, Select>();


            //Plan
            CreateMap<Plan, SelectCode>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Label))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Color));

            CreateMap<Plan, PlanForDetailDto>()
                .ForMember(d => d.Plan, o => o.MapFrom(s => s));

            CreateMap<PlanUser, Select>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.User.Id))
                .ForMember(d => d.Label, o => o.MapFrom(s => s.User.FirstName + " " + s.User.LastName));

            CreateMap<PlanPoste, PlanPosteForTableDto>();

            //CreateMap<PlanPosteReference, Select>()
            //    .ForMember(d => d.Id, o => o.MapFrom(s => s.IdReference))
            //    .ForMember(d => d.Label, o => o.MapFrom(s => s.))


            //CreateMap<PlanPosteForDetail, PlanPoste>()
            //    .ForMember(d => d.ReferenceTable, o => o.Ignore())
            //    .ForMember(d => d.Poste, o => o.Ignore())
            //    .ForMember(d => d.Plan, o => o.Ignore());

            CreateMap<PlanPoste, PlanPosteForDetail>()
                .ForMember(d => d.PlanPosteUser, o => o.Ignore())
                .ForMember(d => d.PlanPosteReference, o => o.Ignore())
                .ForMember(d => d.PlanPosteFrequencies, o => o.Ignore())
                .ForMember(d => d.ReferenceTable, o => o.Ignore())
            .ReverseMap()
                .ForMember(d => d.IdReferenceTable, o => o.MapFrom(s => s.ReferenceTable.Id))
                .ForMember(d => d.IdPoste, o => o.MapFrom(s => s.Poste.Id))
                .ForMember(d => d.ReferenceTable, o => o.Ignore())
                .ForMember(d => d.Poste, o => o.Ignore())
                .ForMember(d => d.Plan, o => o.Ignore());


            CreateMap<PlanPosteFrequency, PlanPosteFrequencyForDetailDto>();
            //CreateMap<AccountStatementPlan, SelectCode>()
            //    .ForMember(d => d.Id, o => o.MapFrom(s => s.IdPlan))
            //    .ForMember(d => d.Label, o => o.MapFrom(s => s.Plan.Label))
            //    .ForMember(d => d.Code, o => o.MapFrom(s => s.Plan.Color));

            CreateMap<Month, Select>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Label, o => o.MapFrom(s => s.LabelLong));
            

            CreateMap<Poste, SelectCode>()
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Movement.Id));

            CreateMap<ReferenceTable, Select>();

            CreateMap<PlanPosteUser, PlanPosteUserForDetailDto>()
                .ForMember(d => d.User, o => o.MapFrom(s => s.PlanUser.User))
            .ReverseMap()
                .ForMember(d => d.PlanPoste, o => o.Ignore())
                .ForMember(d => d.PlanUser, o => o.Ignore());

            //Filter
            //CreateMap<Pagination, FilterAccountStatement>();

            //GMap
            CreateMap<GMapAddress, GMapAddressDto>()
            .ReverseMap()
                .ForMember(d => d.IdGMapAdministrativeAreaLevel1, o => o.MapFrom(s => s.GMapAdministrativeAreaLevel1.Id))
                .ForMember(d => d.IdGMapAdministrativeAreaLevel2, o => o.MapFrom(s => s.GMapAdministrativeAreaLevel2.Id))
                .ForMember(d => d.IdGMapCountry, o => o.MapFrom(s => s.GMapCountry.Id))
                .ForMember(d => d.IdGMapLocality, o => o.MapFrom(s => s.GMapLocality.Id))
                .ForMember(d => d.IdGMapNeighborhood, o => o.MapFrom(s => s.GMapNeighborhood.Id))
                .ForMember(d => d.IdGMapPostalCode, o => o.MapFrom(s => s.GMapPostalCode.Id))
                .ForMember(d => d.IdGMapRoute, o => o.MapFrom(s => s.GMapRoute.Id))
                .ForMember(d => d.IdGMapStreetNumber, o => o.MapFrom(s => s.GMapStreetNumber.Id))
                .ForMember(d => d.IdGMapSublocalityLevel1, o => o.MapFrom(s => s.GMapSublocalityLevel1.Id))
                .ForMember(d => d.IdGMapSublocalityLevel2, o => o.MapFrom(s => s.GMapSublocalityLevel2.Id));
            CreateMap<GMapAdministrativeAreaLevel1, Select>();
            CreateMap<GMapAdministrativeAreaLevel2, Select>();
            CreateMap<GMapCountry, Select>();
            CreateMap<GMapLocality, Select>();
            CreateMap<GMapNeighborhood, Select>();
            CreateMap<GMapPostalCode, Select>();
            CreateMap<GMapRoute, Select>();
            CreateMap<GMapStreetNumber, Select>();
            CreateMap<GMapSublocalityLevel1, Select>();
            CreateMap<GMapSublocalityLevel2, Select>();
            CreateMap<GMapType, GMapTypeDto>()
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Keyword))
                .ForMember(d => d.Label, o => o.Ignore())
            .ReverseMap()
                .ForMember(d => d.Keyword, o => o.MapFrom(s => s.Code));

            //CreateMap<GMapAddressDto, GMapAddress>()
            //    .ForMember(d => d.IdGMapAdministrativeAreaLevel1, o => o.MapFrom(s => s.GMapAdministrativeAreaLevel1.Id))
            //    .ForMember(d => d.IdGMapAdministrativeAreaLevel2, o => o.MapFrom(s => s.GMapAdministrativeAreaLevel2.Id))
            //    .ForMember(d => d.IdGMapCountry, o => o.MapFrom(s => s.GMapCountry.Id))
            //    .ForMember(d => d.IdGMapLocality, o => o.MapFrom(s => s.GMapLocality.Id))
            //    .ForMember(d => d.IdGMapNeighborhood, o => o.MapFrom(s => s.GMapNeighborhood.Id))
            //    .ForMember(d => d.IdGMapPostalCode, o => o.MapFrom(s => s.GMapPostalCode.Id))
            //    .ForMember(d => d.IdGMapRoute, o => o.MapFrom(s => s.GMapRoute.Id))
            //    .ForMember(d => d.IdGMapStreetNumber, o => o.MapFrom(s => s.GMapStreetNumber.Id))
            //    .ForMember(d => d.IdGMapSublocalityLevel1, o => o.MapFrom(s => s.GMapSublocalityLevel1.Id))
            //    .ForMember(d => d.IdGMapSublocalityLevel2, o => o.MapFrom(s => s.GMapSublocalityLevel2.Id));

            CreateMap<FilterAsTableSelection, FilterPlanNotAsTableSelection>()
                .ReverseMap();
            CreateMap<FilterAsForDetail, FilterAsifForDetail>();
            

            //========================================== MAPPING FILE ============================================================//
            CreateMap<string[], BanquePopulaireFileDto>()
                .ForMember(p => p.Reference, opts => opts.MapFrom(s => s[4]))
                .ForMember(p => p.LabelAs, opts => opts.MapFrom(s => s[3]))
                .ForMember(p => p.AmountOperation, opts => opts.MapFrom(s => s[6]))
                .ForMember(p => p.DateIntegration, opts => opts.MapFrom(s => s[1]))
                .ForMember(p => p.AccountNumber, opts => opts.MapFrom(s => s[0]));

            CreateMap<string[], CreditAgricoleFileDto>()
                .ForMember(p => p.LabelAs, opts => opts.MapFrom(s => s[2]))
                .ForMember(p => p.AmountDebitOperation, opts => opts.MapFrom(s => s[3]))
                .ForMember(p => p.AmountCreditOperation, opts => opts.MapFrom(s => s[4]))
                .ForMember(p => p.DateIntegration, opts => opts.MapFrom(s => s[1]))
                .ForMember(p => p.AccountNumber, opts => opts.MapFrom(s => s[0]));
        }
    }
}
