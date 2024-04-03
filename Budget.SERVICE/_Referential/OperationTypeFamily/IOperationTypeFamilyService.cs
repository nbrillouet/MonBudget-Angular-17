using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IOperationTypeFamilyService
    {
        PagedList<OtfForTableDto> GetForTable(FilterOtfTableSelected filter);
        OtfForDetail GetForDetail(int idOtf);
        OtfForDetail GetForDetail(int? idOtf, int idUser);
        OperationTypeFamily GetById(int idOtf);

        Select GetByCodeUserGroupForSelect(EnumOtf enumCodeOtf, int idUserGroup);
        List<Select> GetSelectList(int idUserGroup, EnumMovement enumMovement, EnumSelectType enumSelectType);
        List<SelectCode> GetSelectCodeList(int idOperationMethod, EnumSelectType enumSelectType);
        List<Select> GetSelectList(int idUserGroup, EnumSelectType enumSelectType);
        List<SelectGroupDto> GetSelectGroup(int idUserGroup);
        List<SelectGroupDto> GetSelectGroupListByMovement(int idUserGroup, EnumMovement enumMovement);
        List<Select> GetSelectListByIdList(List<int> idList);
        List<Select> GetByIdUserGroup(int idUserGroup);
                
        
        OtfForDetail Save(OtfForDetail otfForDetail);
        void Delete(List<int> listIdOtf);
        //void DeleteList(List<int> idOtfList, int idUserGroup);



    }
}
