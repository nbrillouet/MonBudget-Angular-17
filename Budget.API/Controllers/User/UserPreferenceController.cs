using AutoMapper;
using Budget.MODEL.Database;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/user/{idUser}/preference")]
    public class UserPreferenceController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserPreferenceService _userPreferenceService;
        private readonly IMapper _mapper;

        public UserPreferenceController(
            IUserService userService,
            IUserPreferenceService userPreferenceService,
            IMapper mapper)
        {
            _userService = userService;
            _userPreferenceService = userPreferenceService;
            _mapper = mapper;
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteShortcut(int idUser, int id)
        //{
        //    var user = await _userService.GetByIdAsync(idUser);
        //    if (user == null)
        //        return BadRequest($"Could not find user id: {idUser}");

        //    var shortcut = await _shortcutService.GetByIdAsync(id);
        //    if (shortcut == null)
        //        return BadRequest($"Could not find shortcut id: {id}");

        //    _shortcutService.Delete(shortcut);

        //    return Ok();
        //}

        [HttpPost()]
        [Route("update")]
        public IActionResult UpdateUserPreference(int idUser, [FromBody] UserPreference userPreference)
        {

            userPreference = _userPreferenceService.Update(userPreference);

            return Ok(userPreference);

            //var user = _userService.GetById(idUser);
            //if (user == null)
            //    return BadRequest($"Could not find user id: {idUser}");

            //var shortcut = new UserShortcut();
            //_mapper.Map(userShortcutDto, shortcut);
            //shortcut.IdUser = idUser;
            //shortcut.Icon = shortcut.Icon == "false" ? null : shortcut.Icon;
            //shortcut = await _shortcutService.Create(shortcut);

            //return Ok(shortcut);
        }
    }

}
