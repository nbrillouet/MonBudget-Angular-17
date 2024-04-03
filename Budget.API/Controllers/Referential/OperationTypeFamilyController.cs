using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
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
    [Route("api/referential/operation-type-family")]
    public class OperationTypeFamilyController : Controller
    {
        private ReferentialService _referentialService;
        private FilterService _filterService;

        public OperationTypeFamilyController(
            ReferentialService referentialService,
            FilterService filterService
        )
        {
            _referentialService = referentialService;
            _filterService = filterService;
        }

        [HttpGet]
        [Route("user-groups/{idUser}/movements/{idMovement}/select-type/{idSelectType}/select-list")]
        public IActionResult GetSelectList(int idUserGroup, int idMovement, int idSelectType)
        {
            var selectsDto = _referentialService.OperationTypeFamilyService.GetSelectList(idUserGroup, (EnumMovement)idMovement,(EnumSelectType)idSelectType);

            return Ok(selectsDto);
        }

        [HttpGet]
        [Route("operation-method/{idOperationMethod}/select-type/{idSelectType}/select-list")]
        public IActionResult GetSelectCodeList(int idOperationMethod, int idSelectType)
        {
            var selectsDto = _referentialService.OperationTypeFamilyService.GetSelectCodeList(idOperationMethod, (EnumSelectType)idSelectType);

            return Ok(selectsDto);
        }

        [HttpGet]
        [Route("user-groups/{idUser}/select-group-list")]
        public IActionResult GetSelectGroupList(int idUserGroup)
        {
            var selectsDto = _referentialService.OperationTypeFamilyService.GetSelectGroup(idUserGroup);

            return Ok(selectsDto);
        }

        [HttpPost]
        [Route("operation-type-family-table-filter")]
        public IActionResult getOtfTableFilter([FromBody] FilterOtfTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterOtfTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("operation-type-family-table")]
        public IActionResult getForTable([FromBody] FilterOtfTableSelected filter)
        {
            var pagedList = _referentialService.OperationTypeFamilyService.GetForTable(filter);

            return Ok(pagedList);
        }

        [HttpGet]
        [Route("{idOperationTypeFamily}/user/{idUser}/operation-type-family-detail")]
        public IActionResult GetForDetail(int? idOperationTypeFamily, int idUser)
        {
            var results = _referentialService.OperationTypeFamilyService.GetForDetail(idOperationTypeFamily, idUser);
            return Ok(results);
        }

        [HttpPost]
        [Route("operation-type-family-detail-filter")]
        public IActionResult GetForDetailFilter([FromBody] OtfForDetail otfForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForOtf(otfForDetail));
        }

        [HttpPost]
        [Route("operation-type-family-save")]
        public IActionResult Save([FromBody] OtfForDetail otfForDetailDto)
        {
            var result = _referentialService.OperationTypeFamilyService.Save(otfForDetailDto);
            return Ok(result);
        }

        [HttpPost("operation-type-family-table-delete")]
        public IActionResult DeleteOtfTable([FromBody] List<int> listIdOtf)
        {
            try
            {
                _referentialService.OperationTypeFamilyService.Delete(listIdOtf);
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
        //[Route("user-groups/{idUserGroup}/delete-operation-type-family-list")]
        //public IActionResult DeleteList(int idUserGroup, [FromBody] List<int> idOtfList)
        //{
        //    try
        //    {
        //        _referentialService.OperationTypeFamilyService.DeleteList(idOtfList, idUserGroup);
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

        //[HttpDelete]
        //[Route("{idOtf}/delete")]
        //public IActionResult DeleteOtfDetail(int idOtf)
        //{
        //    try
        //    {
        //        var results = _operationTypeFamilyService.DeleteOtfDetail(idOtf);
        //        return Ok(results);
        //    }
        //    catch(Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

    }

}
