using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IFilterDetailService
    {
        FilterOperationForDetail GetFilterForOperation(OperationForDetail operationForDetail);
        FilterOtForDetail GetFilterForOt(OtForDetail otForDetail);
        FilterOtfForDetail GetFilterForOtf(OtfForDetail otfForDetail);
        FilterAsForDetail GetFilterForAs(AsForDetail asForDetail);
        FilterAsifForDetail GetFilterForAsif(AsifForDetail asifForDetail);
        FilterAccountForDetail GetFilterForAccount(AccountForDetail accountForDetail);
        FilterPlanPosteForDetail GetFilterForPlanPoste(int idUserGroup, PlanPosteForDetail planPosteForDetail);
    }
}
