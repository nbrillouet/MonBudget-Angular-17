using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IAccountStatementImportService
    {
        AsiForList GetAsiForList(int idUser);
        //List<BankAgency> GetDistinctBankAgencies(int idUser);
        PagedList<AsiForTableDto> GetAsiTable(FilterAsiTableSelected filter);
        //ValueTask<AccountStatementImport> GetByIdAsync(int idImport);
        AsiForTableDto GetByIdForData(int idImport);
        AsiForListDto GetForDetailById(int idImport);
        AccountStatementImport ImportFile(StreamReader reader, User user);
        AccountStatementImport SaveWithTran(AccountStatementImport accountStatementImport);
        UserForGroupDto GetUserForGroup(int idImport);
        void DeleteList(List<int> idAsiList);
    }
}
