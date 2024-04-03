using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IAsChartCategorisationService 
    {
        AsChartCategorisationSelect GetAsChartCategorisationDebit(FilterAsTableSelected filterAsTableSelected);
        
    }
}
