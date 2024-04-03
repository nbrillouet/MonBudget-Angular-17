using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private readonly IUserPreferenceRepository _userPreferenceRepository;
        private readonly IMapper _mapper;

        public UserPreferenceService(
            IUserPreferenceRepository userPreferenceRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _userPreferenceRepository = userPreferenceRepository;
        }

        public UserPreference Get(int id)
        {
            var userPreference = _userPreferenceRepository.GetById(id);

            return userPreference; // _mapper.Map<UserPreferenceDto>(userPreference);
        }

        public UserPreference GetByIdUser(int idUser)
        {
            var userPreference = _userPreferenceRepository.GetByIdUser(idUser);

            return userPreference; 
        }

        public UserPreference Update(UserPreference userPreference)
        {
            //var userPreferenceRef = _userPreferenceRepository.GetById(userPreference.Id);
            //userPreferenceRef = userPreference;
            
            return _userPreferenceRepository.Update(userPreference);
        }

        public void UpdateUserStatut(int idUser, string statut)
        {
            UserPreference userPreference = _userPreferenceRepository.GetByIdUser(idUser);
        }



    }
}


