using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.API.Controllers.Referential
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/referential/operation-transverses")]
    public class OperationTransverseController : Controller
    {
        private IOperationTransverseService _operationTransverseService;

        public OperationTransverseController(
            IOperationTransverseService operationTransverseService
        )
        {
            _operationTransverseService = operationTransverseService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] OperationTransverse operationTransverse)
        {
            try
            {
                var result = _operationTransverseService.Add(operationTransverse);
                return Ok(operationTransverse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("user/{idUser}/select-type/{enumSelectType}/operation-transverse-select-list")]
        public IActionResult GetSelectList(int idUser, EnumSelectType enumSelectType)
        {
            var selectsDto = _operationTransverseService.GetSelectList(idUser, enumSelectType);

            return Ok(selectsDto);
        }
    }
}
