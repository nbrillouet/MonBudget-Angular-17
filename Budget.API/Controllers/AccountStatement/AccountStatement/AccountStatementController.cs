using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Filter;
using Budget.SERVICE;
using Budget.API.Helpers;
using Budget.MODEL.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/account-statements")]
    public class AccountStatementController : Controller
    {
        private readonly IAccountStatementService _accountStatementService;
        private readonly IAsSoldeService _asSoldeService;
        private readonly FilterService _filterService;
        private readonly ReferentialService _referentialService;


        private Dictionary<string, object> serviceNames = new Dictionary<string, object>();

        public AccountStatementController(
            IAccountStatementService accountStatementService,
            IAsSoldeService asSoldeService,
            ReferentialService referentialService,
            FilterService filterService
            

            )
        {
            _referentialService = referentialService;
            _accountStatementService = accountStatementService;
            _asSoldeService = asSoldeService;
            _filterService = filterService;

            serviceNames.Add("accountStatement", _accountStatementService);
            serviceNames.Add("referentialService", _referentialService);
        }

        [HttpPost]
        [Route("as-main-filter-selection")]
        public IActionResult getFilterAsMainSelection([FromBody] FilterAsMainSelected filter)
        {
            var result = _filterService.FilterMainService.GetFilterAsMainSelection(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("as-table-filter-selection")]
        public IActionResult getFilterAsTableSelection([FromBody] FilterAsTableSelected filter)
        {
            var result = _filterService.FilterTableService.GetFilterAsTableSelection(filter);

            return Ok(result);
        }

        //[HttpPost]
        //[Route("table-filter")]
        //public IActionResult getAsTableFilter([FromBody] JObject filterSelected)
        //{
        //    FilterTableSelected filterTableSelected = filterSelected.ToObject<FilterTableSelected>();
        //    string filterName = filterTableSelected.EnumFilterTableSelectedType.ToString();

        //    Type typeModel = Assembly.Load("Budget.MODEL").GetTypes().Where(x => x.Name == "FilterAsTable").FirstOrDefault();

        //    //Type typeFilter = Type.GetType("Budget.MODEL.Filter.FilterAsTable");
        //    object toto = Activator.CreateInstance(typeModel);
        //    var properties = toto.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        //    var service = serviceNames["referentialService"];
        //    var propertiesr = service.GetType().GetProperties();
        //    var t = service.GetType();
        //    foreach (PropertyInfo propertyInfo in properties)
        //    {
        //        var value = propertyInfo.PropertyType;
        //        PropertyInfo p = t.GetProperty($"{propertyInfo.Name}Service");
        //        var location = p.GetValue(service, null);

        //        if (propertyInfo.PropertyType == typeof(List<SelectDto>))
        //        {
        //            MethodInfo method;
        //            switch (propertyInfo.Name)
        //            {
        //                case "OperationMethod":
        //                    method = p.PropertyType.GetMethods()
        //                        .Single(
        //                        x => x.Name == "GetSelectList" &&
        //                        //x.GetGenericArguments().Length == 1 && 
        //                        x.GetParameters().Length == 1 &&
        //                        x.GetParameters()[0].ParameterType == typeof(EnumSelectType));
        //                    break;
        //                case "Operation":
        //                    method = p.PropertyType.GetMethods()
        //                        .Single(
        //                        x => x.Name == "GetSelectList" &&
        //                        //x.GetGenericArguments().Length == 1 && 
        //                        x.GetParameters().Length == 1 &&
        //                        x.GetParameters()[0].ParameterType == typeof(EnumSelectType));
        //                    break;
        //                default:
        //                    method = p.PropertyType.GetMethods()
        //                        .Single(
        //                        x => x.Name == "GetSelectList" &&
        //                        x.GetParameters().Length == 1 &&
        //                        x.GetParameters()[0].ParameterType == typeof(EnumSelectType));
        //                    break;
        //            }


        //            var results = method.Invoke(location, new object[] { EnumSelectType.Empty });

        //            toto.GetType().GetProperty(propertyInfo.Name).SetValue(toto,results);

        //            //foreach (var item in propertiesr)
        //            //{
        //            //    var th = propertiesr.Where(x => x.Name == $"{propertyInfo.Name}Service").FirstOrDefault();
        //            //    Type assemblyService = Assembly.Load("Budget.SERVICE").GetTypes().Where(x => x.Name == $"{propertyInfo.Name}Service").FirstOrDefault();
        //            //    var ti = th.GetValue(th);
        //            //    var method = th.PropertyType.GetMethod("GetSelectList");

        //            //           MethodInfo openGenericMethod = th.GetType().GetMethod("GetSelectList"); // assemblyService.GetMethod("GetSelectList");
        //            //    var results = method.Invoke(location, new object[] { EnumSelectType.Empty });
        //            //}
        //        }

        //    }

        //    //determiner la classe du filtre en fonction du nom du filtre
        //    //FilterAsTable filterAsTable = new FilterAsTable();
        //    //filterAsTable.Selected = filter;

        //    //var operationMethods = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty);
        //    //filterAsTable.OperationMethod = operationMethods;

        //    //var result = _filterService.GetFilterAsTable(filter);

        //    return Ok(null);
        //}

        [HttpPost]
        [Route("filter")]
        public IActionResult getAsTable([FromBody] FilterAsTableSelected filter)
        {
            var pagedList = _accountStatementService.GetTable(filter);

            return Ok(pagedList);

        }

        //[HttpPost]
        //[Route("filter")]
        //public IActionResult getAsTable([FromBody] JObject filter)
        //{
        //    var filterTableSelected = filter.ToObject<FilterTableSelected>();
        //    switch(filterTableSelected.EnumFilterTableSelectedType)
        //    {
        //        case EnumFilterTableSelectedType.accountStatement:
        //            var service = serviceNames[filterTableSelected.EnumFilterTableSelectedType.ToString()];
        //            Type assemblyServce = Assembly.Load("Budget.SERVICE").GetTypes().Where(x => x.Name == $"IAccountStatementService").FirstOrDefault();
        //            //var t = filter.ToObject<FilterAsTableSelected>();
        //            MethodInfo openGenericMethod = assemblyServce.GetMethod("GetAsTable");
        //            //object o2 = openGenericMethod.Invoke(_couvertureService, new object[] { 1006 });
        //            object o2 = openGenericMethod.Invoke(service, new object[] { filter.ToObject<FilterAsTableSelected>() });
        //            return Ok(o2);
        //            break;
        //    }
        //    var t = filter.ToObject<FilterAsTableSelected>();// JsonConvert.DeserializeObject<FilterAsTableSelected>(filter);
        //    //var t = JsonConvert.DeserializeObject<FilterAsTableSelected>(filter);
        //    //var t = filter as FilterAsTableSelected;
        //    //if (filter.GetType().Name == "FilterAsTableSelected")
        //    //{
        //    //    FilterAsTableSelected filterAsTableSelected = filter as FilterAsTableSelected;
        //    //    var pagedList = _accountStatementService.GetAsTable(filterAsTableSelected);
        //    //    return Ok(pagedList);
        //    //}
        //    return null;

        //}

        [HttpGet]
        [Route("{idAs}/as-detail")]
        public IActionResult GetForDetail(int idAs)
        {
            var results = _accountStatementService.GetForDetail(idAs);
            return Ok(results);
        }

        [HttpPost]
        [Route("as-detail-filter")]
        public IActionResult GetForDetailFilter([FromBody] AsForDetail asForDetail)
        {
            return Ok(_filterService.FilterDetailService.GetFilterForAs(asForDetail));
        }

        //[HttpPost]
        //[Route("detail")]
        //public IActionResult GetAsDetail([FromBody] FilterAsDetail filter)
        //{
        //    var asifDto = _accountStatementService.GetAsDetail(filter);

        //    return Ok(asifDto);
        //}

        [HttpPost]
        [Route("as-solde")]
        public IActionResult GetSolde([FromBody] FilterAsMainSelected filter)
        {
            var pagedList = _asSoldeService.GetSolde(filter);

            return Ok(pagedList);

        }

        [HttpPost]
        [Route("save-as-detail")]
        public IActionResult Save([FromBody] AsForDetail asForDetail)
        {
            try
            {
                var result = _accountStatementService.Update(asForDetail);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
