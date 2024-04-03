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
    [Route("api/referential/operation-methods")]
    public class OperationMethodController : Controller
    {
        private IOperationMethodService _operationMethodService;

        public OperationMethodController(
            IOperationMethodService operationMethodService
        )
        {
            _operationMethodService = operationMethodService;
        }

        [HttpGet]
        [Route("select-type/{idSelectType}/select-list")]
        public IActionResult GetOperationMethodSelectList(int idSelectType)
        {
            var selectsDto = _operationMethodService.GetSelectList((EnumSelectType)idSelectType);

            return Ok(selectsDto);

        }
    }
}
