using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class PlanPosteUserService : IPlanPosteUserService
    {
        private readonly IMapper _mapper;
        private readonly IPlanPosteUserRepository _planPosteUserRepository;
        private readonly IPlanUserService _planUserService;

        public PlanPosteUserService(
            IMapper mapper,
            IPlanUserService planUserService,
            IPlanPosteUserRepository planPosteUserRepository
        )
        {
            _mapper = mapper;
            _planUserService = planUserService;
            _planPosteUserRepository = planPosteUserRepository;
        }

        public List<PlanPosteUserForDetailDto> GetByIdPlanPoste(int idPlanPoste)
        {
            var planPosteUsers = GetBaseByIdPlanPoste(idPlanPoste);
            return _mapper.Map<List<PlanPosteUserForDetailDto>>(planPosteUsers);
        }

        public List<PlanPosteUser> GetBaseByIdPlanPoste(int idPlanPoste)
        {
            var planPosteUsers = _planPosteUserRepository.GetByIdPlanPoste(idPlanPoste);
            return planPosteUsers;
        }

        public List<PlanPosteUserForDetailDto> InitForCreation(int idPlan)
        {
            List<PlanPosteUserForDetailDto> planPosteUsersForDetailDto = new List<PlanPosteUserForDetailDto>();
            var planUsers = _planUserService.GetByIdPlan(idPlan);
            foreach (var planUser in planUsers)
            {
                PlanPosteUserForDetailDto PlanPosteUserForDetailDto = new PlanPosteUserForDetailDto
                {
                    Id = 0,
                    IdPlanUser = planUser.Id,
                    User = _mapper.Map<UserForLabelDto>(planUser.User),
                    IsSalaryEstimatedPart = false,
                    PercentagePart = 0
                };

                planPosteUsersForDetailDto.Add(PlanPosteUserForDetailDto);
            }

            return planPosteUsersForDetailDto;
        }

        public void Save(int idPlan, List<Select> selectUsers)
        {
            //Suppression
            //DeleteByIdPlan(idPlan);

            List<PlanUser> planUsers = _planUserService.GetByIdPlan(idPlan);

            //check enregistrement dans planPosteUser non present dans selectUsers
            var planPosteUsers = UserNotInForPlan(idPlan, selectUsers);
            if (planPosteUsers.Count > 0)
            {
                throw new Exception($"Impossible de supprimer l'utilisateur: {planPosteUsers[0].PlanUser.User.LastName}");
            }

            //Enregistrement
            foreach (var user in selectUsers)
            {
                var planUser = planUsers.Where(x => x.IdUser == user.Id).FirstOrDefault();
                if (planUser == null)
                {
                    var planUserNew = new PlanUser
                    {
                        IdPlan = idPlan,
                        IdUser = user.Id
                    };
                    _planUserService.Create(planUserNew);
                }
            }
        }

        public List<PlanPosteUserForDetailDto> Save(int idPlanPoste, List<PlanPosteUserForDetailDto> PlanPosteUserForDetailList)
        {
            //recherche des enregistrements pour le plan poste et suppression si existant:
            var planPosteList = GetByIdPlanPoste(idPlanPoste);
            if (planPosteList.Count > 0)
                DeleteByIdPlanPoste(idPlanPoste);

            foreach (var planPosteUserForDetail in PlanPosteUserForDetailList)
            {
                PlanPosteUser ppu = _mapper.Map<PlanPosteUser>(planPosteUserForDetail);
                ppu.Id = 0;
                ppu.IdPlanPoste = idPlanPoste;
                Create(ppu);
            }

            return GetByIdPlanPoste(idPlanPoste);
        }

        public PlanPosteUser GetById(int idPlanPosteUser)
        {
            return _planPosteUserRepository.GetById(idPlanPosteUser);
        }

        private List<PlanPosteUser> UserNotInForPlan(int idPlan, List<Select> planUsers)
        {
            var idUserList = planUsers.Select(x => x.Id).ToList();
            return _planPosteUserRepository.UserNotInForPlan(idPlan, idUserList);
        }

        public void Create(PlanPosteUser planPosteUser)
        {
            _planPosteUserRepository.Create(planPosteUser);
        }

        public void Update(PlanPosteUser planPosteUser)
        {
            _planPosteUserRepository.Update(planPosteUser);
        }

        public void Delete(PlanPosteUser planPosteUser)
        {
            _planPosteUserRepository.Delete(planPosteUser);
        }

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            _planPosteUserRepository.DeleteByIdPlanPoste(idPlanPoste);
        }
    }
}
