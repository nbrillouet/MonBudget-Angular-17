using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Budget.MODEL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Budget.MODEL.Dto;
using AutoMapper;
using System.Linq;
using Budget.SERVICE._Helpers;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Budget.MODEL.Enum;

namespace Budget.SERVICE
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        //private readonly IUserPreferenceService _userPreferenceService;
        private readonly IMailRegisterValidationService _mailRegisterValidationService;
        private readonly IMailPasswordRecoveryService _mailPasswordRecoveryService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IConfiguration _configuration;

        private readonly IAuthRepository _authRepository;

        public AuthService(
            IMapper mapper,
            IBusinessExceptionMessageService businessExceptionMessageService,
            IUserService userService,
            //IUserPreferenceService userPreferenceService,
            IMailRegisterValidationService mailRegisterValidationService,
            IMailPasswordRecoveryService mailPasswordRecoveryService,
            IConfiguration configuration,

            IAuthRepository authRepository
            
        )
        {
            _mapper = mapper;
            _businessExceptionMessageService = businessExceptionMessageService;
            _userService = userService;
            _mailRegisterValidationService = mailRegisterValidationService;
            _mailPasswordRecoveryService = mailPasswordRecoveryService;
            _configuration = configuration;

            _authRepository = authRepository;
        }

        public UserForAuth Login(string username, string password)
        {
            User user = _userService.GetByUsername(username);
            CheckForLogin(user, password);


            UserForAuth userForAuth = new UserForAuth { 
                Id = user.Id,
                Role = user.Role,
                IdUserGroup = user.IdUserGroup,
                Token = GetToken(user)
            };
            return userForAuth;
        }

        private string GetToken(User user)
        {
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GroupSid, user.IdUserGroup.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Locality, user.UserPreference.Language)
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public User Register(UserForRegister userForRegister)
        {
            userForRegister.UserName = userForRegister.UserName.ToLower();
            User user = _mapper.Map<User>(userForRegister);
            CheckForRegister(user, userForRegister.Password);

            user = CreatePasswordHash(user, userForRegister.Password);
            user.ActivationCode = GetActivationCode();
            user.ActivationIsConfirmed = false;
            user.Role = EnumRole.User.ToString();
            //TODO register userpreference
            //user.AvatarUrl = _configuration.GetSection("Items:AvatarDefault").Value;
            user.IdGMapAddress = 1;
            user.DateCreated = DateTime.Now;

            user = _userService.Register(user);

            //Envoi du mail validation
            _mailRegisterValidationService.SendRegisterValidationMail(user);

            //Enregistrement date et heure d'envoi du mail validation
            UserForDetail userForDetail = _userService.GetForDetailById(user.Id);
            userForDetail.ActivationDateSend = DateTime.Now;
            _userService.Save(userForDetail);

            return _mapper.Map<User>(userForDetail);
        }

        public User ActivateAccount(string activationCode)
        {
            var user = _userService.ActivateAccount(activationCode);
            return user;
        }
        
        public void PasswordRecovery(string mail)
        {
            User user = _userService.GetByMail(mail);
            CheckForPasswordRecovery(user);

            //Envoi du mail de password recovery
            _mailPasswordRecoveryService.SendPasswordRecoveryMail(user);
        }

        public UserForRegister GetUserEncrypt(string userId)
        {
            UserForRegister userForRegister=null;
            int idUser=0;
            userId = HELPER.CryptoHelper.Decrypt(userId);
            if (userId != null)
                int.TryParse(userId,out idUser);

            if (idUser != 0)
            {
                var user = _userService.GetById(idUser);
                userForRegister = _mapper.Map<UserForRegister>(user);
            }

            return userForRegister;
        }

        public bool ChangePassword(UserForPasswordChange userForPasswordChange)
        {
            CheckForChangePassword(userForPasswordChange);

            int idUser = DecryptIdUser(userForPasswordChange.IdCrypted);
            var user = _userService.GetById(idUser);
            user = CreatePasswordHash(user, userForPasswordChange.Password);

            _userService.UpdatePassword(user);

            return true;
        }

        //private bool UserExists(string mail)
        //{
        //    return _authRepository.UserExists(mail);
        //}

        private void CheckForRegister(User user, string password)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();

            //Recherche si utilisateur existe deja (verification adresse mail)
            if (_userService.GetByMail(user.Email)!=null)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_000));

            //Recherche si utilisateur existe deja (verification username)
            if (_userService.GetByUsername(user.UserName)!=null)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_007));

            //password doit être superieur a 8 caracteres
            if (password.Length < 8)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_001));
            }

            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private void CheckForLogin(User user, string password)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si utilisateur a été trouvé
            if (user==null)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_002));
            else
            {
                //Recherche si mot de passe correct
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_008));

                //Recherche si utilisateur a son compte validé isMailConfirmed
                if (!user.ActivationIsConfirmed)
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_006));
            }

            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private void CheckForPasswordRecovery(User user)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si utilisateur existe (adresse mail existe en base)
            if (user==null)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_003));


            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private void CheckForChangePassword(UserForPasswordChange userForPasswordChange)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si utilisateur existe (basé sur id)
            int idUser = DecryptIdUser(userForPasswordChange.IdCrypted);
            //userForPasswordChange.IdCrypted = 
            //verification si user existe en base (basé sur id crypté)
            if (idUser != 0)
            {
                var user = _userService.GetById(idUser);
                if(user==null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_004));
                }
                else
                {
                    //verification que le user a le meme mail que celui fourni
                    if(user.Email!= userForPasswordChange.Email)
                    {
                        businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_005));
                    }
                    //password doit être superieur a 8 caracteres
                    if (userForPasswordChange.Password.Length < 8)
                    {
                        businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_001));
                    }
                }
            }
            else
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_AUTH_ERR_004));
            }


            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private User CreatePasswordHash(User user, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return user; 
        }

        private string GetActivationCode()
        {
            var user = _userService.GetLast();
            var code = user.Id.ToString();

            return $"{StringHelper.RandomString(10)}{code}";
        }

        private int DecryptIdUser(string idUserCrypted)
        {
            int idUser = 0;
            idUserCrypted = HELPER.CryptoHelper.Decrypt(idUserCrypted);
            if (idUserCrypted != null)
                int.TryParse(idUserCrypted, out idUser);

            return idUser;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

    }
}
