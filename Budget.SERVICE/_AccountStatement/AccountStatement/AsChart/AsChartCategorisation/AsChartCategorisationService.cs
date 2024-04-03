using AutoMapper;
using Budget.DATA.Repositories;
using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class AsChartCategorisationService : IAsChartCategorisationService
    {
        private readonly IMapper _mapper;
        private readonly IAsChartCategorisationRepository _asChartCategorisationRepository;
        private readonly ReferentialService _referentialService;

        public AsChartCategorisationService(
            IMapper mapper,
            IAsChartCategorisationRepository asChartCategorisationRepository,
            ReferentialService referentialService
            )
        {
            _mapper = mapper;
            _asChartCategorisationRepository = asChartCategorisationRepository;
            _referentialService = referentialService;
        }

        public AsChartCategorisationSelect GetAsChartCategorisationDebit(FilterAsTableSelected filterAsTableSelected)
        {
            DateRange dateRange = DateHelper.GetDateRange(filterAsTableSelected.MonthYear);
            
            AsChartCategorisationSelect asChartCategorisationSelect = new AsChartCategorisationSelect();
            asChartCategorisationSelect.OperationMethod = GetWidgetCardChartPieSelect(filterAsTableSelected.IdAccount, dateRange.DateMin, dateRange.DateMax, EnumTableRef.OperationMethod);
            asChartCategorisationSelect.OperationTypeFamily = GetWidgetCardChartPieSelect(filterAsTableSelected.IdAccount, dateRange.DateMin, dateRange.DateMax, EnumTableRef.OperationTypeFamily);
            asChartCategorisationSelect.OperationType = GetWidgetCardChartPieSelect(filterAsTableSelected.IdAccount, dateRange.DateMin, dateRange.DateMax, EnumTableRef.OperationType);

            return asChartCategorisationSelect;
        }

        private WidgetCardChartPieSelect GetWidgetCardChartPieSelect(int? idAccount, DateTime dateMin,DateTime dateMax, EnumTableRef enumTableRef)
        {
            List<SelectNameValueDto<double>> operations = _asChartCategorisationRepository.GetAsChartCategorisationSelect(idAccount, dateMin, dateMax, enumTableRef);
            double total = operations.Sum(x => x.Value);
            foreach (var operation in operations)
            {
                operation.Value = Math.Round(operation.Value * 100 / total, 2);
            }

            //Chercher catégorie père pour chaque item operation
            List<SelectNameValueDto<double>> fatherOperations = GetFathers(operations, enumTableRef);
            var fatherOperationsGroup = fatherOperations
                .GroupBy(x => new { Id = x.Id, Name = x.Name, Value = x.Value })
                .Select(g=> new SelectNameValueDto<double> { Id = g.Key.Id, Name = g.Key.Name, Value = g.Key.Value } )
                .ToList();

            var list = new List<SelectNameValueGroupDto<double>>();
            
            foreach (var fatherOperationGroup in fatherOperationsGroup)
            {
                var fatherSelect = new SelectNameValueGroupDto<double>
                {
                    Id = fatherOperationGroup.Id,
                    Name = fatherOperationGroup.Name,
                    Selects = new List<SelectNameValueDto<double>>()
                };

                for (int i = 0; i < fatherOperations.Count; i++)
                {
                    if(fatherOperationGroup.Id== fatherOperations[i].Id)
                    {
                        fatherSelect.Selects.Add(operations[i]);
                    }
                        
                }

                list.Add(fatherSelect);
            }

            ComboNameValueMultiple<SelectNameValueGroupDto<double>, double> comboNameValueMultiple = new ComboNameValueMultiple<SelectNameValueGroupDto<double>, double>();
            comboNameValueMultiple.List.AddRange(list);
            comboNameValueMultiple.ListSelected.AddRange(operations.Take(4).ToList());

            WidgetCardChartPieSelect widgetCardChartPieSelect = new WidgetCardChartPieSelect(GetChartTitle(enumTableRef));
            widgetCardChartPieSelect.Data.Ranges = comboNameValueMultiple;


            return widgetCardChartPieSelect;

        }

        private string GetChartTitle(EnumTableRef enumTableRef)
        {
            string title = string.Empty;
            switch (enumTableRef)
            {
                case EnumTableRef.OperationMethod:
                    title = "Méthodes";
                    break;
                case EnumTableRef.OperationTypeFamily:
                    title = "Catégories";
                    break;
                case EnumTableRef.OperationType:
                    title = "Types";
                    break;
            }

            return title;
        }

        private List<SelectNameValueDto<double>> GetFathers(List<SelectNameValueDto<double>> operations, EnumTableRef enumTableRef)
        {
            List<SelectNameValueDto<double>> fathers = new List<SelectNameValueDto<double>>();
            foreach (var operation in operations)
            {
                SelectNameValueDto<double> selectNameValueDto = new SelectNameValueDto<double>();
                switch(enumTableRef)
                {
                    case EnumTableRef.OperationMethod:
                        selectNameValueDto = new SelectNameValueDto<double>
                            {
                                Id=0,
                                Name= "Méthode d'opérations"
                        };
                        break;
                    case EnumTableRef.OperationTypeFamily:
                        selectNameValueDto = new SelectNameValueDto<double>
                        {
                            Id = 0,
                            Name = "Catégorie d'opérations"
                        };
                        break;
                    case EnumTableRef.OperationType:
                        var operationType = _referentialService.OperationTypeService.GetByIdWithOperationTypeFamily(operation.Id);
                        selectNameValueDto = new SelectNameValueDto<double>
                        {
                            Id = operationType.OperationTypeFamily.Id,
                            Name = operationType.OperationTypeFamily.Label
                        };
                        break;
                }

                fathers.Add(selectNameValueDto);
            }

            return fathers;
        }

    }
}
