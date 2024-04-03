using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationTransverseRepository
    {
        List<OperationTransverse> GetSelectList(int idUser);

        OperationTransverse Add(OperationTransverse operationTransverse);
    }
}
