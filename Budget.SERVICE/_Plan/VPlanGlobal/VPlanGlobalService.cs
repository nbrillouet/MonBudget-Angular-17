using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class VPlanGlobalService : IVPlanGlobalService
    {
        private readonly IMapper _mapper;
        //private readonly IPlanService _planService;
        private readonly IVPlanGlobalRepository _vPlanGlobalRepository;

        public VPlanGlobalService(
            IMapper mapper,
            //IPlanService planService,

            IVPlanGlobalRepository vPlanGlobalRepository

        )
        {
            _mapper = mapper;
            //_planService = planService;

            _vPlanGlobalRepository = vPlanGlobalRepository;

        }

        public List<VPlanGlobal> Get(FilterPlanFollowUpSelected filter)
        {
           return _vPlanGlobalRepository.Get(filter);
        }

        public List<VPlanGlobal> GetByIdPlan(int IdPlan)
        {
            return _vPlanGlobalRepository.GetByIdPlan(IdPlan);
        }

        public List<VPlanGlobal> GetByIdAccountStatement(int idAs)
        {
            List<VPlanGlobal> results = _vPlanGlobalRepository.GetByIdAccountStatement(idAs);

            return results;
        }

    }


}
