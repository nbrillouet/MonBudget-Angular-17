using Budget.MODEL.Filter;
using Budget.SERVICE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/tables")]
    public class TableController : Controller
    {
        private readonly IAccountStatementService _accountStatementService;
        private readonly FilterService _filterService;

        private Dictionary<string, object> serviceNames = new Dictionary<string, object>();

        public TableController(
            IAccountStatementService accountStatementService,
            FilterService filterService
            )
        {
            _accountStatementService = accountStatementService;
            _filterService = filterService;

            serviceNames.Add("accountStatement", _accountStatementService);
        }

        [HttpPost]
        [Route("table-filter")]
        public IActionResult getAsTableFilter([FromBody] JObject filterSelected)
        {
            FilterTableSelected filterTableSelected = filterSelected.ToObject<FilterTableSelected>();
            string filterName = filterTableSelected.EnumFilterTableSelectedType.ToString();

            Type typeModel = Assembly.Load("Budget.MODEL").GetTypes().Where(x => x.Name == "Filter.FilterAsTable").FirstOrDefault();
            //Type typeFilter = Type.GetType("Filter.FilterAsTable");
            object toto = Activator.CreateInstance(typeModel);
            var properties = this.GetType().GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in properties)
            {
                var t = propertyInfo.Name;
            }
            
            //determiner la classe du filtre en fonction du nom du filtre
            //FilterAsTable filterAsTable = new FilterAsTable();
            //filterAsTable.Selected = filter;

            //var operationMethods = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty);
            //filterAsTable.OperationMethod = operationMethods;

            //var result = _filterService.GetFilterAsTable(filter);

            return Ok(null);
        }

        //[HttpPost]
        //[Route("filter")]
        //public IActionResult getAsTable([FromBody] FilterAsTableSelected filter)
        //{
        //    var pagedList = _accountStatementService.GetAsTable(filter);

        //    return Ok(pagedList);

        //}

        [HttpPost]
        [Route("datas")]
        public IActionResult getTable([FromBody] JObject filter)
        {
            FilterTableSelected filterTableSelected = filter.ToObject<FilterTableSelected>();
            string filterName = filterTableSelected.EnumFilterTableSelectedType.ToString();
            string interfaceServiceName = $"I{filterName.Substring(0, 1).ToUpper()}{filterName.Substring(1)}Service";
            var service = serviceNames[filterName];
            Type assemblyService = Assembly.Load("Budget.SERVICE").GetTypes().Where(x => x.Name == interfaceServiceName).FirstOrDefault();
            MethodInfo openGenericMethod = assemblyService.GetMethod("GetTable");
            var results = openGenericMethod.Invoke(service, new object[] { filter.ToObject<FilterAsTableSelected>() });

            return Ok(results);
        }

        [HttpPost]
        [Route("filter")]
        public IActionResult getAsTableFilter([FromBody] FilterAsTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterAsTableSelection(filter);

            return Ok(result);
        }



        //[HttpPost]
        //[Route("detail")]
        //public IActionResult GetAsDetail([FromBody] FilterAsDetail filter)
        //{

        //    var asifDto = _accountStatementService.GetAsDetail(filter);

        //    return Ok(asifDto);
        //}

        //[HttpPost]
        //[Route("solde-filter")]
        //public async Task<IActionResult> GetSolde([FromBody] FilterAsTableSelected filter)
        //{
        //    var pagedList = _accountStatementService.GetSolde(filter);

        //    return Ok(pagedList);

        //}

        //[HttpPost]
        //[Route("update")]
        //public IActionResult update([FromBody] AsDetailDto asDetailDto)
        //{
        //    try
        //    {
        //        var result = _accountStatementService.Update(asDetailDto);

        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}



    }
}
