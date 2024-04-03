using AutoMapper;
using Budget.DATA.Repositories;
using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class AsChartEvolutionService : IAsChartEvolutionService
    {
        private readonly IMapper _mapper;
        private readonly IAsChartEvolutionRepository _accountStatementChartRepository;
        private readonly IUserCustomOtfService _userCustomOtfService;
        private readonly ReferentialService _referentialService;

        public AsChartEvolutionService(
            IMapper mapper,
            IAsChartEvolutionRepository accountStatementChartRepository,
            IUserCustomOtfService userCustomOtfService,
            ReferentialService referentialService
            )
        {
            _mapper = mapper;
            _accountStatementChartRepository = accountStatementChartRepository;
            _userCustomOtfService = userCustomOtfService;
            _referentialService = referentialService;
        }

        public AsChartEvolutionCdb GetAsChartEvolutionBrut(FilterAsTableSelected filterAsTableSelected)
        {
            return GetAsChartEvolutionCdb(filterAsTableSelected, "Brut");
        }

        public AsChartEvolutionCdb GetAsChartEvolutionNoIntTransfer(FilterAsTableSelected filterAsTableSelected)
        {
            return GetAsChartEvolutionCdb(filterAsTableSelected, "NoIntTransfer");
        }

        private AsChartEvolutionCdb GetAsChartEvolutionCdb(FilterAsTableSelected filterAsTableSelected, string evolutionType)
        {
            List<AsEvolutionCdbDto> asEvolutionCdbDtos = GetAsEvolutionDto(filterAsTableSelected, evolutionType);

            AsChartEvolutionCdb asChartEvolutionCdb = new AsChartEvolutionCdb();
            asChartEvolutionCdb.Debit = GetWidgetCardChartBar(asEvolutionCdbDtos
                .Select(x => new BaseChartData { Id = x.Id, Month = x.Month, Year = x.Year, Amount = x.Debit })
                .ToList(), EnumAmountState.Debit.ToString());

            asChartEvolutionCdb.Credit = GetWidgetCardChartBar(asEvolutionCdbDtos
                .Select(x => new BaseChartData { Id = x.Id, Month = x.Month, Year = x.Year, Amount = x.Credit })
                .ToList(), EnumAmountState.Credit.ToString());

            asChartEvolutionCdb.Balance = GetWidgetCardChartBar(asEvolutionCdbDtos
                .Select(x => new BaseChartData { Id = x.Id, Month = x.Month, Year = x.Year, Amount = x.Balance })
                .ToList(), EnumAmountState.Balance.ToString());

            return asChartEvolutionCdb;
        }
        private List<AsEvolutionCdbDto> GetAsEvolutionDto(FilterAsTableSelected filterAsTableSelected,string evolutionType)
        {
            var date = Convert.ToDateTime($"01/{filterAsTableSelected.MonthYear.Month.Id}/{filterAsTableSelected.MonthYear.Year}");
            var dateMax = DateHelper.GetLastDayOfMonth(date);
            var dateMin = DateHelper.GetFirstDayOfMonth(dateMax.AddMonths(-12));

            switch(evolutionType)
            {
                case "Brut":
                    return _accountStatementChartRepository.GetAsChartEvolutionBrut(filterAsTableSelected.IdAccount, dateMin, dateMax);
                case "NoIntTransfer":
                    return _accountStatementChartRepository.GetAsChartEvolutionNoIntTransfer(filterAsTableSelected.IdAccount, filterAsTableSelected.User.IdUserGroup, dateMin, dateMax); ;
                default:
                    throw new Exception("No matching Evolution type ");
            }
        }

        private WidgetCardChartBar GetWidgetCardChartBar(List<BaseChartData> baseChartDatas, string chartLabel)
        {
            WidgetCardChartBar widgetCardChartBar = new WidgetCardChartBar();

            List<double> datas = new List<double>();
            List<string> colors = new List<string>();
            foreach (var baseChartData in baseChartDatas)
            {
                //widgetCardChartBar.Chart.Data.Labels.Add(new Select() {
                //    Id = Int32.Parse(baseChartData.Month),
                //    Label = $"{DateHelper.GetLabelMonthShort(baseChartData.Month)} {baseChartData.Year}"
                //    });

                widgetCardChartBar.Chart.Data.Labels.Add($"{DateHelper.GetLabelMonthShort(baseChartData.Month)} {baseChartData.Year}");
  
                //var amount = enumAmountState == EnumAmountState.Debit 
                //    ? AsEvolution.Debit : enumAmountState == EnumAmountState.Credit
                //    ? AsEvolution.Credit : enumAmountState == EnumAmountState.Balance
                //    ? AsEvolution.Balance : 0;

                datas.Add(baseChartData.Amount);
                colors.Add(baseChartData.Amount >= 0 
                    ? ChartHelper.GetChartColor(EnumChartBarColor.Green.ToString()) 
                    : ChartHelper.GetChartColor(EnumChartBarColor.Red.ToString()));
            }

            widgetCardChartBar.Chart.Data.Datasets.Add(new Dataset()
            {
                Label = chartLabel,
                Data = datas,
                BackgroundColor = colors,
                HoverBackgroundColor = colors
            });
            //widgetCardChartBar.Chart.Colors.Add(new Color
            //{
            //    BackgroundColor = colors
            //});

            widgetCardChartBar.Title.Label = chartLabel;
            //prendre que les datas dont nombre<>0 (pas de données si total =0 pour un mois donnée ou alors le compe ne vit pas) 
            var datasNoZero = datas.Where(x => x != 0).ToList();
            widgetCardChartBar.Title.AverageAmount = datas.Count>0 && datasNoZero.Sum()!=0 ? Math.Round(datasNoZero.Average(),2) : 0;
            var lastData = datas.Count > 0 ? datas[datas.Count - 1] : 0; //widgetCardChartBar.Chart.DataSets[0].Data[widgetCardChartBar.Chart.DataSets[0].Data.Count - 1];
            widgetCardChartBar.Title.RatioAmount = datas.Count > 0 ? Math.Round((lastData- widgetCardChartBar.Title.AverageAmount) * 100 / Math.Abs(widgetCardChartBar.Title.AverageAmount),2) : 0;
            widgetCardChartBar.Title.RatioLabel = datas.Count > 0 ? $" pour {widgetCardChartBar.Chart.Data.Labels.Last() }" : "données inexistantes";

            YAxe yAxe = new YAxe();
            yAxe.Ticks.Min = datas.Count > 0 ? widgetCardChartBar.Chart.Data.Datasets[0].Data.Min() : 0;
            yAxe.Ticks.Max = datas.Count > 0 ? widgetCardChartBar.Chart.Data.Datasets[0].Data.Max() : 0;
            //widgetCardChartBar.Chart.Options.Scales.YAxes.Add(yAxe);

            widgetCardChartBar.IsLoaded = true;

            return widgetCardChartBar;
        }

        public List<WidgetCardChartBar> GetAsChartEvolutionCustomOtf(FilterAsTableSelected filterAsTableSelected)
        {
            //Rechercher les operationTypeFamily favori pour l'utilisateur
            List<Select> otfs = _userCustomOtfService.GetOperationTypeFamilySelect(filterAsTableSelected.User.Id, filterAsTableSelected.IdAccount);
            List<WidgetCardChartBar> widgetCardChartBars = new List<WidgetCardChartBar>();
            foreach (var otf in otfs)
            {
                var baseChartDatas = GetAsEvolutionCustomOtf(filterAsTableSelected, otf.Id);
                WidgetCardChartBar widgetCardChartBar = GetWidgetCardChartBar(baseChartDatas, otf.Label);
                widgetCardChartBars.Add(widgetCardChartBar);
            }

            return widgetCardChartBars;
        }

        private List<BaseChartData> GetAsEvolutionCustomOtf(FilterAsTableSelected filterAsTableSelected, int idOperationTypeFamily)
        {
            var date = Convert.ToDateTime($"01/{filterAsTableSelected.MonthYear.Month.Id}/{filterAsTableSelected.MonthYear.Year}");
            var dateMax = DateHelper.GetLastDayOfMonth(date);
            var dateMin = DateHelper.GetFirstDayOfMonth(dateMax.AddMonths(-12));

            return _accountStatementChartRepository.GetAsChartEvolutionCustomOtf(filterAsTableSelected.IdAccount, idOperationTypeFamily, dateMin, dateMax);

        }

        public AsChartEvolutionCustomOtfFilter GetAsChartEvolutionCustomOtfFilter(FilterAsTableSelected filter)
        {
            var operationTypeFamilies = _referentialService.OperationTypeFamilyService.GetSelectGroup(filter.User.IdUserGroup);
            AsChartEvolutionCustomOtfFilter asChartEvolutionCustomOtfFilter = new AsChartEvolutionCustomOtfFilter {
                Selected = new AsChartEvolutionCustomOtfFilterSelected
                {
                    User = filter.User,
                    IdAccount = filter.IdAccount,
                    MonthYear = filter.MonthYear,
                    OperationTypeFamilies = _userCustomOtfService.GetOperationTypeFamilySelect(filter.User.Id, filter.IdAccount)
                },
                OperationTypeFamilies = operationTypeFamilies,
            };

            return asChartEvolutionCustomOtfFilter;
        }

        public bool UpdateAsChartEvolutionCustomOtfFilter(AsChartEvolutionCustomOtfFilterSelected filter)
        {
            return _userCustomOtfService.Update(filter);
        }




        //public AsChartCategorisation GetAsChartCategorisationDebit(FilterAsTableSelected filterAsTableSelected)
        //{
        //    return GetAsChartEvolutionCdb(filterAsTableSelected, "Brut");
        //}
    }
}
