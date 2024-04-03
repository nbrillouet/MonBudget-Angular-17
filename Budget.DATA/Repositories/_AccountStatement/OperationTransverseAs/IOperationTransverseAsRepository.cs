using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationTransverseAsRepository
    {
        List<OperationTransverse> GetOperationTransverseList(int IdAccountStatement);
        List<OperationTransverseAs> GetByIdAs(int idAsif);

        OperationTransverseAs Create(OperationTransverseAs operationTransverseAs);
        OperationTransverseAs Update(OperationTransverseAs operationTransverseAs);
        bool Update(List<Select> operationTransverses, int idAsif);
    }

}
