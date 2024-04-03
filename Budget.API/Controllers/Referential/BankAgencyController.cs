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
    [Route("api/referential/bank-agencies")]
    public class BankAgencyController : Controller
    {
        private IBankAgencyService _bankAgencyService;

        public BankAgencyController(
            IBankAgencyService bankAgencyService
        )
        {
            _bankAgencyService = bankAgencyService;
        }

        [HttpGet("bank-sub-families/{idBankSubFamily}/select-list")]
        public IActionResult GetSelectList(int idBankSubFamily)
        {
            var selectListDto = _bankAgencyService.GetSelectList(idBankSubFamily);

            return Ok(selectListDto);
        }
    }
}


