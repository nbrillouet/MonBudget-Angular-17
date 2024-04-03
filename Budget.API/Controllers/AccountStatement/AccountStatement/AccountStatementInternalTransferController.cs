using Budget.MODEL.Filter;
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
    [Route("api/account-statement-internal-transfers")]
    public class AccountStatementInternalTransferController : Controller
    {
        private readonly IAccountStatementService _accountStatementService;
        private readonly FilterService _filterService;

        public AccountStatementInternalTransferController(
            IAccountStatementService accountStatementService,
            FilterService filterService

            )
        {
            _accountStatementService = accountStatementService;
            _filterService = filterService;
        }

        [HttpPost]
        [Route("list-filter")]
        public IActionResult getAsInternalTransfer([FromBody] FilterAsTableSelected filter)
        {
            var result = _accountStatementService.GetAsInternalTransfer(filter);

            return Ok(result);
        }

        //[HttpPost]
        //[Route("filter")]
        //public IActionResult getAsTable([FromBody] FilterAsTableSelected filter)
        //{
        //    var pagedList = _accountStatementService.GetAsTable(filter);

        //    return Ok(pagedList);

        //}
        [HttpGet]
        [Route("check-orphan")]
        public IActionResult CheckAsInternalTransferOrphan()
        {
             _accountStatementService.CheckAsInternalTransferOrphan(2);

            return Ok(null);
        }




    }
}

