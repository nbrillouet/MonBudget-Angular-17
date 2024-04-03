using AutoMapper;
using Budget.DATA.Repositories.GMap;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapAddressService : IGMapAddressService
    {
        private readonly IGMapAddressRepository _gMapAddressRepository;
        private readonly IMapper _mapper;
        private readonly IGMapAdministrativeAreaLevel1Service _gMapAdministrativeAreaLevel1Service;
        private readonly IGMapAdministrativeAreaLevel2Service _gMapAdministrativeAreaLevel2Service;
        private readonly IGMapCountryService _gMapCountryService;
        private readonly IGMapLocalityService _gMapLocalityService;
        private readonly IGMapNeighborhoodService _gMapNeighborhoodService;
        private readonly IGMapPostalCodeService _gMapPostalCodeService;
        private readonly IGMapRouteService _gMapRouteService;
        private readonly IGMapStreetNumberService _gMapStreetNumberService;
        private readonly IGMapSublocalityLevel1Service _gMapSublocalityLevel1Service;
        private readonly IGMapSublocalityLevel2Service _gMapSublocalityLevel2Service;
        //private readonly IGMapTypeService _gMapTypeService;
        private readonly IGMapAddressTypeService _gMapAddressTypeService;

        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;

        public GMapAddressService(
            IGMapAddressRepository gMapAddressRepository,
            IMapper mapper,
            IGMapAdministrativeAreaLevel1Service gMapAdministrativeAreaLevel1Service,
            IGMapAdministrativeAreaLevel2Service gMapAdministrativeAreaLevel2Service,
            IGMapCountryService gMapCountryService,
            IGMapLocalityService gMapLocalityService,
            IGMapNeighborhoodService gMapNeighborhoodService,
            IGMapPostalCodeService gMapPostalCodeService,
            IGMapRouteService gMapRouteService,
            IGMapStreetNumberService gMapStreetNumberService,
            IGMapSublocalityLevel1Service gMapSublocalityLevel1Service,
            IGMapSublocalityLevel2Service gMapSublocalityLevel2Service,
            //IGMapTypeService gMapTypeService,
            IGMapAddressTypeService gMapAddressTypeService,

            IBusinessExceptionMessageService businessExceptionMessageService)
        {
            _gMapAddressRepository = gMapAddressRepository;
            _mapper = mapper;
            _gMapAdministrativeAreaLevel1Service = gMapAdministrativeAreaLevel1Service;
            _gMapAdministrativeAreaLevel2Service = gMapAdministrativeAreaLevel2Service;
            _gMapCountryService = gMapCountryService;
            _gMapLocalityService = gMapLocalityService;
            _gMapNeighborhoodService = gMapNeighborhoodService;
            _gMapPostalCodeService = gMapPostalCodeService;
            _gMapRouteService = gMapRouteService;
            _gMapStreetNumberService = gMapStreetNumberService;
            _gMapSublocalityLevel1Service = gMapSublocalityLevel1Service;
            _gMapSublocalityLevel2Service = gMapSublocalityLevel2Service;
            //_gMapTypeService = gMapTypeService;
            _gMapAddressTypeService = gMapAddressTypeService;

            _businessExceptionMessageService = businessExceptionMessageService;
        }

        public GMapAddressDto GetById(int id, EnumLanguage enumLanguage)
        {
            GMapAddress gMapAddress = _gMapAddressRepository.GetById(id);
            GMapAddressDto gMapAddressDto = _mapper.Map<GMapAddressDto>(gMapAddress);
            if(gMapAddressDto!=null)
                gMapAddressDto.GMapTypes= _gMapAddressTypeService.GetByIdGMapAddress(id, enumLanguage);

            return gMapAddressDto;
        }

        //public GMapAddressDto Create(GMapAddressDto gMapAddressDto)
        //{
        //    GMapAddress gMapAddress = _mapper.Map<GMapAddress>(gMapAddressDto);
        //    GMapAdministrativeAreaLevel1 gMapAdministrativeAreaLevel1 = _gMapAdministrativeAreaLevel1Service.GetByLabelOrCreate(gMapAddress.GMapAdministrativeAreaLevel1);
        //    GMapAdministrativeAreaLevel2 gMapAdministrativeAreaLevel2 = _gMapAdministrativeAreaLevel2Service.GetByLabelOrCreate(gMapAddress.GMapAdministrativeAreaLevel2);
        //    GMapCountry gMapCountry = _gMapCountryService.GetByLabelOrCreate(gMapAddress.GMapCountry);
        //    GMapLocality gMapLocality = _gMapLocalityService.GetByLabelOrCreate(gMapAddress.GMapLocality);
        //    GMapNeighborhood gMapNeighborhood = _gMapNeighborhoodService.GetByLabelOrCreate(gMapAddress.GMapNeighborhood);
        //    GMapPostalCode gMapPostalCode = _gMapPostalCodeService.GetByLabelOrCreate(gMapAddress.GMapPostalCode);
        //    GMapRoute gMapRoute = _gMapRouteService.GetByLabelOrCreate(gMapAddress.GMapRoute);
        //    GMapStreetNumber gMapStreetNumber = _gMapStreetNumberService.GetByLabelOrCreate(gMapAddress.GMapStreetNumber);
        //    GMapSublocalityLevel1 gMapSublocalityLevel1 = _gMapSublocalityLevel1Service.GetByLabelOrCreate(gMapAddress.GMapSublocalityLevel1);
        //    GMapSublocalityLevel2 gMapSublocalityLevel2 = _gMapSublocalityLevel2Service.GetByLabelOrCreate(gMapAddress.GMapSublocalityLevel2);

        //    gMapAddress.IdGMapAdministrativeAreaLevel1 = gMapAdministrativeAreaLevel1.Id;
        //    gMapAddress.IdGMapAdministrativeAreaLevel2 = gMapAdministrativeAreaLevel2.Id;
        //    gMapAddress.IdGMapCountry = gMapCountry.Id;
        //    gMapAddress.IdGMapLocality = gMapLocality.Id;
        //    gMapAddress.IdGMapNeighborhood = gMapNeighborhood.Id;
        //    gMapAddress.IdGMapPostalCode = gMapPostalCode.Id;
        //    gMapAddress.IdGMapRoute = gMapRoute.Id;
        //    gMapAddress.IdGMapStreetNumber = gMapStreetNumber.Id;
        //    gMapAddress.IdGMapSublocalityLevel1 = gMapSublocalityLevel1.Id;
        //    gMapAddress.IdGMapSublocalityLevel2 = gMapSublocalityLevel2.Id;

        //    List<GMapTypeDto> gMapTypes = _gMapTypeService.GetByKeywordOrCreate(_mapper.Map<List<GMapType>>(gMapAddressDto.GMapTypes), EnumLanguage.FR);


        //    //Recherche si adresse existe deja
        //    var gMapAddressDuplicate = _gMapAddressRepository.GetByGMapAddress(gMapAddress);
        //    if (gMapAddressDuplicate == null)
        //    {
        //        gMapAddress = _gMapAddressRepository.Create(gMapAddress);
        //        gMapAddressDto = _mapper.Map<GMapAddressDto>(gMapAddress);

        //        //creation du GMapAddressType
        //        _gMapAddressTypeService.Create(gMapAddress.Id, gMapTypes);
        //        gMapAddressDto.GMapTypes = gMapTypes;
        //    }
        //    else
        //    {
        //        gMapAddressDto = _mapper.Map<GMapAddressDto>(gMapAddressDuplicate);
        //        gMapAddressDto.GMapTypes = gMapTypes; 
        //    }

        //    return gMapAddressDto;

        //}

        

        //CheckValues utilisé comme enregistrement pour cette classe
        public GMapAddress CheckValues(GMapAddressDto gMapAddressDto, EnumOperationPlace enumOperationPlace)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            GMapAddress gMapAddress=null;
            if (enumOperationPlace == EnumOperationPlace.GEO)
            {
                if (gMapAddressDto == null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_GMAP_ERR_001));
                }

                gMapAddress = gMapAddressDto.Id != 0
                    ? GetById(gMapAddressDto.Id)
                    : Create(gMapAddressDto);

                //update GMapTypes
                _gMapAddressTypeService.Update(gMapAddress.Id, gMapAddressDto.GMapTypes);
            }

            return gMapAddress;
        }

        private GMapAddress GetById(int idGMapAddress)
        {
            GMapAddress gMapAddress = _gMapAddressRepository.GetById(idGMapAddress);
            //if (gMapAddress != null)
            //{
            //    //mise à jour des gmapType pour cette adresse
            //    _gMapAddressTypeService.Update(idGMapAddress, gMapTypes);
            //}

            return gMapAddress;
        }

        private GMapAddress Create(GMapAddressDto gMapAddressDto)
        {
            GMapAddress gMapAddress = new GMapAddress
            {
                IdGMapAdministrativeAreaLevel1 = _gMapAdministrativeAreaLevel1Service.GetByLabelOrCreate(gMapAddressDto.GMapAdministrativeAreaLevel1.Label).Id,
                IdGMapAdministrativeAreaLevel2 = _gMapAdministrativeAreaLevel2Service.GetByLabelOrCreate(gMapAddressDto.GMapAdministrativeAreaLevel2.Label).Id,
                IdGMapCountry = _gMapCountryService.GetByLabelOrCreate(gMapAddressDto.GMapCountry.Label).Id,
                IdGMapLocality = _gMapLocalityService.GetByLabelOrCreate(gMapAddressDto.GMapLocality.Label).Id,
                IdGMapNeighborhood = _gMapNeighborhoodService.GetByLabelOrCreate(gMapAddressDto.GMapNeighborhood.Label).Id,
                IdGMapPostalCode = _gMapPostalCodeService.GetByLabelOrCreate(gMapAddressDto.GMapPostalCode.Label).Id,
                IdGMapRoute = _gMapRouteService.GetByLabelOrCreate(gMapAddressDto.GMapRoute.Label).Id,
                IdGMapStreetNumber = _gMapStreetNumberService.GetByLabelOrCreate(gMapAddressDto.GMapStreetNumber.Label).Id,
                IdGMapSublocalityLevel1 = _gMapSublocalityLevel1Service.GetByLabelOrCreate(gMapAddressDto.GMapSublocalityLevel1.Label).Id,
                IdGMapSublocalityLevel2 = _gMapSublocalityLevel2Service.GetByLabelOrCreate(gMapAddressDto.GMapSublocalityLevel2.Label).Id,
                FormattedAddress = gMapAddressDto.FormattedAddress,
                Lat = gMapAddressDto.Lat,
                Lng = gMapAddressDto.Lng
            };
            

            //List<GMapTypeDto> gMapTypes = _gMapTypeService.GetByKeywordOrCreate(_mapper.Map<List<GMapType>>(gMapAddressDto.GMapTypes), EnumLanguage.FR);

            //Recherche si adresse existe deja
            var gMapAddressDuplicate = _gMapAddressRepository.GetByGMapAddress(gMapAddress);
            if (gMapAddressDuplicate == null)
            {
                gMapAddress = _gMapAddressRepository.Create(gMapAddress);
                //gMapAddressDto = _mapper.Map<GMapAddressDto>(gMapAddress);

                ////creation du GMapAddressType
                //_gMapAddressTypeService.Create(gMapAddress.Id, gMapTypes);
                //gMapAddressDto.GMapTypes = gMapTypes;
            }
            else
            {
                gMapAddress = gMapAddressDuplicate;
                //gMapAddressDto = _mapper.Map<GMapAddressDto>(gMapAddressDuplicate);
                //gMapAddressDto.GMapTypes = gMapTypes;
            }

            return gMapAddress;

        }

    }


}
