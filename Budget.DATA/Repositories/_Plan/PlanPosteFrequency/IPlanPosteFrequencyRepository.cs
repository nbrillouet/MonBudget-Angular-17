using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanPosteFrequencyRepository : IBaseRepository<PlanPosteFrequency>
    {
        List<PlanPosteFrequency> GetByIdPlanPoste(int idPlanPoste);
        void DeleteByIdPlanPoste(int idPlanPoste);
    }


}
