using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IAsChartEvolutionService
    {
        AsChartEvolutionCdb GetAsChartEvolutionBrut(FilterAsTableSelected filterAsTableSelected);
        AsChartEvolutionCdb GetAsChartEvolutionNoIntTransfer(FilterAsTableSelected filterAsTableSelected);
        List<WidgetCardChartBar> GetAsChartEvolutionCustomOtf(FilterAsTableSelected filterAsTableSelected);
        AsChartEvolutionCustomOtfFilter GetAsChartEvolutionCustomOtfFilter(FilterAsTableSelected filter);
        bool UpdateAsChartEvolutionCustomOtfFilter(AsChartEvolutionCustomOtfFilterSelected filter);
    }
}
