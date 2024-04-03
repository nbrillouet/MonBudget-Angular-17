using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IOperationService 
    {
        Select GetUnknown(int idUserGroup);
        List<Select> GetSelectList(int idUserGroup);
        List<Select> GetSelectList(int idUserGroup, int idOperationMethod, int idOperationType, EnumSelectType enumSelectType);
        List<Select> GetSelectList(int idUserGroup, List<Select> operationMethodList, List<Select> operationTypeFamilyList, List<Select> operationTypeList);
        List<SelectGroupDto> GetSelectGroupListByMovement(int idUserGroup, EnumMovement enumMovement);
        List<Select> GetSelectListByIdList(List<int> idList);
        PagedList<OperationForTableDto> GetForTable(FilterOperationTableSelected filter);
        OperationForDetail GetForDetail(int? idOperation, int idUser);
        
        OperationForDetail SaveDetail(OperationForDetail operationForDetail);
        Operation Save(Operation operation);

        void Delete(Operation operation);
        bool Delete(int idOperation);
        void Delete(List<int> idOperationList);

    }
}
