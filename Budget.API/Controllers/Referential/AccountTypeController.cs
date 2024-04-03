using Budget.MODEL.Dto;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.API.Controllers.Referential
{

    [Authorize]
    [Produces("application/json")]
    [Route("api/referential/account-types")]
    public class AccountTypeController : Controller
    {
        private IAccountTypeService _accountTypeService;

        public AccountTypeController(
            IAccountTypeService accountTypeService
        )
        {
            _accountTypeService = accountTypeService;
        }

        [HttpGet("select-type/{idSelectType}/select-list")]
        public IActionResult GetSelectList(int idSelectType)
        {
            var selectListDto = _accountTypeService.GetSelectList((EnumSelectType)idSelectType);

            return Ok(selectListDto);
        }
    }
    
}
