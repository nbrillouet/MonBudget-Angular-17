using AutoMapper;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class PlanDetailService: IPlanDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IPlanService _planService;
        private readonly IPlanUserService _planUserService;
        private readonly IPlanPosteService _planPosteService;
        private readonly IPlanPosteUserService _planPosteUserService;
        private readonly IPosteService _posteService;
        private readonly IPlanAccountService _planAccountService;
        private readonly IPlanNotAsService _planNotAsService;


        public PlanDetailService(
            IMapper mapper,
            IUserService userService,
            IPlanService planService,
            IPlanUserService planUserService,
            IPlanPosteService planPosteService,
            IPosteService posteService,
            IPlanPosteUserService planPosteUserService,
            IPlanAccountService planAccountService,
            IPlanNotAsService planNotAsService

            )
        {
            _mapper = mapper;
            _userService = userService;
            _planService = planService;
            _planUserService = planUserService;
            _planPosteService = planPosteService;
            _posteService = posteService;
            _planPosteUserService = planPosteUserService;
            _planAccountService = planAccountService;
            _planNotAsService = planNotAsService;
        }

        public PlanForDetailDto GetForDetail(int idPlan, int idUser)
        {
            var user = _userService.GetById(idUser);
            var users = _userService.GetByIdUserGroup(user.IdUserGroup);
            var userList = _mapper.Map<List<Select>>(users);

            PlanForDetailDto planForDetailDto = new PlanForDetailDto();
            //Recherche des accounts (list + selected)
            planForDetailDto.Accounts = _planAccountService.GetAccountComboMultiple(idPlan, idUser);
            //recherche des users (list + selected)
            planForDetailDto.Users = _planUserService.GetUserComboMultiple(idPlan, idUser);
            

            //nouveau Plan
            if (idPlan == 0)
            {

                planForDetailDto.Plan = new Plan
                {
                    Id = 0,
                    Label = null,
                    Year = DateTime.Now.Year
                };
                //planForDetailDto.Accounts = _planAccountService.GetAccountComboMultiple(idPlan);

                //planForDetailDto.Users.List = userList;
                //planForDetailDto.Users.ListSelected = new List<SelectDto>();
                //return planForDetailDto;
            }
            else
            {
                planForDetailDto.Plan = _planService.GetById(idPlan);
                //recherche du nombre d'account statement non relié au plan
                planForDetailDto.PlanNotAsCount = _planNotAsService.GetPlanNotAsCount(idPlan, idUser);
                
                //var postes = _posteService.GetAllSelect();
                //foreach (var poste in postes)
                //{
                //    PlanPosteDto planPosteDto = new PlanPosteDto
                //    {
                //        Poste = poste,
                //        List = _mapper.Map<List<PlanPosteForTableDto>>(_planPosteService.Get(idPlan, poste.Id))
                //    };
                //    planForDetailDto.PlanPostes.Add(planPosteDto);
                //};
            }
            return planForDetailDto;
        }

        public void Save(PlanForDetailDto planForDetailDto)
        {
            Plan plan = planForDetailDto.Plan;

            //sauvegarde de plan et de user selected
            if (planForDetailDto.Plan.Id == 0)
            {
                _planService.Create(plan);
            }
            else
            {
                _planService.Update(plan);
            }

            _planPosteUserService.Save(plan.Id, planForDetailDto.Users.ListSelected);
            _planAccountService.Save(plan.Id, planForDetailDto.Accounts.ListSelected);

        }



        
    }
}
