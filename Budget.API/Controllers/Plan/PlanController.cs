using AutoMapper;
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
    [Route("api")]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IPlanPosteReferenceService _planPosteReferenceService;
        private readonly IPlanDetailService _planDetailService;
        private readonly IPlanPosteDetailService _planPosteDetailService;
        private readonly IPlanFollowUpService _planFollowUpService;
        private readonly IPlanUserService _planUserService;
        private readonly IPlanPosteFrequencyService _planPosteFrequencyService;
        private readonly IPlanNotAsService _accountStatementPlanService;
        private readonly FilterService _filterService;

        public PlanController(
            IPlanService planService,
            IPlanPosteReferenceService planPosteReferenceService,
            IPlanDetailService planDetailService,
            IPlanPosteDetailService planPosteDetailService,
            IPlanFollowUpService planFollowUpService,
            IPlanUserService planUserService,
            IPlanPosteFrequencyService planPosteFrequencyService,
            IPlanNotAsService accountStatementPlanService,
            FilterService filterService
            )
        {
            _planService = planService;
            _planPosteReferenceService = planPosteReferenceService;
            _planDetailService = planDetailService;
            _planPosteDetailService = planPosteDetailService;
            _planFollowUpService = planFollowUpService;
            _planUserService = planUserService;
            _planPosteFrequencyService = planPosteFrequencyService;
            _accountStatementPlanService = accountStatementPlanService;
            _filterService = filterService;
        }

        //[HttpPost]
        //[Route("plans/filter")]
        //public async Task<IActionResult> GetPlanTable([FromBody] FilterPlan filter)
        //{
        //    var pagedList = _planService.GetPlanTable(filter);

        //    return Ok(pagedList);

        //}

        //[HttpGet("plans/combo-filter")]
        //public IActionResult GetPlanTableComboFilter()
        //{
        //    var plan = _planService.GetPlanTableComboFilter();

        //    return Ok(plan);
        //}
        [HttpPost]
        [Route("plans/plan-table-filter")]
        public IActionResult getPlanTableFilter([FromBody] FilterPlanTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterPlanTable(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("plans/plan-table-data")]
        public IActionResult GetPlanTable([FromBody] FilterPlanTableSelected filter)
        {
            var pagedList = _planService.GetPlanTable(filter);

            return Ok(pagedList);
        }
               

        [HttpGet("plans/users/{idUser}/list")]
        public IActionResult GetPlansByIdUser(int idUser)
        {
            var plan = _planUserService.GetPlansByIdUser(idUser);

            return Ok(plan);
        }

        [HttpGet("users/{idUser}/plans/{idPlan}/plan-detail")]
        public IActionResult Get(int idPlan, int idUser)
        {
           var planForDetailDto = _planDetailService.GetForDetail(idPlan, idUser);

            return Ok(planForDetailDto);
        }



        [HttpPost("plans/plan-details/save")]
        public IActionResult SavePlanDetail([FromBody] PlanForDetailDto planForDetailDto)
        {
            try
            {
                _planDetailService.Save(planForDetailDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Erreur lors de la sauvegarde", e.Message.ToString());
                return BadRequest(ModelState);
            }

            return Ok(planForDetailDto.Plan.Id);
        }

        [HttpPost("plans/delete-plans")]
        public IActionResult DeletePlans([FromBody] List<int> idPlanList)
        {
            try
            {
                _planService.DeletePlans(idPlanList);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Erreur lors de la suppression", e.Message.ToString());
                return BadRequest(ModelState);
            }

            return Ok("delete-plans-ok");
        }

        [HttpPost("plans/plan-follow-up/dashboard")]
        public IActionResult GetPlanForFollowUp([FromBody] FilterPlanFollowUpSelected filter)
        {

            var planForDetailDto = _planFollowUpService.Get(filter);

            return Ok(planForDetailDto);
        }

        [HttpPost]
        [Route("plans/plan-follow-up/dashboard-filter")]
        public IActionResult getPlanFollowUpDashboardFilter([FromBody] FilterPlanFollowUpSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterPlanDashboard(filter);

            return Ok(result);
        }
        [HttpPost]
        [Route("plans/plan-follow-up/amount-real")]
        public IActionResult GetPlanFollowUpAmountReal([FromBody] PlanFollowUpAmountRealFilter filter)
        {
            var results = _planFollowUpService.GetPlanFollowUpAmountReal(filter);

            return Ok(results);

        }
    }
}
