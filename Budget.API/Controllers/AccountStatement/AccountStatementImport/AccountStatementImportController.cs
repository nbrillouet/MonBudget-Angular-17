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

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/account-statement-import")]
    public class AccountStatementImportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAccountStatementImportService _accountStatementImportService;
        private readonly IAccountStatementImportFileService _accountStatementImportFileService;
        private readonly FilterService _filterService;

        public AccountStatementImportController(
            IAccountStatementImportService accountStatementImportService,
            IUserService userService,
            IAccountStatementImportFileService accountStatementImportFileService,
            IMapper mapper,
            FilterService filterService
            )
        {
            _mapper = mapper;
            _accountStatementImportService = accountStatementImportService;
            _userService = userService;
            _accountStatementImportFileService = accountStatementImportFileService;
            _filterService = filterService;
        }

        [HttpGet]
        [Route("list/user/{idUser}/asi-by-bank-agency")]
        public IActionResult GetByBankAgency(int idUser)
        {
            var result = _accountStatementImportService.GetAsiForList(idUser);

            return Ok(result);
        }

        [HttpGet]
        [Route("{idImport}/asi-detail")]
        public IActionResult getById(int idImport)
        {
            var pagedList = _accountStatementImportService.GetByIdForData(idImport);

            return Ok(pagedList);
        }

        [HttpGet]
        [Route("imports/{idImport}/account-statement-import")]
        public IActionResult GetAsiDto(int idImport)
        {
            var asiDto = _accountStatementImportService.GetForDetailById(idImport);
            return Ok(asiDto);
        }

        [HttpPost]
        [Route("users/{idUser}/upload-file")]
        public IActionResult UploadFile(int idUser,  IFormFile file)
        {
            var files = Request.Form.Files;
            file = files[0];

            var user = _userService.GetById(idUser);

            if (user == null)
                return BadRequest("Could not find user");

            //var file = asifuDto.File;

            AsifGroupByAccounts asifGroupByAccounts = new AsifGroupByAccounts();
            if (file.Length > 0)
            {
                try
                {
                    StreamReader csvreader = new StreamReader(file.OpenReadStream()); //, Encoding.GetEncoding(1252));
                    AccountStatementImport accountStatementImport = _accountStatementImportService.ImportFile(csvreader, user);
                    asifGroupByAccounts = _accountStatementImportFileService.GetListDto(accountStatementImport.Id);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Erreur lors du chargement de fichier", e.Message.ToString());
                    return BadRequest(ModelState);
                }
            }

            return Ok(asifGroupByAccounts);
        }

        //[HttpPost]
        //[Route("users/{idUser}/upload-file")]
        //public async Task<IActionResult> UploadFile(int idUser, AsiForUploadDto asifuDto)
        //{

        //    var user = await _userService.GetByIdAsync(idUser);

        //    if (user == null)
        //        return BadRequest("Could not find user");

        //    var file = asifuDto.File;

        //    AsifGroupByAccounts asifGroupByAccounts = new AsifGroupByAccounts();
        //    if (file.Length > 0)
        //    {
        //        try
        //        {
        //            StreamReader csvreader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding(1252));
        //            AccountStatementImport accountStatementImport = _accountStatementImportService.ImportFile(csvreader, user);
        //            asifGroupByAccounts = _accountStatementImportFileService.GetListDto(accountStatementImport.Id);
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("Erreur lors du chargement de fichier", e.Message.ToString());
        //            return BadRequest(ModelState);
        //        }
        //    }

        //    return Ok(asifGroupByAccounts);
        //}

        [HttpPost]
        [Route("delete-asi-list")]
        public IActionResult DeleteList([FromBody] List<int> idAsiList)
        {
            try
            {
                _accountStatementImportService.DeleteList(idAsiList);
                return Ok("delete-asi-list-OK");
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


    }
}
