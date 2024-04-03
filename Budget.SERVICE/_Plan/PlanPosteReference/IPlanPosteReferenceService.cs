using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IPlanPosteReferenceService
    {
        void DeleteByIdPlanPoste(int idPlanPoste);
        void Create(PlanPosteReference planPosteReference);
        //ComboMultiple<SelectGroupDto> GetListForComboByIdPlanPoste(int idUser, int idPlanPoste, int idReferenceTable, int idPoste); // TO DELETE
        List<SelectGroupDto> GetListForSelectGroup(int idUserGroup, int idReferenceTable, int idPoste);
        List<Select> GetListForSelectList(int idPlanPoste, int idReferenceTable);
        List<PlanPosteReference> GetByIdPlanPoste(int idPlanPoste);
        List<Select> Save(int idPlanPoste, int idReferenceTable, List<Select> planPosteReferenceList);
    }


}
