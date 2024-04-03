using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IOperationTransverseAsifService
    {
        List<OperationTransverseAsif> GetByIdAsif(int idAsif);
        List<Select> GetOperationTransverseSelectList(int IdAccountStatementFile, EnumSelectType enumSelectType);
        bool Update(List<Select> operationTransverses, int idAsif);

    }
}
