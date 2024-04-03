using Budget.MODEL;
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
    [Route("api/account-statement-charts")]
    public class AccountStatementChartController: Controller
    {
        private readonly IAsChartEvolutionService _asChartEvolutionService;
        private readonly IAsChartCategorisationService _asChartCategorisationService;

        public AccountStatementChartController(
            IAsChartEvolutionService asChartEvolutionService,
            IAsChartCategorisationService asChartCategorisationService

            )
        {
            _asChartEvolutionService = asChartEvolutionService;
            _asChartCategorisationService = asChartCategorisationService;
        }

        //=====================================================================================
        //=================================  EVOLUTION  =======================================
        //=====================================================================================
        [HttpPost]
        [Route("chart-evolution-brut")]
        public IActionResult GetAsChartEvolutionBrut([FromBody] FilterAsTableSelected filter)
        {
            var result = _asChartEvolutionService.GetAsChartEvolutionBrut(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("chart-evolution-no-int-transfer")]
        public IActionResult GetAsChartEvolutionNoIntTransfer([FromBody] FilterAsTableSelected filter)
        {
            var result = _asChartEvolutionService.GetAsChartEvolutionNoIntTransfer(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("chart-evolution-custom-otf")]
        public IActionResult GetAsChartEvolutionCustomOtf([FromBody] FilterAsTableSelected filter)
        {
            var result = _asChartEvolutionService.GetAsChartEvolutionCustomOtf(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("chart-evolution-custom-otf-filter")]
        public IActionResult GetAsChartEvolutionCustomOtfFilter([FromBody] FilterAsTableSelected filter)
        {
            var result = _asChartEvolutionService.GetAsChartEvolutionCustomOtfFilter(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("chart-evolution-custom-otf-filter/update")]
        public IActionResult UpdateAsChartEvolutionCustomOtfFilter([FromBody] AsChartEvolutionCustomOtfFilterSelected filter)
        {
            
            var result = _asChartEvolutionService.UpdateAsChartEvolutionCustomOtfFilter(filter);

            return Ok(result);
        }




        //=====================================================================================
        //=============================  CATEGORISATION  ======================================
        //=====================================================================================
        [HttpPost]
        [Route("chart-categorisation-debit")]
        public IActionResult GetAsChartCategorisationDebit([FromBody] FilterAsTableSelected filter)
        {
            var result = _asChartCategorisationService.GetAsChartCategorisationDebit(filter);

            return Ok(result);
        }

    }
}
