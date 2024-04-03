using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public interface IAccountStatementRepository : IBaseRepository<AccountStatement>
    {
        PagedList<AccountStatement> GetAsTable(FilterAsTableSelected filter);
        PagedList<AccountStatement> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter);
        int GetPlanNotAsCount(FilterFixedPlanNotAsTableSelected filterFixed);
        AccountStatement GetForDetail(int id);
        List<AccountStatement> GetByDatePlanPosteReferenceList(Poste poste, List<PlanAccount> planAccounts, List<PlanPosteReference> planPosteReferences, DateTime dateMin, DateTime dateMax);
        List<int> GetYearAvailable(int idUser, int idAccount);
        bool HasOperation(int idOperation);
        bool HasOt(int idOt);
        bool HasOtf(int idOtf);
        bool HasAsi(int idAsi);
        bool IsDuplicate(AccountStatement accountStatement);
        //Boolean Save(List<AccountStatement> accountStatements);
        //new AccountStatement Create(AccountStatement accountStatement);
        SoldeDto GetSolde(int? idUser, int? idAccount, DateTime dateMin, DateTime dateMax, bool isWithITransfer);
        List<AccountStatement> GetAsInternalTransfer(int idUserGroup, int? idAccount, DateTime dateMin, DateTime dateMax);
        AccountStatement GetAsInternalTransferCouple(int idUserGroup, int idAccountStatement);
        List<AccountStatement> GetAsInternalTransferOrphan(int idUserGroup);
        List<AccountStatement> GetAsInternalTransferCouple(AccountStatement asOrphan);


        AccountStatement GetLastAccountStatement(int idAccount);
        AccountStatement SearchInternalTransferCouple(AccountStatement accountStatement);

    }
}
