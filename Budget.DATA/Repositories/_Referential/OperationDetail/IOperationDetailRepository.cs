using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationDetailRepository : IBaseRepository<OperationDetail>
    {
        bool HasSameKeywords(OperationDetail operationDetail);
        List<OperationDetail> GetAllByIdOperationMethod(int idUserGroup, int idOperationMethod);
        OperationDetail GetByOperationDetail(OperationDetail operationDetail);
        OperationDetail FindKeywordPlace(int idUserGroup, string operationLabel);
        OperationDetail GetUnknown(int idUserGroup);

        OperationDetail GetByIdForDetail(int idOperationDetail);
    }

}
