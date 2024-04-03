using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Budget.MODEL;
using AutoMapper;
using Budget.MODEL.Dto;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/users/{idUser}/shortcuts")]
    public class ShortcutController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserShortcutService _shortcutService;
        private readonly IMapper _mapper;

        public ShortcutController(
            IUserService userService,
            IUserShortcutService shortcutService,
            IMapper mapper)
        {
            _userService = userService;
            _shortcutService = shortcutService;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShortcut(int idUser, int id)
        {
            var user = _userService.GetById(idUser);
            if (user == null)
                return BadRequest($"Could not find user id: {idUser}");

            var shortcut = _shortcutService.GetById(id);
            if(shortcut == null)
                return BadRequest($"Could not find shortcut id: {id}");

            _shortcutService.Delete(shortcut);

            return Ok();
        }

        [HttpPost()]
        public IActionResult AddShortcut(int idUser, [FromBody] UserShortcutDto userShortcutDto)
        {
            var user = _userService.GetById(idUser);
            if (user == null)
                return BadRequest($"Could not find user id: {idUser}");

            var shortcut = new UserShortcut();
            _mapper.Map(userShortcutDto, shortcut);
            shortcut.IdUser = idUser;
            shortcut.Icon = shortcut.Icon == "false" ? null : shortcut.Icon;
            shortcut = _shortcutService.Create(shortcut);

            return Ok(shortcut);
        }
    }
}