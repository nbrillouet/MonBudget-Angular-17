using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;
//FilterAsi
namespace Budget.SERVICE
{
    public interface IFilterTableService
    {
        FilterAsTableSelection GetFilterAsTableSelection(FilterAsTableSelected filter);
        FilterAsifTableSelection GetFilterAsifTable(FilterAsifTableSelected filter);
        FilterUserTableSelection GetFilterUserTable(FilterUserTableSelected filter);
        FilterAccountTableSelection GetFilterAccountTable(FilterAccountTableSelected filter);
        FilterOtfTableSelection GetFilterOtfTable(FilterOtfTableSelected filter);
        FilterOtTableSelection GetFilterOtTable(FilterOtTableSelected filter);
        FilterOperationTableSelection GetFilterOperationTable(FilterOperationTableSelected filter);
        FilterPlanTableSelection GetFilterPlanTable(FilterPlanTableSelected filter);
        FilterPlanPosteTableSelection GetFilterPlanPosteTable(FilterPlanPosteTableSelected filter);
        FilterPlanNotAsTableSelection GetFilterPlanNotAsTable(FilterPlanNotAsTableSelected filter);
        FilterPlanFollowUpSelection GetFilterPlanDashboard(FilterPlanFollowUpSelected filter);

    }

}
