using Budget.MODEL.Dto;
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
    [Route("api/plan-poste-references")]
    public class PlanPosteReferenceController : Controller
    {
        private readonly IPlanPosteReferenceService _planPosteReferenceService;
            
        public PlanPosteReferenceController(
            IPlanPosteReferenceService planPosteReferenceService
            )
        {

            _planPosteReferenceService = planPosteReferenceService;
        }


        [HttpGet("user-groups/{idUserGroup}/reference-table/{idReferenceTable}/postes/{idPoste}/plan-poste-reference-list")]
        public IActionResult GetPlanPosteReferenceList(int idUserGroup, int idReferenceTable, int idPoste)
        {
            return Ok(_planPosteReferenceService.GetListForSelectGroup(idUserGroup, idReferenceTable, idPoste));
        }

    }

}
