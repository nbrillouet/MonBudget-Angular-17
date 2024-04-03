using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Budget.API.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Budget.HELPER;
using System.IO;
using Budget.MODEL.Database;
using System.Net;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserAccountService _userAccountService;
        private IUserPreferenceService _userPreferenceService;
        private readonly IMapper _mapper;
        private readonly FilterService _filterService;

        public UserController(
            IUserService userService, 
            IMapper mapper,
            FilterService filterService,
            IUserAccountService userAccountService,
            IUserPreferenceService userPreferenceService
            )
        {
            _mapper = mapper;
            _userService = userService;
            //_cloudinaryConfig = cloudinaryConfig;

            //Account acc = new Account(
            //    CryptoHelper.Decrypt(_cloudinaryConfig.Value.CloudName),
            //    CryptoHelper.Decrypt(_cloudinaryConfig.Value.ApiKey),
            //    CryptoHelper.Decrypt(_cloudinaryConfig.Value.ApiSecret));

            //_cloudinary = new Cloudinary(acc);
            _filterService = filterService;
            _userAccountService = userAccountService;
            _userPreferenceService = userPreferenceService;
        }

        [HttpPost]
        [Route("table-filter")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserTableFilter([FromBody] FilterUserTableSelected filter)
        {
            var toto = HttpContext.User.Claims;
            var result = _filterService.FilterTableService.GetFilterUserTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("filter")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserTable([FromBody] FilterUserTableSelected filter)
        {
            var pagedList = _userService.GetUserTable(filter);

            return Ok(pagedList);
        }

        
        [HttpGet("{id}/user-detail", Name = "GetUser")]
        public IActionResult GetForDetail(int id)
        {
            var userForDetailDto =  _userService.GetForDetailById(id);

            return Ok(userForDetailDto);
        }

        [HttpGet("{id}/user-logged")]
        public IActionResult GetForLogged(int id)
        {
            var userForLogged = _userService.GetForLoggedById(id);

            return Ok(userForLogged);
        }
        //[HttpGet("{id}", Name = "GetUser")]
        //public async Task<IActionResult> GetUser(int id)
        //{
        //    var user = await _userService.GetById(id);
        //    //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

        //    return Ok(user);
        //}

        [HttpPost("save-user-for-detail")]
        public IActionResult SaveUserForDetail([FromBody] UserForDetail userForDetailedDto)
        {
            try
            {
                return Ok(_userService.Save(userForDetailedDto));
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        //[HttpPut("{id}/update")]
        //public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForDetail userForDetailedDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        //    var user = await _userService.GetByIdAsync(id);

        //    if (user == null)
        //        return NotFound($"Could not find user with an ID of {id}");

        //    if (currentUserId != user.Id)
        //        return Unauthorized();

        //    //_mapper.Map(userForDetailedDto, user);

        //    _userService.Update(userForDetailedDto);

        //    return NoContent();
        //}

        [HttpPut("{id}/update-for-logged")]
        public IActionResult UpdateUseForLogged(int id, [FromBody] UserForLogged userForLogged)
        {

            var result = _userService.Update(userForLogged);

            return Ok(result);
        }

        [HttpPut]
        [Route("{idUser}/avatar")]
        public IActionResult UpdateUserStatut(int idUser, string statut)
        {
            try
            {
                _userPreferenceService.UpdateUserStatut(idUser, statut);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("{idUser}/avatar")]
        public IActionResult UpdateAvatar(int idUser, [FromForm] IFormFile file)
        {
            var files = Request.Form.Files;
            file = files[0];
            var savePath = Directory.GetCurrentDirectory();

            try
            {
                _userService.UpdateAvatar(idUser, file, savePath);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


        [HttpPut("{idUser}/user-preference-update")]
        public IActionResult UpdateUserPreference(int idUser, [FromBody] UserPreference userPreference)
        {

            var result = _userPreferenceService.Update(userPreference);

            return Ok(result);
        }

        //[HttpPost]
        //[Route("{idUser}/avatar")]
        //public async Task<IActionResult> AddAvatar(int idUser, UserForAvatarCreationDto avatarDto)
        //{
        //    var user = await _userService.GetByIdAsync(idUser);

        //    if (user == null)
        //        return BadRequest("Could not find user");


        //    //ajout de l'avatar dans Cloudinary
        //    var file = avatarDto.File;

        //    var uploadResult = new ImageUploadResult();

        //    if (file.Length > 0)
        //    {
        //        using (var stream = file.OpenReadStream())
        //        {
        //            var uploadParams = new ImageUploadParams()
        //            {
        //                File = new FileDescription(file.Name, stream)
        //                //Transformation = new Transformation().Width(250).Height(250).Crop("fill").Gravity("face")
        //            };

        //            uploadResult = _cloudinary.Upload(uploadParams);
        //        }
        //    }

        //    //suppression de l'ancien avatar dans Cloudinary
        //    var deleteParams = new DeletionParams(user.IdAvatarCloud);
        //    var result = _cloudinary.Destroy(deleteParams);

        //    //maj bdd
        //    avatarDto.AvatarUrl = uploadResult.Uri.ToString();
        //    avatarDto.IdAvatarCloud = uploadResult.PublicId;

        //    _mapper.Map(avatarDto, user);
        //    //user = _mapper.Map<User>(avatarDto);

        //    _userService.Update(user);

        //    return CreatedAtRoute("GetUser", new { id = user.Id }, user);

        //}

        ///// <summary>
        ///// Rechercher les banques + comptes liés aux banque pour un utilisateurs
        ///// </summary>
        ///// <param name="idUser"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("{idUser}/bankAgencies")]
        //public IActionResult GetBankAgencies(int idUser)
        //{
        //    var bankAgencies = _userAccountService.GetBankAgencies(idUser);

        //    return Ok(bankAgencies);
        //}
    }
}