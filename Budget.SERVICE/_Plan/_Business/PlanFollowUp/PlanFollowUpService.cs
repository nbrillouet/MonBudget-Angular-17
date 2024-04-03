using AutoMapper;
using Budget.DATA.Repositories;
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
    public class PlanFollowUpService : IPlanFollowUpService
    {
        private readonly IMapper _mapper;
        private readonly IVPlanGlobalService _vPlanGlobalService;
        private readonly IPlanRepository _planRepository;
        private readonly IPosteRepository _posteRepository;
        private readonly IPlanPosteUserRepository _planPosteUserRepository;
        private readonly IPlanPosteReferenceService _planPosteReferenceService;
        private readonly IAccountStatementService _accountStatementService;
        private readonly IPlanAccountService _planAccountService;

        public PlanFollowUpService(
            IMapper mapper,
            IVPlanGlobalService vPlanGlobalService,
            IPlanRepository planRepository,
            IPosteRepository posteRepository,
            IPlanPosteUserRepository planPosteUserRepository,
            IAccountStatementService accountStatementService,
            IPlanPosteReferenceService planPosteReferenceService,
            IPlanAccountService planAccountService
            )
        {
            _mapper = mapper;
            _vPlanGlobalService = vPlanGlobalService;
            _planRepository = planRepository;
            _posteRepository = posteRepository;
            _planPosteUserRepository = planPosteUserRepository;
            _accountStatementService = accountStatementService;
            _planPosteReferenceService = planPosteReferenceService;
            _planAccountService = planAccountService;

        }

        public PlanForFollowUp Get(FilterPlanFollowUpSelected filter)
        {
            PlanForFollowUp planForFollowUp = new PlanForFollowUp();
            planForFollowUp.Plan = _planRepository.GetById(filter.Plan.Id);

            
            List<VPlanGlobal> vPlanGlobal = _vPlanGlobalService.Get(filter);
            if(vPlanGlobal.Count>0)
            {
                //recherche de tous les postes de la base et affectation au planForFollowUp
                planForFollowUp.Postes = GetPostesForFollowUp(vPlanGlobal, filter.Plan.Id, filter.MonthYear.Month.Id == (int)EnumMonth.BalanceSheetYear); // filter.MonthYear.Month.Id== (int)EnumMonth.BalanceSheetYear);

                //somme pour le plan
                PlanFollowUpAmountStore planFollowUpAmountStore = vPlanGlobal
                    .GroupBy(x => new { x.PreviewAmount, x.IdPlan })
                    .Select(g => new PlanFollowUpAmountStore { Id = g.Key.IdPlan.Value, Label = planForFollowUp.Plan.Label, AmountPreview = g.Key.PreviewAmount.Value, AmountReal = g.Sum(a => a.AmountOperation.Value) })
                    .GroupBy(x => new { x.Id })
                    .Select(g => new PlanFollowUpAmountStore { Id = g.Key.Id, Label = planForFollowUp.Plan.Label, AmountPreview = g.Sum(ap => ap.AmountPreview), AmountReal = g.Sum(a => a.AmountReal) })
                    .First();

                planForFollowUp.AmountPreview = Math.Round(planFollowUpAmountStore.AmountPreview, 2);
                planForFollowUp.AmountReal = Math.Round(planFollowUpAmountStore.AmountReal, 2);
                planForFollowUp.GaugeValue = CalculatePercentage(planFollowUpAmountStore.AmountReal, planFollowUpAmountStore.AmountPreview);
            }

            return planForFollowUp;
        }

        private List<PosteForFollowUp> GetPostesForFollowUp(List<VPlanGlobal> vPlanGlobal,int idPlan, bool isBalanceSheet)
        {
            List<Poste> postes = _posteRepository.GetAllEager();
            List<PosteForFollowUp> postesForFollowUp = new List<PosteForFollowUp>();

            foreach (var poste in postes)
            {
                PosteForFollowUp posteForFollowUp = new PosteForFollowUp();
                posteForFollowUp.Poste = _mapper.Map<SelectCode>(poste);

                var vByPoste = vPlanGlobal
                    .Where(x => x.IdPoste == poste.Id)
                    .Where(x=>x.IdMovement == poste.IdMovement)
                    .ToList();
                //recherche des planPoste et affectation au planFollowUp
                posteForFollowUp.PlanPostes = GetPlanPostesForFollowUp(vByPoste, idPlan, poste.Id);

                if (vByPoste.Count > 0)
                {
                    PlanFollowUpAmountStore planFollowUpAmountStore = GetPlanFollowUpAmountStore(vByPoste, isBalanceSheet);

                    posteForFollowUp.AmountPreview = Math.Round(planFollowUpAmountStore.AmountPreview, 2);
                    posteForFollowUp.AmountReal = Math.Round(planFollowUpAmountStore.AmountReal, 2);
                    posteForFollowUp.GaugeValue = CalculatePercentage(planFollowUpAmountStore.AmountReal, planFollowUpAmountStore.AmountPreview);
                }
                postesForFollowUp.Add(posteForFollowUp);

            }
            return postesForFollowUp;
        }

        private PlanFollowUpAmountStore GetPlanFollowUpAmountStore(List<VPlanGlobal> vByPoste, bool isBalanceSheet)
        {

            var planTrackingAmountStore = GenerateQueryByPoste(vByPoste);

            return planTrackingAmountStore;

        }

        private List<PlanPosteForFollowUp> GetPlanPostesForFollowUp(List<VPlanGlobal> vByPoste, int idPlan,int idPoste)
        {
            List<PlanPosteForFollowUp> PlanPostesForFollowUp = new List<PlanPosteForFollowUp>();

            //somme des PlanPoste group by PlanPoste
            List<PlanFollowUpAmountStore> planFollowUpAmountStoreYears = GenerateQuery(vByPoste, true).ToList();

            
            List<PlanFollowUpAmountStore> planFollowUpAmountStoreMonths = GenerateQuery(vByPoste, false).ToList();

            PlanPostesForFollowUp.AddRange(CalculatePlanPosteFollowUp(vByPoste, planFollowUpAmountStoreYears, true));
            PlanPostesForFollowUp.AddRange(CalculatePlanPosteFollowUp(vByPoste, planFollowUpAmountStoreMonths, false));


            return PlanPostesForFollowUp;
        }

        private IQueryable<PlanFollowUpAmountStore> GenerateQuery(List<VPlanGlobal> vByPoste, bool isForBalanceSheetYear)
        {
            var query = vByPoste.AsQueryable();
            query = isForBalanceSheetYear
                ? query.Where(x => x.Month == (int)EnumMonth.BalanceSheetYear).AsQueryable()
                : query.Where(x => x.Month != (int)EnumMonth.BalanceSheetYear).AsQueryable();

            var query2 = query
                .GroupBy(x => new { x.IdPlanPoste, x.PlanPosteLabel, x.Month, x.PreviewAmount })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.IdPlanPoste.Value, Label = g.Key.PlanPosteLabel, AmountPreview = g.Key.PreviewAmount.Value, AmountReal = g.Sum(a => a.AmountOperation.Value) })
                .GroupBy(x => new { x.Id, x.Label })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.Id, Label = g.Key.Label, AmountPreview = g.Sum(a => a.AmountPreview), AmountReal = g.Sum(a => a.AmountReal) })
                .AsQueryable();

            return query2;
        }

        private PlanFollowUpAmountStore GenerateQueryByPoste(List<VPlanGlobal> vByPoste)
        {
            //calcul par preview annuel
            var queryByAnnualPreview = vByPoste
                .Where(x => x.Month == (int)EnumMonth.BalanceSheetYear)
                .GroupBy(x => new { x.IdPoste, x.IdPlanPoste, x.PreviewAmount })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.IdPoste.Value, Label = g.Key.IdPoste.Value.ToString(), AmountPreview = g.Key.PreviewAmount.Value, AmountReal = g.Sum(a => a.AmountOperation.Value) })
                .GroupBy(x => new { x.Id })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.Id, Label = g.Key.Id.ToString(), AmountPreview = g.Sum(s => s.AmountPreview), AmountReal = g.Sum(a => a.AmountReal) })
                .FirstOrDefault();
            queryByAnnualPreview = queryByAnnualPreview == null
                ? queryByAnnualPreview = new PlanFollowUpAmountStore { Id = vByPoste[0].IdPoste.Value }
                : queryByAnnualPreview;

            //calcul par preview mensuel
            var queryByMonthPreview = vByPoste
                .Where(x => x.Month != (int)EnumMonth.BalanceSheetYear)
                .GroupBy(x => new { x.IdPoste, x.IdPlanPoste, x.Month, x.PreviewAmount })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.IdPoste.Value, Label = g.Key.IdPoste.Value.ToString(), AmountPreview = g.Key.PreviewAmount.Value, AmountReal = g.Sum(a => a.AmountOperation.Value) })
                .GroupBy(x => new { x.Id })
                .Select(g => new PlanFollowUpAmountStore { Id = g.Key.Id, Label = g.Key.Id.ToString(), AmountPreview = g.Sum(ap => ap.AmountPreview), AmountReal = g.Sum(a => a.AmountReal) })
                .FirstOrDefault();
            queryByMonthPreview = queryByMonthPreview == null
                ? queryByMonthPreview = new PlanFollowUpAmountStore { Id = vByPoste[0].IdPoste.Value }
                : queryByMonthPreview;

            //sommage
            queryByAnnualPreview.AmountPreview = queryByAnnualPreview.AmountPreview + queryByMonthPreview.AmountPreview;
            queryByAnnualPreview.AmountReal = queryByAnnualPreview.AmountReal + queryByMonthPreview.AmountReal;

            return queryByAnnualPreview;

        }

        private List<PlanPosteForFollowUp> CalculatePlanPosteFollowUp(List<VPlanGlobal> vByPoste, List<PlanFollowUpAmountStore> planTrackingAmountStores,bool isAnnualPreview)
        {
            List<PlanPosteForFollowUp> PlanPosteForFollowUpList = new List<PlanPosteForFollowUp>();
            foreach (var planTrackingAmountStore in planTrackingAmountStores)
            {
                PlanPosteForFollowUp planPosteForFollowUp = new PlanPosteForFollowUp
                {
                    IdPlanPoste = planTrackingAmountStore.Id,
                    Label = planTrackingAmountStore.Label,
                    AmountReal = Math.Round(planTrackingAmountStore.AmountReal, 2),
                    AmountPreview = Math.Round(planTrackingAmountStore.AmountPreview, 2),
                    IsAnnualPreview = isAnnualPreview,
                    GaugeValue = CalculatePercentage(planTrackingAmountStore.AmountReal, planTrackingAmountStore.AmountPreview)
                };
                var vByPlanPoste = vByPoste.Where(x => x.IdPlanPoste == planTrackingAmountStore.Id).ToList();
                planPosteForFollowUp.PlanPosteUsers = GetPlanPosteUsersForFollowUp(planPosteForFollowUp, planTrackingAmountStore.Id);

                PlanPosteForFollowUpList.Add(planPosteForFollowUp);
            }

            return PlanPosteForFollowUpList;
        }

        private List<PlanPosteUserForFollowUp> GetPlanPosteUsersForFollowUp(PlanPosteForFollowUp planPosteForFollowUp, int idPlanPoste)
        {
            List<PlanPosteUser> planPosteUsers = _planPosteUserRepository.GetByIdPlanPoste(idPlanPoste);
            List<PlanPosteUserForFollowUp> planPosteUsersForFollowUp = new List<PlanPosteUserForFollowUp>();
            foreach ( var planPosteUser in planPosteUsers)
            {
                if (planPosteUser.PercentagePart != 0)
                {
                    PlanPosteUserForFollowUp planPosteUserForFollowUp = new PlanPosteUserForFollowUp
                    {
                        FirstName = planPosteUser.PlanUser.User.FirstName,
                        PercentagePart = planPosteUser.PercentagePart,
                        AmountPreview = Math.Round(planPosteUser.PercentagePart * planPosteForFollowUp.AmountPreview / 100, 2),
                        AmountReal = Math.Round(planPosteUser.PercentagePart * planPosteForFollowUp.AmountReal / 100, 2)
                    };
                    planPosteUserForFollowUp.GaugeValue = CalculatePercentage(planPosteUserForFollowUp.AmountReal, planPosteUserForFollowUp.AmountPreview);

                    planPosteUsersForFollowUp.Add(planPosteUserForFollowUp);
                }
            }

            return planPosteUsersForFollowUp;
        }

        private double CalculatePercentage(double AmountBase,double Amount)
        {
            return AmountBase != 0
                ? Math.Round(AmountBase * 100 / Amount, 2)
                : 0;

        }

        public List<AsForTable> GetPlanFollowUpAmountReal(PlanFollowUpAmountRealFilter filter)
        {
            List<PlanPosteReference> planPosteReferences = _planPosteReferenceService.GetByIdPlanPoste(filter.IdPlanPoste.Value);
            List<PlanAccount> planAccounts = _planAccountService.GetByIdPlan(filter.IdPlan.Value);
            Poste poste = _posteRepository.GetById(filter.IdPoste.Value);
            
            List<AsForTable> asForTable = _accountStatementService.GetByPlanPosteReferences(poste, planAccounts, planPosteReferences, filter.MonthYear);

            return asForTable;
        }
    }
}
