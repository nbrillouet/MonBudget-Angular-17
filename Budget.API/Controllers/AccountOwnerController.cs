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
    [Route("api/account-owner")]
    public class AccountOwnerController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountOwnerController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("response-of-account-owner/{responseEncrypt}")]
        public IActionResult ResponseOfAccountOwner(string responseEncrypt)
        {
            var responseDecrypt = HttpUtility.UrlDecode(responseEncrypt);
            var accountOwnerDto = _accountService.ResponseOfAccountOwner(responseDecrypt);
            
            return Ok(accountOwnerDto);
        }

        [HttpPost]
        [Route("ask-account-owner")]
        public IActionResult AskAccountOwner([FromBody] AccountForDetail accountForDetail)
        {
            var result = _accountService.AskAccountOwner(accountForDetail);

            return Ok(result);
        }
    }
}
