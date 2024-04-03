using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class PlanPosteDetailService : IPlanPosteDetailService
    {
        private readonly IMapper _mapper;
        private readonly IPlanPosteService _planPosteService;
        private readonly IPosteService _posteService;
        private readonly IPlanPosteUserService _planPosteUserService;
        private readonly IReferenceTableService _referenceTableService;
        private readonly IPlanPosteReferenceService _planPosteReferenceService;
        private readonly IPlanPosteFrequencyService _planPosteFrequencyService;
        private readonly IMonthService _frequencyService;
        //private readonly IAccountStatementPlanService _accountStatementPlanService;
        private readonly IPlanAccountService _planAccountService;

        public PlanPosteDetailService(
            IMapper mapper,
            IPlanPosteService planPosteService,
            IPosteService posteService,
            IPlanPosteUserService planPosteUserService,
            IReferenceTableService referenceTableService,
            IPlanPosteReferenceService planPosteReferenceService,
            IPlanPosteFrequencyService planPosteFrequencyService,
            IMonthService frequencyService,
            IPlanAccountService planAccountService

            )
        {
            _mapper = mapper;
            _planPosteService = planPosteService;
            _posteService = posteService;
            _planPosteUserService = planPosteUserService;
            _referenceTableService = referenceTableService;
            _planPosteReferenceService = planPosteReferenceService;
            _planPosteFrequencyService = planPosteFrequencyService;
            _frequencyService = frequencyService;
            _planAccountService = planAccountService;
        }

        public PlanPosteForDetail GetForDetailById(int idPlanPoste)
        {
            var planPoste = _planPosteService.GetById(idPlanPoste);

            PlanPosteForDetail planPosteForDetail = _mapper.Map<PlanPosteForDetail>(planPoste);
            planPosteForDetail.Poste = _mapper.Map<SelectCode>(planPoste.Poste);
            planPosteForDetail.ReferenceTable =  _mapper.Map<Select>(planPoste.ReferenceTable);
            planPosteForDetail.PlanPosteUser = _planPosteUserService.GetByIdPlanPoste(planPoste.Id);
            planPosteForDetail.PlanPosteReference = _planPosteReferenceService.GetListForSelectList(planPoste.Id, planPoste.ReferenceTable.Id);
            planPosteForDetail.PlanPosteFrequencies = _planPosteFrequencyService.GetByIdPlanPoste(planPoste.Id);

            return planPosteForDetail;
        }

        public PlanPosteForDetail GetForDetailById(int idPlan, int idPoste)
        {
            PlanPosteForDetail planPosteForDetail = new PlanPosteForDetail();
            planPosteForDetail.IdPlan = idPlan;
            planPosteForDetail.IdPoste = idPoste;
            planPosteForDetail.Poste = _mapper.Map<SelectCode>(_posteService.GetById(idPoste));

            planPosteForDetail.ReferenceTable = new Select();
            planPosteForDetail.PlanPosteUser = _planPosteUserService.InitForCreation(idPlan);
            planPosteForDetail.PlanPosteReference = new List<Select>(); 
            planPosteForDetail.PlanPosteFrequencies = _planPosteFrequencyService.GetByIdPlanPoste(null);

            return planPosteForDetail;
        }

        public PlanPosteForDetail Save(PlanPosteForDetail planPosteForDetail)
        {

            PlanPoste planPoste = CheckValues(planPosteForDetail);

            PlanPosteForDetail planPosteForDetailSaved = Save(planPoste);
            planPosteForDetailSaved.PlanPosteUser = _planPosteUserService.Save(planPosteForDetailSaved.Id, planPosteForDetail.PlanPosteUser);
            planPosteForDetailSaved.PlanPosteReference = _planPosteReferenceService.Save(planPosteForDetailSaved.Id, planPosteForDetail.ReferenceTable.Id, planPosteForDetail.PlanPosteReference);
            planPosteForDetailSaved.PlanPosteFrequencies = _planPosteFrequencyService.Save(planPosteForDetailSaved.Id, planPosteForDetail.PlanPosteFrequencies);

            return planPosteForDetailSaved;
        }

        private PlanPosteForDetail Save(PlanPoste planPoste)
        {
            planPoste = planPoste.Id == 0
               ? Create(planPoste)
               : Update(planPoste);

            PlanPosteForDetail planPosteForDetail = GetForDetailById(planPoste.Id);

            return planPosteForDetail;
            //return Save(couverture, userName);
        }


        private PlanPoste Create(PlanPoste planPoste)
        {

            planPoste = _planPosteService.Create(planPoste);
            return planPoste;
        }

        private PlanPoste Update(PlanPoste planPoste)
        {

            planPoste = _planPosteService.Update(planPoste);

            return planPoste;
        }

        private PlanPoste CheckValues(PlanPosteForDetail planPosteForDetail)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Check des données      
            //IsExist(couvertureForData, forcableSave, businessExceptionMessages);
            //if (HelperDate.IsWeekEnd(couvertureForData.DateOperation))
            //{
            //    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_ERR_046, true));
            //}


            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            return _mapper.Map<PlanPoste>(planPosteForDetail);
        }

        private void UpdatePlanPosteReference(int idPlanPoste,int idReferenceTable, List<Select> planPosteReferences)
        {
            //sauvegarde PlanPosteReference
            //suppression des PlanPosteReference pour l'idPoste
            _planPosteReferenceService.DeleteByIdPlanPoste(idPlanPoste);
            foreach (var planPosteReference in planPosteReferences)
            {
                PlanPosteReference ppr = new PlanPosteReference
                {
                    Id = 0,
                    IdPlanPoste = idPlanPoste,
                    IdReference = planPosteReference.Id,
                    IdReferenceTable = idReferenceTable
                };
                _planPosteReferenceService.Create(ppr);
            }
        }

        private void UpdatePlanPosteFrequency(int idPlanPoste, List<PlanPosteFrequencyForDetailDto> planPosteFrequencies)
        {
            //Sauvegarde PlanPosteFrequency
            //suppression des PlanPosteFrequency pour l'idPoste
            _planPosteFrequencyService.DeleteByIdPlanPoste(idPlanPoste);
            foreach (var planPosteFrequency in planPosteFrequencies)
            {
                PlanPosteFrequency ppf = new PlanPosteFrequency
                {
                    Id = 0,
                    IdFrequency = planPosteFrequency.Frequency.Id,
                    IdPlanPoste = idPlanPoste,
                    PreviewAmount = planPosteFrequency.PreviewAmount
                };
                _planPosteFrequencyService.Create(ppf);
            }
        }

        public void Delete(List<int> listIdPlanPoste)
        {
            foreach(var idPlanPoste in listIdPlanPoste)
            {
                PlanPoste planPoste = _planPosteService.GetById(idPlanPoste);
                if(planPoste!=null)
                {
                    _planPosteUserService.DeleteByIdPlanPoste(planPoste.Id);
                    _planPosteFrequencyService.DeleteByIdPlanPoste(planPoste.Id);
                    _planPosteReferenceService.DeleteByIdPlanPoste(planPoste.Id);

                    _planPosteService.Delete(planPoste);
                }
            }
        }
    }
}
