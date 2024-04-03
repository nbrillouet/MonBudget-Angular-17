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
    public interface IAccountStatementImportFileService
    {
        PagedList<AsifForTable> GetAsifTable(FilterAsifTableSelected filter);
        AsForDetail GetForDetail(int idAs);
        List<Select> GetAccountSelectListByIdImport(int idImport);

        AsifGroupByAccounts GetListDto(int idImport);
        List<Select> GetAsifStates(int idImport, int idAccount);

        string GetOperationLabelWork(string operationLabel);
        OperationDetail GetOperationDetail(AsifForDetail asifForDetail);
        bool IsSaveableInAccountStatement(int idImport);


        AsForDetail SaveAsifDetail(AsForDetail asifForDetail);
        void SaveWithTran(List<AccountStatementImportFile> accountStatementImportFiles);
        bool SaveInAccountStatement(int idImport);
        void DeleteByIdImport(int idImport);



    }
}
