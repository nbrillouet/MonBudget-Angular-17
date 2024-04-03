using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Budget.SERVICE.GMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.SERVICE._Helpers;
using System.IO;
using Microsoft.AspNetCore.Http;
using Budget.MODEL.Enum;
using Budget.MODEL.Database;

namespace Budget.SERVICE
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountService _userAccountService;
        private readonly IUserEventService _userEventService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IGMapAddressService _gMapAddressService;
        private readonly IUserPreferenceService _userPreferenceService;
        private readonly IMapper _mapper;
       

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IUserAccountService userAccountService,
            IUserEventService userEventService,
            IBusinessExceptionMessageService businessExceptionMessageService,
            IGMapAddressService gMapAddressService,
            IUserPreferenceService userPreferenceService
            )
        {
            _userRepository = userRepository;
            _userAccountService = userAccountService;
            _userEventService = userEventService;
            _mapper = mapper;
            _businessExceptionMessageService = businessExceptionMessageService;
            _gMapAddressService = gMapAddressService;
            _userPreferenceService = userPreferenceService;
        }

        public PagedList<UserForTableDto> GetUserTable(FilterUserTableSelected filter)
        {
            var pagedList = _userRepository.GetUserTable(filter);

            var result = new PagedList<UserForTableDto>(_mapper.Map<List<UserForTableDto>>(pagedList.Datas), pagedList.Pagination);

            return result;
        }

        public UserForDetail GetForDetailById(int id)
        {
            var user =  _userRepository.GetForDetailById(id);

            var userForDetailDto = _mapper.Map<UserForDetail>(user);
            userForDetailDto.BankAgencies = _userAccountService.GetBankAgencies(id);
            userForDetailDto.UserEvents = _userEventService.Get(userForDetailDto);
            userForDetailDto.UserPreference = _userPreferenceService.Get(user.IdUserPreference.Value);
            userForDetailDto.GMapAddress = _gMapAddressService.GetById(user.IdGMapAddress.Value, userForDetailDto.UserPreference.Language.ToEnum<EnumLanguage>());

            return userForDetailDto;
        }

        public UserForLogged GetForLoggedById(int id)
        {
            var userForDetail = GetForDetailById(id);

            var userForLogged = _mapper.Map<UserForLogged>(userForDetail);

            return userForLogged;
        }

        public UserForGroupDto GetForUserGroup(int id)
        {
            var user = _userRepository.GetById(id);

            return _mapper.Map<UserForGroupDto>(user);
        }

        public UserPreference GetUserPreference(int idUser)
        {
            var userPreference = _userRepository.GetUserPreference(idUser);

            return userPreference;

        }

        //public async Task<User> GetByIdAsync(int id)
        //{
        //    var user = await _userRepository.GetByIdAsync(id);

        //    return user;
        //}

        public User GetLast()
        {
            return _userRepository.GetLast();
        }
        
        public User ActivateAccount(string activationCode)
        {
            var user = _userRepository.GetByActivationCode(activationCode);
            CheckForActivateAccount(user);

            // Mettre à jour l'activation Code à ACTIVATED
            user.ActivationCode = EnumActivationCode.Active.ToString();
            // Mettre à jour le flag mail à true
            user.ActivationIsConfirmed = true;
            //mettre activation_date_send a null
            user.ActivationDateSend = null;
            // Creation d'un nouveau user group
            user.IdUserGroup = _userRepository.GetNewUserGroup();

            user = _userRepository.Update(user);

            //Ajout du referentiel pour l'utilisateur
            //_referentialService.OperationService.InitUser(user);

            return user;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public User GetByMail(string mail)
        {
            return _userRepository.GetByMail(mail);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public List<User> GetByIdUserGroup(int idUserGroup)
        {
            return _userRepository.GetByIdUserGroup(idUserGroup);
        }

        //public bool HasCompleteInformation(int idUser)
        //{
        //    var user = _userRepository.GetById(idUser);
        //    if (string.IsNullOrEmpty(user.FirstName))
        //        return false;
        //    if (string.IsNullOrEmpty(user.LastName))
        //        return false;
        //    if (string.IsNullOrEmpty(user.Gender))
        //        return false;
        //    if (!user.DateOfBirth.HasValue)
        //        return false;
        //    if (user.IdGMapAddress==1)
        //        return false;

        //    return true;
        //}
        public void UpdateAvatar(int idUser, IFormFile file, string savePath)
        {
            //if (!Directory.Exists(savePath))
            //{
            //    Directory.CreateDirectory(savePath);
            //}
            var savePath1 = Path.Combine(savePath, "wwwroot");
            var savePath2 = Path.Combine(Directory.GetParent(savePath).FullName, "Budget.SPA\\src");
            var fileName = $"assets/images/users/avatar/avatar_{idUser}.jpg";

            var path1 = Path.Combine(savePath1, fileName);
            var path2 = Path.Combine(savePath2, fileName);

            using (var stream = new FileStream(path1, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            using (var stream = new FileStream(path2, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var user = GetById(idUser);
            //TODO get avatar from userPreference
            //user.AvatarUrl = fileName;
            Update(user);

            //return fileName;
        }


        //public string UpdateUserPreference(int idUser, UserPreference userPreference)
        //{
        //    var user = GetById(idUser);
        //    var userPreference = _userPreferenceService.Get(user.IdUserPreference.Value);
        //    userPreference.Theme = theme;
        //    _userPreferenceService.Update(userPreference);

        //    return userPreference.Theme;
        //}

        public UserForDetail Save(UserForDetail userForDetail)
        {
            User user = CheckValues(userForDetail);

            return Save(user);
        }

        public User UpdatePassword(User user)
        {
            return Update(user);
        }

        public void Update(UserForDetail userForDetail)
        {
            User user = _userRepository.GetById(userForDetail.Id);
            user.FirstName = userForDetail.FirstName;
            user.LastName = userForDetail.LastName;
            user.UserName = userForDetail.UserName;
            user.IdGMapAddress = userForDetail.IdGMapAddress;
            user.DateOfBirth = userForDetail.DateOfBirth;

            Update(user);
        }

        public UserForLogged Update(UserForLogged userForLogged)
        {
            User user = _userRepository.GetById(userForLogged.Id);
            _mapper.Map<UserForLogged, User>(userForLogged, user);
            //user = _mapper.Map<User>(userForLogged);

            user = Update(user);

            return _mapper.Map<UserForLogged>(user);
        }

        public User Register(User user)
        {
            return _userRepository.Create(user);
        }



        private User CheckValues(UserForDetail userForDetail)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.F_BUS_ERR_002, true));
            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            User user = _mapper.Map<User>(userForDetail);
            
            //recuperation des champs passwords (pas envoyé au front/pas a modifier par le front)
            var technicalFields = GetTechnicalField(userForDetail.Id);  //GetTechnicalField(userForDetail.Id);
            user.ActivationCode = technicalFields.ActivationCode;
            user.ActivationDateSend = technicalFields.ActivationDateSend;
            user.ActivationIsConfirmed = technicalFields.ActivationIsConfirmed;
            user.DateCreated = technicalFields.DateCreated;
            user.DateLastActive = technicalFields.DateLastActive;
            user.IdUserGroup = technicalFields.IdUserGroup;
                
            user.PasswordHash = technicalFields.PasswordHash;
            user.PasswordSalt = technicalFields.PasswordSalt;
            user.Role = technicalFields.Role;

            return user;
        }

        private UserForTechnicalField GetTechnicalField(int idUser)
        {
            var user = _userRepository.GetForNoTrace(idUser);
            return _mapper.Map<UserForTechnicalField>(user);
        }

        private UserForDetail Save(User user)
        {
            user = user.Id == 0
                ? Create(user)
                : Update(user);

            UserForDetail userForDetail = GetForDetailById(user.Id);

            return userForDetail;
        }

        private User Create(User user)
        {
            return null;
        }

        private User Update(User user)
        {
            return _userRepository.Update(user);
        }

        private void CheckForActivateAccount(User user)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si utilisateur est trouvé par son code activation
            if (user==null)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_USER_ERR_000));
            else
            {
                //Recherche si la date denvoi d'activation est > à 24h
                if(user.ActivationDateSend.Value.AddDays(1) < DateTime.Now)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_USER_ERR_001));
                    //Suppression du compte
                    _userRepository.Delete(user);
                }
                   
            }


            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }

        }
    }

}
