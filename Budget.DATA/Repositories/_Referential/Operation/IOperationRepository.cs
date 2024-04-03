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
    public interface IOperationRepository : IBaseRepository<Operation>
    {
        List<Operation> GetSelectList(int idUserGroup);
        List<Operation> GetSelectList(int idUserGroup, int idOperationMethod, int idOperationType);
        List<Operation> GetSelectList(int idUserGroup, List<Select> operationMethodList, List<Select> operationTypeFamilyList, List<Select> operationTypeList);
        List<Operation> GetByIdMovement(int idUserGroup, EnumMovement enumMovement);
        List<Operation> GetByIdList(List<int> idList);
        Operation GetUnknown(int idUserGroup);
        PagedList<Operation> GetForTable(FilterOperationTableSelected filter);
        Operation GetForDetail(int idOperation);
        bool IsDuplicate(OperationForDetail oForDetail);
        bool HasOt(int idOt);

    }
}
