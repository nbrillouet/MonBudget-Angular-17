using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanPosteReferenceRepository : BaseRepository<PlanPosteReference>, IPlanPosteReferenceRepository
    {
        public PlanPosteReferenceRepository(BudgetContext context) : base(context)
        {

        }

        public List<PlanPosteReference> Get(int IdPlanPoste, int idReferenceTable)
        {
            var results = Context.PlanPosteReference
                .Where(x => x.IdPlanPoste == IdPlanPoste && x.IdReferenceTable== idReferenceTable)
                .ToList();
            return results;
        }

        public List<PlanPosteReference> GetByIdPlanPoste(int IdPlanPoste)
        {
            var results = Context.PlanPosteReference
                .Where(x => x.IdPlanPoste == IdPlanPoste)
                .ToList();
            return results;
        }

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            var results = Context.PlanPosteReference
                .Where(x => x.IdPlanPoste == idPlanPoste)
                .ToList();

            foreach(var result in results)
            {
                Delete(result);
            }
        }
    }


}
