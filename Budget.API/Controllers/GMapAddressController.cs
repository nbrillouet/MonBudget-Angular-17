using AutoMapper;
using Budget.API.Helpers;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.SERVICE.GMap;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Budget.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/GMapAddresses")]
    public class GMapAddressController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGMapAddressService _gMapAddressService;
        private readonly IGMapTypeService _gMapTypeService;

        public GMapAddressController(
            IGMapAddressService gMapAddressService,
            IGMapTypeService gMapTypeService,
            IMapper mapper)
        {
            _mapper = mapper;
            _gMapAddressService = gMapAddressService;
            _gMapTypeService = gMapTypeService;
        }

        [HttpGet]
        [Route("{id}/GMapAddress")]
        public IActionResult Get(int id)
        {
            string languageCode = HttpContext.User.FindFirst(ClaimTypes.Locality)?.Value.ToUpper();
            var gMapAddress = _gMapAddressService.GetById(id, (EnumLanguage)Enum.Parse(typeof(EnumLanguage),languageCode));

            return Ok(gMapAddress);

        }

        [HttpPost]
        [Route("language/{language}/change-gmap-type")]
        public IActionResult ChangeGMapType(string language, [FromBody] List<GMapTypeDto> GMapTypes)
        {
            //string languageCode = HttpContext.User.FindFirst(ClaimTypes.Locality)?.Value.ToUpper();
            var gMapTypes= _gMapTypeService.ChangeGMapType(GMapTypes, language);

            return Ok(gMapTypes);

        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] GMapAddressDto gMapAddressDto)
        {
            //try
            //{
            //var result = _gMapAddressService.Create(gMapAddressDto);
            return Ok("VIDE");
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}

        }
    }
}
