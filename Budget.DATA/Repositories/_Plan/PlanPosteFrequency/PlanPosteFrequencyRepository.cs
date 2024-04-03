using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PlanPosteFrequencyRepository : BaseRepository<PlanPosteFrequency>, IPlanPosteFrequencyRepository
    {
        public PlanPosteFrequencyRepository(BudgetContext context) : base(context)
        {

        }

        

        public List<PlanPosteFrequency> GetByIdPlanPoste(int idPlanPoste)
        {
            var PlanPosteFrequencies = Context.PlanPosteFrequency
                .Where(x => x.IdPlanPoste == idPlanPoste)
                .Include(x=>x.Frequency)
                .ToList();
            return PlanPosteFrequencies;
        }

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            var results = Context.PlanPosteFrequency
                .Where(x => x.IdPlanPoste == idPlanPoste)
                .ToList();

            foreach (var result in results)
            {
                Delete(result);
            }
        }


    }

}
