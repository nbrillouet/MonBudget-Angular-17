using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanNotAsService
    {
        PagedList<AsForTable> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter);
        int GetPlanNotAsCount(int idPlan, int idUserGroup);

    }

}
