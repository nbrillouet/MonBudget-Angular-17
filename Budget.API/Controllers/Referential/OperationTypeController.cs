using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.API.Controllers.Referential
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/referential/operation-type")]
    public class OperationTypeController : Controller
    {
        private ReferentialService _referentialService;
        private IOperationTypeService _operationTypeService;
        private FilterService _filterService;


        public OperationTypeController(
            ReferentialService referentialService,
            IOperationTypeService operationTypeService,
            FilterService filterService
        )
        {
            _referentialService = referentialService;
            _operationTypeService = operationTypeService;
            _filterService = filterService;
        }

        [HttpPost]
        [Route("user-groups/{idUserGroup}/select-list")]
        public IActionResult GetSelectListByOperationTypeFamily(int idUserGroup, [FromBody] List<Select> operationTypeFamilies)
        {
            var results = _referentialService.OperationTypeService.GetSelectList(idUserGroup, operationTypeFamilies);
            return Ok(results);
        }

        [HttpGet]
        [Route("account/{idAccount}/movement/{idMovement}/operation-type-families/{idOperationTypeFamily}/select-type/{idSelectType}/select-list")]
        public IActionResult GetSelectList(int idAccount, int idMovement, int idOperationTypeFamily, int idSelectType)
        {
            var selectsDto = _referentialService.OperationTypeService.GetSelectList(idAccount, idMovement, idOperationTypeFamily, (EnumSelectType)idSelectType);

            return Ok(selectsDto);
        }


        [HttpPost]
        [Route("operation-type-table-filter")]
        public IActionResult getOtTableFilter([FromBody] FilterOtTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterOtTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("operation-type-table")]
        public IActionResult getForTable([FromBody] FilterOtTableSelected filter)
        {
           var pagedList = _operationTypeService.GetForTable(filter);

            return Ok(pagedList);

        }

        [HttpGet]
        [Route("{idOperationType}/users/{idUser}/detail")]
        public IActionResult GetOtDetail(int? idOperationType, int idUser)
        {
            var results = _operationTypeService.GetForDetail(idOperationType, idUser);
            return Ok(results);
        }

        [HttpPost]
        [Route("operation-type-detail-filter")]
        public IActionResult GetForDetailFilter([FromBody] OtForDetail otForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForOt(otForDetail));
        }

        [HttpPost]
        [Route("operation-type-save")]
        public IActionResult Save([FromBody] OtForDetail otForDetail)
        {
            var pagedList = _operationTypeService.Save(otForDetail);

            return Ok(pagedList);
        }

        //[HttpDelete]
        //[Route("{idOt}/delete")]
        //public IActionResult DeleteOtDetail(int idOt)
        //{
        //    try
        //    {
        //        var results = _operationTypeService.DeleteOtDetail(idOt);
        //        return Ok(results);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPost("operation-type-table-delete")]
        public IActionResult DeleteOtfTable([FromBody] List<int> listIdOtf)
        {
            try
            {
                _referentialService.OperationTypeService.Delete(listIdOtf);
                return Ok(true);
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

        //[HttpPost]
        //[Route("user-groups/{idUserGroup}/delete-operation-type-list")]
        //public IActionResult DeleteOtList(int idUserGroup, [FromBody] List<int> idOtList)
        //{
        //    try
        //    {
        //        _referentialService.OperationTypeService.DeleteOtList(idOtList, idUserGroup);
        //        return Ok("delete-operation-type-list-OK");
        //    }
        //    catch (BusinessException e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.BusinessExceptionMessages);
        //    }
        //    catch (Exception exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, exception);
        //    }
        //}

    }
}
