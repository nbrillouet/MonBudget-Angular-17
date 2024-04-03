using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanService
    {
        PagedList<Plan> GetPlanTable(FilterPlanTableSelected filter);
        Plan GetById(int idPlan);
        List<SelectCode> GetForSelectByIdAs(int idAs);
        //List<int> GetIdAsInPlan(int idPlan);
        List<int> GetDistinctYears();

        void Create(Plan plan);
        void DeletePlans(List<int> idPlanList);
        void Update(Plan plan);
    }
}
