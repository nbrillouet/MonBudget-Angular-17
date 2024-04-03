using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System.Collections.Generic;


namespace Budget.SERVICE
{
    public class PlanPosteService : IPlanPosteService
    {
        private readonly IMapper _mapper;
        private readonly IPlanPosteFrequencyService _planPosteFrequencyService;
        private readonly IPlanPosteReferenceService _planPosteReferenceService;
        private readonly IPlanPosteUserService _planPosteUserService;

        private readonly IPlanPosteRepository _planPosteRepository;

        public PlanPosteService(
            IMapper mapper,
            IPlanPosteFrequencyService planPosteFrequencyService,
            IPlanPosteReferenceService planPosteReferenceService,
            IPlanPosteUserService planPosteUserService,

            IPlanPosteRepository planPosteRepository
            )
        {
            _mapper = mapper;
            _planPosteFrequencyService = planPosteFrequencyService;
            _planPosteReferenceService = planPosteReferenceService;
            _planPosteUserService = planPosteUserService;

            _planPosteRepository = planPosteRepository;
        }

        public PagedList<PlanPosteForTableDto> GetPlanPosteTable(FilterPlanPosteTableSelected filter)
        {
            var pagedList = _planPosteRepository.GetPlanPosteTable(filter);

            var result = new PagedList<PlanPosteForTableDto>(_mapper.Map<List<PlanPosteForTableDto>>(pagedList.Datas), pagedList.Pagination);

            return result;
        }

        public void Delete(List<int> idPlanPosteList)
        {
            foreach (var idPlanPoste in idPlanPosteList)
            {
                PlanPoste planPoste = GetById(idPlanPoste);
                if (planPoste != null)
                {
                    _planPosteUserService.DeleteByIdPlanPoste(planPoste.Id);
                    _planPosteFrequencyService.DeleteByIdPlanPoste(planPoste.Id);
                    _planPosteReferenceService.DeleteByIdPlanPoste(planPoste.Id);

                    Delete(planPoste);
                }
            }
        }

        public PlanPoste GetById(int idPlanPoste)
        {
            return _planPosteRepository.GetById(idPlanPoste);
        }

        public List<PlanPoste> Get(int idPlan, int idPoste)
        {
            return _planPosteRepository.Get(idPlan, idPoste);
        }

        public PlanPoste Create(PlanPoste planPoste)
        {
            return _planPosteRepository.Create(planPoste);
        }

        public PlanPoste Update(PlanPoste planPoste)
        {
            return _planPosteRepository.Update(planPoste);
        }

        public void Delete(PlanPoste planPoste)
        {
            _planPosteRepository.Delete(planPoste);
        }

        public void DeleteByIdPlan(int idPlan)
        {
            //Selection de tous les plans poste du plan
            var planPostes = _planPosteRepository.GetByIdPlan(idPlan);
            foreach(var planPoste in planPostes)
            {
                //suppression plan poste frequency
                _planPosteFrequencyService.DeleteByIdPlanPoste(planPoste.Id);
                //suppression plan poste reference
                _planPosteReferenceService.DeleteByIdPlanPoste(planPoste.Id);
                //suppression plan poste user
                _planPosteUserService.DeleteByIdPlanPoste(planPoste.Id);

                Delete(planPoste);
            }
        }
    }


}
