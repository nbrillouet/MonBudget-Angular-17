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
    [Route("api/plan-postes")]
    public class PlanPosteController : Controller
    {

        private readonly IPlanPosteService _planPosteService;
        private readonly IPlanPosteDetailService _planPosteDetailService;
        private readonly IPlanPosteFrequencyService _planPosteFrequencyService;
        private readonly FilterService _filterService;


        public PlanPosteController(
            IPlanPosteService planPosteService,
            IPlanPosteDetailService planPosteDetailService,
            FilterService filterService
            )
        {
            _planPosteService = planPosteService;
            _planPosteDetailService = planPosteDetailService;
            _filterService = filterService;
        }

        [HttpPost]
        [Route("plan-poste-table-filter")]
        public IActionResult getPlanPosteTableFilter([FromBody] FilterPlanPosteTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterPlanPosteTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("plan-poste-table-data")]
        public IActionResult GetPlanPosteTableData([FromBody] FilterPlanPosteTableSelected filter)
        {
            var pagedList = _planPosteService.GetPlanPosteTable(filter);

            return Ok(pagedList);
        }

        [HttpPost("plan-poste-table-delete")]
        public IActionResult DeletePlanPosteTable([FromBody] List<int> listIdPlanPoste)
        {
            _planPosteDetailService.Delete(listIdPlanPoste);
            return Ok(true);
        }

        [HttpPost("plan-poste-detail-save")]
        public IActionResult SavePlanPosteDetail([FromBody] PlanPosteForDetail planPosteForDetail)
        {
            return Ok(_planPosteDetailService.Save(planPosteForDetail));
        }

        

        [HttpGet("{idPlanPoste}/plans/{idPlan}/postes/{idPoste}/plan-poste-detail")]
        public IActionResult GetPlanPosteDetail(int idPlanPoste, int idPlan, int idPoste)
        {
            if (idPlanPoste != 0)
            {
                return Ok(_planPosteDetailService.GetForDetailById(idPlanPoste));
            }
            return Ok(_planPosteDetailService.GetForDetailById(idPlan, idPoste));
        }

        [HttpPost]
        [Route("user-groups/{idUserGroup}/plan-poste-detail-filter")]
        public IActionResult GetForDetailFilter(int idUserGroup,[FromBody] PlanPosteForDetail planPosteForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForPlanPoste(idUserGroup, planPosteForDetail));
        }

        //[HttpGet("plans/{idPlan}/user-groups/{idUserGroup}/as-not-in-plan")]
        //public IActionResult GetAsNotInPlan(int idPlan, int idUserGroup)
        //{

        //    var asifForTableDto = _accountStatementPlanService.GetAsNotInPlan(idPlan, idUserGroup);

        //    return Ok(asifForTableDto);
        //}

        //[HttpGet("plan-poste-references/user-groups/{idUserGroup}/plan-postes/{idPlanPoste}/reference-table/{idReferenceTable}/postes/{idPoste}/combo-reference")]
        //public IActionResult GetPlanPosteReferenceDetail(int idUserGroup, int idPlanPoste, int idReferenceTable, int idPoste)
        //{
        //    return Ok(_planPosteReferenceService.GetListForComboByIdPlanPoste(idUserGroup, idPlanPoste, idReferenceTable, idPoste));
        //}

        //[HttpPost("plans/{idPlan}/plan-tracking")]
        //public IActionResult GetPlanTrackingByIdPlan(int idPlan, [FromBody] FilterPlanTracking filter)
        //{

        //    var planForDetailDto = _planTrackingService.Get(filter);

        //    return Ok(planForDetailDto);
        //}

        //[HttpPost]
        //[Route("plan-amounts/filter")]
        //public IActionResult GetPlanAmountTable([FromBody] FilterPlanAmount filter)
        //{
        //    var results = _planTrackingService.GetPlanAmountTable(filter);

        //    return Ok(results);

        //}

        [HttpGet("plan-poste-frequencies/plan-postes/{idPlanPoste}/is-annual-estimation/{isAnnualEstimation}")]
        public IActionResult GetPlanPosteFrequencies(int idPlanPoste, bool isAnnualEstimation)
        {
            return Ok(_planPosteFrequencyService.GetByIdPlanPoste(idPlanPoste));

            //if (idPlanPoste != 0)
            //{
            //    var toto = _planPosteFrequencyService.GetByIdPlanPoste(idPlanPoste);
            //    if ((toto.Count == 1 && !isAnnualEstimation) || (toto.Count > 1 && isAnnualEstimation))
            //        return Ok(_planPosteFrequencyService.InitForCreation(isAnnualEstimation));
            //    else
            //        return Ok(toto);
            //}
            //return Ok(_planPosteFrequencyService.InitForCreation(isAnnualEstimation));

        }
    }
}
