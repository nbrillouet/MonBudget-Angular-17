using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Budget.SERVICE;
using Budget.MODEL;
using Budget.API.Helpers;
using System.IO;
using System.Text;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System.Security.Claims;

//var toto = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/account-statement-import-files")]
    public class AccountStatementImportFileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountStatementImportFileService _accountStatementImportFileService;
        private readonly FilterService _filterService;

        public AccountStatementImportFileController(
            IAccountStatementImportFileService accountStatementImportFileService,
            IMapper mapper,
            FilterService filterService)
        {
            _mapper = mapper;
            _accountStatementImportFileService = accountStatementImportFileService;
            _filterService = filterService;
        }

        [HttpPost]
        [Route("table-filter")]
        public IActionResult GetAsifTableFilter([FromBody] FilterAsifTableSelected filter)
        {
           var result = _filterService.FilterTableService.GetFilterAsifTable(filter);

           return Ok(result);
        }

        [HttpPost]
        [Route("filter")]
        public IActionResult GetAsifTable([FromBody] FilterAsifTableSelected filter)
        {
            var pagedList = _accountStatementImportFileService.GetAsifTable(filter);

            return Ok(pagedList);
        }

        
        [HttpGet]
        [Route("{idAsif}/asif-detail")]
        public IActionResult GetForDetail(int idAsif)
        {
            var results = _accountStatementImportFileService.GetForDetail(idAsif);
            return Ok(results);
        }

        [HttpPost]
        [Route("asif-detail-filter")]
        public IActionResult GetForDetailFilter([FromBody] AsifForDetail asifForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForAsif(asifForDetail));
        }

        [HttpPost]
        [Route("save-asif-detail")]
        public IActionResult SaveAsifDetail([FromBody] AsForDetail asForDetail)
        {
            try
            {
                return Ok(_accountStatementImportFileService.SaveAsifDetail(asForDetail));
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("imports/{idImport}/SaveInAccountStatement")]
        public IActionResult SaveInAccountStatement(int idImport)
        {
            try
            {
                return Ok(_accountStatementImportFileService.SaveInAccountStatement(idImport));
            }
            catch (BusinessException e)
            {

                return BadRequest(e.BusinessExceptionMessages);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("imports/{idImport}/IsSaveableInAccountStatement")]
        public IActionResult IsSaveableInAccountStatement(int idImport)
        {
            var result = _accountStatementImportFileService.IsSaveableInAccountStatement(idImport);

            return Ok(result);
        }

    }

    
}

