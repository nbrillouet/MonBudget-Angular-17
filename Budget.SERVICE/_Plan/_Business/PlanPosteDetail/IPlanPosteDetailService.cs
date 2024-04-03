using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanPosteDetailService
    {
        PlanPosteForDetail GetForDetailById(int idPlan, int idPoste);
        PlanPosteForDetail GetForDetailById(int idPlanPoste);

        PlanPosteForDetail Save(PlanPosteForDetail planPosteForDetail);
        void Delete(List<int> listIdPlanPoste);
    }


}
