using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Budget.SERVICE;
using Budget.MODEL;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Budget.MODEL.Dto;

using System.Web;

namespace Budget.API.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IConfiguration _config;

        private readonly IMapper _mapper;
        //private readonly IHostingEnvironment _hostingEnvironment;
        //private readonly IMailRegisterValidationService _mailRegisterValidationService;
        private readonly IAccountService _accountService;

        public AuthController(
            IAuthService authService,
            IConfiguration config,
            IMapper mapper,
            //IHostingEnvironment hostingEnvironment,
            //IMailRegisterValidationService mailRegisterValidationService,
            IAccountService accountService)
        {
            _authService = authService;
            _config = config;
            _mapper = mapper;
            //_mailRegisterValidationService = mailRegisterValidationService;
            _accountService = accountService;
            //_hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserForRegister userForRegister)
        {
            try
            {
                var user = _authService.Register(userForRegister);
                //var user = new User
                //{
                //    MailAddress = "nico_brillouet@hotmail.com",
                //    UserName = "nico"
                //};

                
                return Ok(user);
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpGet("account-activation/{activationCode}")]
        public IActionResult AccountActivation(string activationCode)
        {
            try
            {
                var user = _authService.ActivateAccount(activationCode);

                return Ok(user);
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpGet("account-password-recovery/{mail}")]
        public IActionResult AccountPasswordRecovery(string mail)
        {
            try
            {
                _authService.PasswordRecovery(mail);

                return Ok();
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        //[HttpGet("user-encrypt/{user}")]
        //public IActionResult GetUserEncrypt(string user)
        //{
        //    try
        //    {
        //        return Ok(_authService.GetUserEncrypt(System.Uri.UnescapeDataString(user)));
        //    }
        //    catch (BusinessException e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
        //    }
        //    catch (Exception exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, exception);
        //    }
        //}

        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] UserForPasswordChange userForPasswordChange)
        {
            try
            {
                return Ok(_authService.ChangePassword(userForPasswordChange));
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody]UserForLoginDto userForLoginDto)
        {
            try
            {
                var userAuth = _authService.Login(userForLoginDto.Username, userForLoginDto.Password);
                return Ok(userAuth);
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        
        //private string GetToken(UserForDetailDto userForDetail)
        //{
        //    //generate token
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier,userForDetail.Id.ToString()),
        //            new Claim(ClaimTypes.Name, userForDetail.UserName),
        //            new Claim(ClaimTypes.GroupSid, userForDetail.IdUserGroup.ToString()),
        //            new Claim(ClaimTypes.Role, userForDetail.Role),
        //            new Claim(ClaimTypes.Locality, "fr")
        //        }),

        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha512Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return tokenString;
        //}


        //if (userRetrieve == null)
        //{
        //    ModelState.AddModelError("Login Error","Incorrect username or password");
        //    return BadRequest(ModelState);
        //    // return Unauthorized();
        //}
        ////generate token
        //var tokenHandler = new JwtSecurityTokenHandler();

        //var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,userRetrieve.Id.ToString()),
        //        new Claim(ClaimTypes.Name, userRetrieve.UserName),
        //        new Claim(ClaimTypes.Locality, "fr")
        //    }),

        //    Expires = DateTime.Now.AddDays(1),
        //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //        SecurityAlgorithms.HmacSha512Signature)
        //};

        //var token = tokenHandler.CreateToken(tokenDescriptor);
        //var tokenString = tokenHandler.WriteToken(token);

        //var user = _mapper.Map<UserForConnection>(userRetrieve);
        //user.Token = tokenString;
        //return Ok(user);
    }
}