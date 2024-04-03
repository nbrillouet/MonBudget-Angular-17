using AutoMapper;
using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class FilterTableService : IFilterTableService
    {
        private readonly IMapper _mapper;
        private readonly IAccountStatementImportService _accountStatementImportService;
        private readonly IAccountStatementImportFileService _accountStatementImportFileService;
        private readonly IAccountStatementService _accountStatementService;
        private readonly IPlanService _planService;
        private readonly IPlanUserService _planUserService;
        private readonly ReferentialService _referentialService;


        public FilterTableService(
            IMapper mapper,
            IAccountStatementImportService accountStatementImportService,
            IAccountStatementImportFileService accountStatementImportFileService,
            IAccountStatementService accountStatementService,
            ReferentialService referentialService,
            IPlanService planService,
            IPlanUserService planUserService

            )
        {
            _mapper = mapper;
            _accountStatementImportService = accountStatementImportService;
            _accountStatementImportFileService = accountStatementImportFileService;
            _accountStatementService = accountStatementService;
            _referentialService = referentialService;
            _planService = planService;
            _planUserService = planUserService;

        }

        public FilterAsTableSelection GetFilterAsTableSelection(FilterAsTableSelected filter)
        {
            FilterAsTableSelection filterAsTable = new FilterAsTableSelection();

            filterAsTable.OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty);
            filterAsTable.OperationTypeFamily = _referentialService.OperationTypeFamilyService.GetSelectGroup(filter.User.IdUserGroup);
            filterAsTable.OperationType = _referentialService.OperationTypeService.GetSelectGroup(filter.User.IdUserGroup, filter.OperationTypeFamily);
            filterAsTable.Operation = _referentialService.OperationService.GetSelectList(filter.User.IdUserGroup, filter.OperationMethod, filter.OperationTypeFamily, filter.OperationType);
            filterAsTable.Month = DateHelper.GetMonthList();
            if(filter.IdAccount.HasValue)
            {
                filterAsTable.Year = _accountStatementService.GetYearAvailable(filter.User.Id, filter.IdAccount.Value);
            }

            return filterAsTable;
        }

        //public FilterAsiTableSelection GetFilterAsiTable(FilterAsiTableSelected filter)
        //{
        //    FilterAsiTableSelection filterAsiTable = new FilterAsiTableSelection();

        //    var BankAgencies = _accountStatementImportService.GetDistinctBankAgencies(filter.User.Id);
        //    var BankAgenciesDto = _mapper.Map<List<BankAgencyDto>>(BankAgencies);
        //    filterAsiTable.BankAgencies = BankAgenciesDto;

        //    return filterAsiTable;
        //}
        
        public FilterAsifTableSelection GetFilterAsifTable(FilterAsifTableSelected filter)
        {
            FilterAsifTableSelection filterAsifTable = new FilterAsifTableSelection();

            var accounts = _accountStatementImportFileService.GetAccountSelectListByIdImport(filter.IdImport.Value);
            filterAsifTable.Account = accounts;

            var account = filter.Account == null ? accounts[0] : filter.Account;

            var states = _accountStatementImportFileService.GetAsifStates(filter.IdImport.Value, account.Id);
            filterAsifTable.State = states;

            var operationMethods = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty);
            filterAsifTable.OperationMethod = operationMethods;
            
            var operationTypeFamilies = _referentialService.OperationTypeFamilyService.GetSelectGroup(filter.User.IdUserGroup);
            filterAsifTable.OperationTypeFamily = operationTypeFamilies;
            
            var operationTypes = _referentialService.OperationTypeService.GetSelectGroup(filter.User.IdUserGroup, filter.OperationTypeFamily);
            filterAsifTable.OperationType = operationTypes;
            
            var operations = _referentialService.OperationService.GetSelectList(filter.User.IdUserGroup, filter.OperationMethod, filter.OperationTypeFamily, filter.OperationType);
            filterAsifTable.Operation = operations;

            return filterAsifTable;
        }

        public FilterUserTableSelection GetFilterUserTable(FilterUserTableSelected filter)
        {
            FilterUserTableSelection filterUserTable = new FilterUserTableSelection();

            return filterUserTable;
        }

        public FilterAccountTableSelection GetFilterAccountTable(FilterAccountTableSelected filter)
        {
            
            FilterAccountTableSelection filterAccountTableSelection = new FilterAccountTableSelection();

            var bankFamily = _referentialService.UserAccountService.GetBankFamily(filter.User.Id);
            filterAccountTableSelection.BankFamily = bankFamily;

            return filterAccountTableSelection;
        }

        public FilterOtfTableSelection GetFilterOtfTable(FilterOtfTableSelected filter)
        {
            FilterOtfTableSelection filterOtfTable = new FilterOtfTableSelection();

            var Movements = _referentialService.MovementService.GetSelectList(EnumSelectType.Empty);

            filterOtfTable.Movement = Movements;

            return filterOtfTable;
        }

        public FilterOtTableSelection GetFilterOtTable(FilterOtTableSelected filter)
        {
            FilterOtTableSelection filterOtTable = new FilterOtTableSelection();

            var Otfs = _referentialService.OperationTypeFamilyService.GetSelectList(filter.User.IdUserGroup, EnumSelectType.Empty);

            filterOtTable.OperationTypeFamily = Otfs;

            return filterOtTable;
        }

        public FilterOperationTableSelection GetFilterOperationTable(FilterOperationTableSelected filter)
        {
            FilterOperationTableSelection filterOperationTable = new FilterOperationTableSelection();

            filterOperationTable.OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty);
            filterOperationTable.OperationType = _referentialService.OperationTypeService.GetSelectGroup(filter.User.IdUserGroup);

            return filterOperationTable;
        }

        public FilterPlanTableSelection GetFilterPlanTable(FilterPlanTableSelected filter)
        {
            FilterPlanTableSelection filterPlanTable = new FilterPlanTableSelection();
            filterPlanTable.Year = _planService.GetDistinctYears();
            return filterPlanTable;
        }

        public FilterPlanPosteTableSelection GetFilterPlanPosteTable(FilterPlanPosteTableSelected filter)
        {
            FilterPlanPosteTableSelection filterPlanPosteTable = new FilterPlanPosteTableSelection();

            return filterPlanPosteTable;
        }

        public FilterPlanNotAsTableSelection GetFilterPlanNotAsTable(FilterPlanNotAsTableSelected filter)
        {
            FilterAsTableSelection filterAsTableSelection = GetFilterAsTableSelection(filter);

            return _mapper.Map<FilterPlanNotAsTableSelection>(filterAsTableSelection);
        }

        public FilterPlanFollowUpSelection GetFilterPlanDashboard(FilterPlanFollowUpSelected filter) 
        {
            FilterPlanFollowUpSelection filterPlanFollowUpSelection = new FilterPlanFollowUpSelection();
            var plan = _planUserService.GetPlansByIdUser(filter.User.Id);

            //toutes les années disponibles
            filterPlanFollowUpSelection.Year = plan
                .GroupBy(x => new { x.Year })
                    .Select(g => g.Key.Year)
                    .OrderByDescending(x => x)
                .ToList();
            
            //tous les mois disponibles
            var month = DateHelper.GetMonthList();
            month.Add(new Select { Id = 13, Label = "Tous les mois" });
            filterPlanFollowUpSelection.Month = month;

            //plan sur l'année tete de liste
            var year = filter.MonthYear==null ? filterPlanFollowUpSelection.Year[0] : filter.MonthYear.Year;
            filterPlanFollowUpSelection.Plan = plan
                .Where(x => x.Year == year)
                .ToList();



            return filterPlanFollowUpSelection;
        }
    }

}
