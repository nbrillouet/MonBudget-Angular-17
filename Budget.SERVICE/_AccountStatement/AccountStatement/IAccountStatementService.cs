using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IAccountStatementService
    {
        PagedList<AsForTable> GetTable(FilterAsTableSelected filter);
        PagedList<AsForTable> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter);
        int GetPlanNotAsCount(FilterFixedPlanNotAsTableSelected filterFixed);
        AsForDetail GetForDetail(int idAs);

        List<InternalTransferDto> GetAsInternalTransfer(FilterAsTableSelected filter);
        List<AsForTable> GetAsInternalTransferOrphan(int idUserGroup);
        void CheckAsInternalTransferOrphan(int idUserGroup);
        List<AsForTable> GetByPlanPosteReferences(Poste poste, List<PlanAccount> planAccounts, List<PlanPosteReference> planPosteReferences,MonthYear monthYear);
        AsForTable GetLastAccountStatement(int idAccount);
        List<int> GetYearAvailable(int idUser, int idAccount);

        
        AccountStatement Create(AccountStatement accountStatement);
        AsForDetail Update(AsForDetail asForDetail);

    }
}
