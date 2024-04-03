using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IOperationTransverseService
    {
        List<Select> GetSelectList(int idUser, EnumSelectType enumSelectType);

        OperationTransverse Add(OperationTransverse operationTransverse);
    }

}
