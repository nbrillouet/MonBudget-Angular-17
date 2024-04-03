using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanPosteUserService
    {
        List<PlanPosteUserForDetailDto> GetByIdPlanPoste(int idPlanPoste);
        List<PlanPosteUser> GetBaseByIdPlanPoste(int idPlanPoste);
        List<PlanPosteUserForDetailDto> InitForCreation(int idPlan);
        //List<PlanPosteUser> UserNotInForPlan(int idPlan,List<PlanUser> planUsers);
        PlanPosteUser GetById(int idPlanPosteUser);

        void Create(PlanPosteUser planPosteUser);
        void Update(PlanPosteUser planPosteUser);
        void Delete(PlanPosteUser planPosteUser);
        void DeleteByIdPlanPoste(int idPlanPoste);
        void Save(int idPlan, List<Select> selectUsers);

        List<PlanPosteUserForDetailDto> Save(int idPlanPoste, List<PlanPosteUserForDetailDto> PlanPosteUserForDetailList);
    }
}
