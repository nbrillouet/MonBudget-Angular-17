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
    [Route("api/plan-not-as")]
    public class PlanNotAsController : Controller
    {
        private readonly IPlanNotAsService _planNotAsService;
        private readonly FilterService _filterService;

        public PlanNotAsController(
            IPlanNotAsService planNotAsService,
            FilterService filterService
            )
        {
            _planNotAsService = planNotAsService;
            _filterService = filterService;
        }

        [HttpPost]
        [Route("plan-not-as-table-filter")]
        public IActionResult getPlanNotAsTableFilter([FromBody] FilterPlanNotAsTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterPlanNotAsTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("plan-not-as-table-data")]
        public IActionResult GetPlanNotAsTable([FromBody]FilterPlanNotAsTableGroupSelected filter)
        {
            var pagedList = _planNotAsService.GetPlanNotAsTable(filter);

            return Ok(pagedList);
        }

        

        //[HttpGet("plans/{idPlan}/user-groups/{idUserGroup}/as-not-in-plan")]
        //public IActionResult GetAsNotInPlan(int idPlan, int idUserGroup)
        //{

        //    var asifForTableDto = _accountStatementPlanService.GetAsNotInPlan(idPlan, idUserGroup);

        //    return Ok(asifForTableDto);
        //}

    }
}
