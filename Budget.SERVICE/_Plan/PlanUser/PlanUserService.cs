using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class PlanUserService: IPlanUserService
    {
        private readonly IMapper _mapper;
        private readonly IPlanUserRepository _planUserRepository;
        private readonly IUserService _userService;
        //private readonly IPlanPosteUserService _planPosteUserService;

        public PlanUserService(
            IMapper mapper,

            IPlanUserRepository planUserRepository,
            IUserService userService

            //IPlanPosteUserService planPosteUserService
        )
        {
            _mapper = mapper;
            
            _planUserRepository = planUserRepository;
            _userService = userService;
            //_planPosteUserService = planPosteUserService;

        }

        public List<PlanUser> GetByIdPlan(int idPlan)
        {
            return _planUserRepository.GetByIdPlan(idPlan);
        }

        public List<Plan> GetPlansByIdUser(int idUser)
        {
            var planUsers = _planUserRepository.GetByIdUser(idUser);
            return planUsers.Select(x => x.Plan).ToList();
        }

        public ComboMultiple<Select> GetUserComboMultiple(int idPlan, int idUserGroup)
        {
            var users = _userService.GetByIdUserGroup(idUserGroup);
            var userList = _mapper.Map<List<Select>>(users);

            var planUsers = GetByIdPlan(idPlan);
            var usersSelected = _mapper.Map<List<Select>>(planUsers);

            ComboMultiple<Select> result = new ComboMultiple<Select>
            {
                List = userList,
                ListSelected = usersSelected
            };

            return result;
        }
        public void Create(PlanUser planUser)
        {
            _planUserRepository.Create(planUser);
        }

        

        public void DeleteByIdPlan(int idPlan)
        {
            _planUserRepository.DeleteByIdPlan(idPlan);
        }
    }
}
