using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IOperationTypeService
    {
        Select GetSelect(EnumOperationType enumOperationType, int idUserGroup);
        List<SelectGroupDto> GetSelectGroup(int idUserGroup);
        List<SelectGroupDto> GetSelectGroup(int idUserGroup, List<Select> operationTypeFamilies);
        List<Select> GetSelectList(int idUserGroup, List<Select> operationTypeFamilies);
        List<Select> GetSelectList(int idAccount, int idMovement, int idOperationTypeFamily, EnumSelectType enumSelectType);
        List<SelectGroupDto> GetSelectGroupListByMovement(int idUserGroup, EnumMovement enumMovement);
        List<Select> GetSelectListByIdList(List<int> idList);
        OperationType GetByIdWithOperationTypeFamily(int idOperationType);
        OperationType GetUnknown(int idUserGroup);
        OperationType GetById(int id);
        PagedList<OtForTableDto> GetForTable(FilterOtTableSelected filter);
        OtForDetail GetForDetail(int? idOperationType, int idUser);

        OtForDetail Save(OtForDetail otForDetailDto);
        void Delete(List<int> idOtList);

    }
}
