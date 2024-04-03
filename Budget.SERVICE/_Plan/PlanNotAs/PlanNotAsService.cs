using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class PlanNotAsService: IPlanNotAsService
    {
        private readonly IMapper _mapper;
        private readonly IPlanAccountService _planAccountService;
        private readonly IPlanService _planService;
        private readonly IVPlanGlobalService _vPlanGlobalService;
        private readonly ReferentialService _referentialService;
        private readonly IAccountStatementService _accountStatementService;

        public PlanNotAsService(
            IMapper mapper,
            IPlanAccountService planAccountService,
            ReferentialService referentialService,
            IPlanService planService,
            IVPlanGlobalService vPlanGlobalService,
            IAccountStatementService accountStatementService
            )
        {
            _mapper = mapper;
            _planAccountService = planAccountService;
            _referentialService = referentialService;
            _planService = planService;
            _accountStatementService = accountStatementService;
            _vPlanGlobalService = vPlanGlobalService;
        }

        //Recherche des account statement non pris en compte dans le plan indiqué en parametre
        public PagedList<AsForTable> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter)
        {
            filter.FilterFixedPlanNotAsTableSelected = GetFilterFixedPlanNotAsTableSelected(filter.FilterFixedPlanNotAsTableSelected);

            return _accountStatementService.GetPlanNotAsTable(filter);
        }

        public int GetPlanNotAsCount(int idPlan, int idUserGroup)
        {
            FilterFixedPlanNotAsTableSelected filterFixed = new FilterFixedPlanNotAsTableSelected
            {
                IdPlan = idPlan,
                IdUserGroup = idUserGroup
            };
            filterFixed = GetFilterFixedPlanNotAsTableSelected(filterFixed);

            return _accountStatementService.GetPlanNotAsCount(filterFixed);
        }

        ////Recherche des account statement non pris en compte dans le plan indiqué en parametre
        private FilterFixedPlanNotAsTableSelected GetFilterFixedPlanNotAsTableSelected (FilterFixedPlanNotAsTableSelected filterFixed)
        {
            //Recherche du plan
            var plan = _planService.GetById(filterFixed.IdPlan);
            //Recherche des account statement pris en compte dans le plan
            var asInPlan = _vPlanGlobalService.GetByIdPlan(filterFixed.IdPlan);
            //Recherche des Accounts utilisés dans le plan
            var planAccounts = _planAccountService.GetByIdPlan(filterFixed.IdPlan);
            //Recherche du virement interne pour le user group (pas de prise en compte dess virements internes)
            var otfViri = _referentialService.OperationTypeFamilyService.GetByCodeUserGroupForSelect(EnumOtf.VIRI, filterFixed.IdUserGroup);

            filterFixed.Year = plan.Year;
            filterFixed.IdInternalTransfert = otfViri.Id;
            filterFixed.AsInPlan = asInPlan.Select(x => x.IdAccountStatement.Value).ToList();
            filterFixed.Accounts = planAccounts.Select(x => x.IdAccount).ToList();

            return filterFixed;
        }
        ////Recherche des account statement non pris en compte dans le plan indiqué en parametre
        //public List<AsForTableDto> GetAsNotInPlan(int idPlan, int idUserGroup)
        //{
        //    //Recherche du plan
        //    var plan = _planService.GetById(idPlan);
        //    //Recherche des account statement pris en compte dans le plan
        //    var asInPlan = _accountStatementPlanRepository.GetByIdPlan(idPlan);
        //    //Recherche des Accounts utilisés dans le plan
        //    var planAccounts = _planAccountService.GetByIdPlan(idPlan);
        //    //Recherche du virement interne pour le user group (pas de prise en compte dess virements internes)
        //    var otfViri = _referentialService.OperationTypeFamilyService.GetByCodeUserGroupForSelect(EnumCodeOtf.VIRI, idUserGroup);

        //    FilterAsNotInPlan filterAsNotInPlan = new FilterAsNotInPlan
        //    {
        //        Year = plan.Year,
        //        IdInternalTransfert = otfViri.Id,
        //        AsInPlan = asInPlan.Select(x => x.IdAccountStatement).ToList(),
        //        Accounts = planAccounts.Select(x => x.IdAccount).ToList()
        //    };

        //    var accountStatements = _accountStatementPlanRepository.GetAsNotInPlan(filterAsNotInPlan);
        //    return _mapper.Map<List<AsForTableDto>>(accountStatements);
        //    //return null;
        //}

    }
}
