using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationTypeRepository : IBaseRepository<OperationType>
    {
        OperationType Get(EnumOperationType enumOperationType, int idUserGroup);
        List<OperationType> GetByIdUserGroup(int idUserGroup);
        List<OperationType> GetByIdOperationTypeFamily(int idOperationTypeFamily);
        List<OperationType> GetForViri(int idAccount,int idMovement, int idOperationTypeFamily);

        List<OperationType> GetByOperationTypeFamilies(int idUserGroup, List<Select> OperationTypeFamilies);
        OperationType GetByIdWithOperationTypeFamily(int idOperationType);
        List<OperationType> GetByIdMovement(int idUserGroup, EnumMovement enumMovement);
        List<OperationType> GetByIdList(List<int> idList);
        OperationType GetUnknown(int idUserGroup);
        PagedList<OperationType> GetForTable(FilterOtTableSelected filter);
        //OperationType GetForDetail(int idOperationType);
        OperationType GetForDetail(int idOt);
        bool HasOtf(int idOtf);

        void DeleteWithEscalation(OperationType operationType);
    }
}
