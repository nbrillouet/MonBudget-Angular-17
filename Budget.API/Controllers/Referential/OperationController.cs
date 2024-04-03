using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Budget.API.Controllers.Referential
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/referential/operation")]
    public class OperationController : Controller
    {
        private readonly ReferentialService _referentialService;
        private readonly FilterService _filterService;

        public OperationController(
            ReferentialService referentialService,
            FilterService filterService
        )
        {
            _referentialService = referentialService;
            _filterService = filterService;
        }

        [HttpGet]
        [Route("user-groups/{idUserGroup}/operation-methods/{idOperationMethod}/operation-types/{idOperationType}/select-type/{enumSelectType}/operations")]
        public IActionResult GetSelectList(int idUserGroup, int idOperationMethod, int idOperationType, EnumSelectType enumSelectType)
        {
            var selectsDto = _referentialService.OperationService.GetSelectList(idUserGroup, idOperationMethod, idOperationType, enumSelectType);

            return Ok(selectsDto);
        }

        //[HttpPost]
        //[Route("user-groups/{idUserGroup}/select-list")]
        //public IActionResult GetSelectListByOperationMethods(int idUserGroup, [FromBody] List<SelectDto> operationMethods)
        //{
        //    var results = _referentialService.OperationService.GetSelectList(idUserGroup, operationMethods);
        //    return Ok(results);
        //}

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Operation operation)
        {
            try
            {
                return Ok(_referentialService.OperationService.Save(operation));
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages); // Content(HttpStatusCode.BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        /*-------------------------------------*/
        [HttpPost]
        [Route("operation-table")]
        public IActionResult GetOTable([FromBody] FilterOperationTableSelected filter)
        {
            var pagedList = _referentialService.OperationService.GetForTable(filter);

            return Ok(pagedList);
        }

        [HttpPost]
        [Route("operation-table-filter")]
        public IActionResult GetOTableFilter([FromBody] FilterOperationTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterOperationTable(filter);

            return Ok(result);
        }
        

        [HttpGet]
        [Route("{idOperation}/user/{idUser}/operation-detail")]
        public IActionResult GetForDetail(int? idOperation, int idUser)
        {
            var results = _referentialService.OperationService.GetForDetail(idOperation, idUser);
            return Ok(results);
        }

        [HttpPost]
        [Route("operation-detail-filter")]
        public IActionResult GetForDetailFilter([FromBody] OperationForDetail operationForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForOperation(operationForDetail));
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveDetail([FromBody] OperationForDetail operationForDetail)
        {
            var pagedList = _referentialService.OperationService.SaveDetail(operationForDetail);

            return Ok(pagedList);

        }

        [HttpPost]
        [Route("operation-table-delete")]
        public IActionResult DeleteOperations([FromBody] List<int> idOperationList)
        {
            try
            {
                _referentialService.OperationService.Delete(idOperationList);
                return Ok("delete-operations-OK");
            }
            catch (BusinessException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        //[HttpDelete]
        //[Route("{idOperation}/delete")]
        //public IActionResult DeleteDetail(int idOperation)
        //{

        //    try
        //    {
        //        var results = _referentialService.OperationService.DeleteDetail(idOperation);
        //        return Ok(results);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
    }

}
