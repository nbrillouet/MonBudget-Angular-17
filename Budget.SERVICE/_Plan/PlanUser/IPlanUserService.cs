using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IPlanUserService
    {
        List<PlanUser> GetByIdPlan(int idPlan);
        List<Plan> GetPlansByIdUser(int idUser);
        ComboMultiple<Select> GetUserComboMultiple(int idPlan, int idUserGroup);
        void Create(PlanUser planUser);
        //void SaveByIdPlan(int idPlan,List<SelectDto> selectUsers);
        void DeleteByIdPlan(int idPlan);
    }


}
