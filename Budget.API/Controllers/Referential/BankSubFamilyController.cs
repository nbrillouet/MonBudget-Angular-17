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
    [Route("api/referential/bank-sub-families")]
    public class BankSubFamilyController : Controller
    {
        private IBankSubFamilyService _bankSubFamilyService;

        public BankSubFamilyController(
            IBankSubFamilyService bankSubFamilyService
        )
        {
            _bankSubFamilyService = bankSubFamilyService;
        }

        [HttpGet("bank-families/{idBankFamily}/select-list")]
        public IActionResult GetSelectList(int idBankFamily)
        {
            var selectListDto = _bankSubFamilyService.GetSelectList(idBankFamily);

            return Ok(selectListDto);
        }
    }
}
