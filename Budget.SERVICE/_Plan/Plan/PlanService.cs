using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class PlanService : IPlanService
    {
        private readonly IMapper _mapper;
        private readonly IPlanAccountService _planAccountService;
        private readonly IPlanUserService _planUserService;
        private readonly IPlanPosteService _planPosteService;
        private readonly IVPlanGlobalService _vPlanGlobalService;

        private readonly IPlanRepository _planRepository;
        //private readonly IPlanUserRepository _planUserRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly IPlanPosteRepository _planPosteRepository;

        public PlanService(
            IMapper mapper,
            IPlanAccountService planAccountService,
            IPlanUserService planUserService,
            IPlanPosteService planPosteService,
            IVPlanGlobalService vPlanGlobalService,

            IPlanRepository planRepository
            //IPlanUserRepository planUserRepository,
            //IUserRepository userRepository,
            //IPlanPosteRepository planPosteRepository
            )
            //IPlanService planService)
        {
            _mapper = mapper;
            _planAccountService = planAccountService;
            _planUserService = planUserService;
            _planPosteService = planPosteService;
            _vPlanGlobalService = vPlanGlobalService;

            _planRepository = planRepository;
            //_planUserRepository = planUserRepository;
            //_userRepository = userRepository;
            //_planPosteRepository = planPosteRepository;
            //_planService = planService;
        }

        //public List<Plan> Get(FilterPlan filter)
        //{
        //    var results = _planRepository.Get(filter);
        //    //var result = new PagedList1<Plan>(pagedList.Datas, pagedList.Pagination);

        //    return results; 

        //}

        public PagedList<Plan> GetPlanTable(FilterPlanTableSelected filter)
        {
            var pagedList = _planRepository.GetPlanTable(filter);
            //var result = new PagedList<UserForTableDto>(_mapper.Map<List<UserForTableDto>>(pagedList.Datas), pagedList.Pagination);
            return pagedList;

            //var datas = _planRepository.Get(filter);
            //return datas;
        }

        public List<int> GetDistinctYears()
        {
            var results = _planRepository.GetDistinctYears();

            return results; // _mapper.Map<List<SelectDto>>(results);
        }

        //public PlanForTableComboFilter GetPlanTableComboFilter()
        //{
        //    //PlanForTableComboFilter PlanForTableComboFilter = new PlanForTableComboFilter();
        //    var years = _planRepository.GetDistinctYears();
        //    List<SelectDto> comboYears = new List<SelectDto>();
        //    SelectDto selected = new SelectDto();
        //    foreach (var year in years)
        //    {
        //        selected = new SelectDto { Id = year, Label = year.ToString() };
        //        comboYears.Add(selected);
        //    }

        //    return new PlanForTableComboFilter
        //    {
        //        Years = new ComboSimple<SelectDto>
        //        {
        //            List = comboYears,
        //            Selected = selected
        //        }
        //    };
        //}


        public Plan GetById(int idPlan)
        {
            return _planRepository.GetById(idPlan);
        }
        public List<SelectCode> GetForSelectByIdAs(int idAs)
        {
            List<VPlanGlobal> vPlanGlobalList = _vPlanGlobalService.GetByIdAccountStatement(idAs);
            List<SelectCode> results = new List<SelectCode>();
            foreach (var item in vPlanGlobalList)
            {
                SelectCode plan = _mapper.Map<SelectCode>(GetById(item.IdPlan.Value));
                results.Add(plan);
            }

            return results;
        }

        //public List<int?> GetIdAsInPlan(int idPlan)
        //{
        //    List<VPlanGlobal> vPlanGlobalList = _vPlanGlobalService.GetByIdPlan(idPlan);

        //    return vPlanGlobalList.Select(x => x.IdAccountStatement).ToList();
        //}

        public void Create(Plan plan)
        {
            _planRepository.Create(plan);
        }

        public void Update(Plan plan)
        {
            _planRepository.Update(plan);
        }

        public void Delete(Plan plan)
        {
            _planRepository.Delete(plan);
        }

        public void DeletePlans(List<int> idPlanList)
        {
            foreach(var idPlan in idPlanList)
            {
                var plan = GetById(idPlan);
                //delete plan account
                _planAccountService.DeleteByIdPlan(idPlan);
                //delete plan user
                _planUserService.DeleteByIdPlan(idPlan);
                //delete plan poste
                _planPosteService.DeleteByIdPlan(idPlan);

                Delete(plan);
            }
        }




    }


}
