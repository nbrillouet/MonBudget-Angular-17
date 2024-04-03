using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IPlanPosteRepository : IBaseRepository<PlanPoste>
    {
        PagedList<PlanPoste> GetPlanPosteTable(FilterPlanPosteTableSelected filter);
        List<PlanPoste> Get(int idPlan, int idPoste);
        new PlanPoste GetById(int id);
        List<PlanPoste> GetByIdPlan(int idPlan);
    }    
}
