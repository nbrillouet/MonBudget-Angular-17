using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class PlanPosteFrequencyService : IPlanPosteFrequencyService
    {
        private readonly IMapper _mapper;
        private readonly IPlanPosteFrequencyRepository _planPosteFrequencyRepository;
        private readonly IMonthService _monthService;

        public PlanPosteFrequencyService(
            IMapper mapper,
            IPlanPosteFrequencyRepository planPosteFrequencyRepository,
            IMonthService monthService
        )
        {
            _mapper = mapper;
            _planPosteFrequencyRepository = planPosteFrequencyRepository;
            _monthService = monthService;
        }

        public PlanPosteFrequencies GetByIdPlanPoste(int? idPlanPoste)
        {
            //init
            PlanPosteFrequencies planPosteFrequencies = InitPlanPosteFrequencies();
            
            //cas create
            if (idPlanPoste == null)
            {
                return planPosteFrequencies;
            }

            //cas update
            List<PlanPosteFrequencyForDetailDto> ppf = _mapper.Map<List<PlanPosteFrequencyForDetailDto>>(GetBaseByIdPlanPoste(idPlanPoste.Value));
            //yearly
            if(ppf.Count==1)
            {
                planPosteFrequencies.IsYearly = true;
                planPosteFrequencies.Yearly = ppf;
            }
            //monthly
            else
            {
                planPosteFrequencies.IsYearly = false;
                planPosteFrequencies.Monthly = ppf;
            }


            return planPosteFrequencies;
        }

        private PlanPosteFrequencies InitPlanPosteFrequencies()
        {
            PlanPosteFrequencies planPosteFrequencies = new PlanPosteFrequencies();
            planPosteFrequencies.IsYearly = false;
            planPosteFrequencies.Yearly = InitPlanPosteFrequencyForDetailList(_monthService.GetAnnual());
            planPosteFrequencies.Monthly = InitPlanPosteFrequencyForDetailList(_monthService.GetAll());

            return planPosteFrequencies;
        }

        private List<PlanPosteFrequencyForDetailDto> InitPlanPosteFrequencyForDetailList(List<Month> months)
        {
            List<PlanPosteFrequencyForDetailDto> PlanPosteFrequenciesForDetailDto = new List<PlanPosteFrequencyForDetailDto>();
            foreach (var frequency in months)
            {
                PlanPosteFrequencyForDetailDto planPosteFrequencyForDetailDto = new PlanPosteFrequencyForDetailDto
                {
                    Id = 0,
                    Frequency = frequency,
                    PreviewAmount = 100
                };

                PlanPosteFrequenciesForDetailDto.Add(planPosteFrequencyForDetailDto);
            }
            return PlanPosteFrequenciesForDetailDto;
        }

        public List<PlanPosteFrequency> GetBaseByIdPlanPoste(int idPlanPoste)
        {
            List<PlanPosteFrequency> PlanPosteFrequencies = _planPosteFrequencyRepository.GetByIdPlanPoste(idPlanPoste);
            return PlanPosteFrequencies;
        }

        //public List<PlanPosteFrequencyForDetailDto> InitForCreation(bool isAnnualEstimation)
        //{
            
        //    List<PlanPosteFrequencyForDetailDto> PlanPosteFrequenciesForDetailDto = new List<PlanPosteFrequencyForDetailDto>();
        //    List<Month> frequencies;
        //    if (!isAnnualEstimation)
        //        frequencies = _monthService.GetAll();
        //    else
        //        frequencies= _monthService.GetAnnual();

        //    foreach (var frequency in frequencies)
        //    {
        //        PlanPosteFrequencyForDetailDto planPosteFrequencyForDetailDto = new PlanPosteFrequencyForDetailDto
        //        {
        //            Id = 0,
        //            Frequency = frequency,
        //            PreviewAmount = 100
        //        };

        //        PlanPosteFrequenciesForDetailDto.Add(planPosteFrequencyForDetailDto);
        //    }

        //    return PlanPosteFrequenciesForDetailDto;
        //}

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            _planPosteFrequencyRepository.DeleteByIdPlanPoste(idPlanPoste);
        }

        public void Create(PlanPosteFrequency planPosteFrequency)
        {
            _planPosteFrequencyRepository.Create(planPosteFrequency);
        }

        public PlanPosteFrequencies Save(int idPlanPoste, PlanPosteFrequencies planPosteFrequencies)
        {
            //suppression données existante
            if(idPlanPoste!=0)
                DeleteByIdPlanPoste(idPlanPoste);


            if (planPosteFrequencies.IsYearly)
            {
                Create(idPlanPoste, planPosteFrequencies.Yearly);
            }
            else
            {
                Create(idPlanPoste, planPosteFrequencies.Monthly);
            }

            return GetByIdPlanPoste(idPlanPoste);
        }

        private void Create(int idPlanPoste, List<PlanPosteFrequencyForDetailDto> planPosteFrequencyForDetailList)
        {
            foreach(var item in planPosteFrequencyForDetailList)
            {
                PlanPosteFrequency ppf = new PlanPosteFrequency { IdPlanPoste = idPlanPoste, IdFrequency = item.Frequency.Id, PreviewAmount = item.PreviewAmount };
                Create(ppf);
            }
        }


    }

}
