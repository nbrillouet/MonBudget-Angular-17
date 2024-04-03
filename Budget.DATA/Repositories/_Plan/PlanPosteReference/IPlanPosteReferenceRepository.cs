using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanPosteReferenceRepository : IBaseRepository<PlanPosteReference>
    {
        List<PlanPosteReference> GetByIdPlanPoste(int IdPlanPoste);
        List<PlanPosteReference> Get(int IdPlanPoste, int idReferenceTable);

        void DeleteByIdPlanPoste(int idPlanPoste);
    }


}
