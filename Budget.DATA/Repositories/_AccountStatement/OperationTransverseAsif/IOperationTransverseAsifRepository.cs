using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationTransverseAsifRepository
    {
        List<OperationTransverse> GetOperationTransverseList(int IdAccountStatementFile);
        List<OperationTransverseAsif> GetByIdAsif(int idAsif);
        bool Update(List<Select> operationTransverses, int idAsif);
    }
}
