using AutoMapper;
using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapAddressTypeService : IGMapAddressTypeService
    {
        private readonly IMapper _mapper;
        private readonly IGMapTypeService _gMapTypeService;
        private readonly IGMapAddressTypeRepository _gMapAddressTypeRepository;

        public GMapAddressTypeService(
            IMapper mapper,
            IGMapTypeService gMapTypeService,
            IGMapAddressTypeRepository gMapAddressTypeRepository)
        {
            _mapper = mapper;
            _gMapAddressTypeRepository = gMapAddressTypeRepository;
            _gMapTypeService = gMapTypeService;
        }

        public GMapAddressType Create(GMapAddressType gMapAddressType)
        {
            return _gMapAddressTypeRepository.Create(gMapAddressType);
        }

        public List<GMapAddressType> Create(int idGMapAddress, List<GMapTypeDto> gMapTypes)
        {
            List<GMapAddressType> gMapAddressTypes = new List<GMapAddressType>();
            foreach (var gMapType in gMapTypes)
            {
                var gMapAddressType = new GMapAddressType
                {
                    IdGMapAddress = idGMapAddress,
                    IdGMapType = gMapType.Id
                };
                gMapAddressTypes.Add(Create(gMapAddressType));
            }

            return gMapAddressTypes;
        }

        public List<GMapType> Update(int idGMapAddress, List<GMapTypeDto> gMapTypeDtos)
        {
            //suppression liaison adresse/type
            DeleteByIdGMapAddress(idGMapAddress);
            //Check des gMapType (ajout si besoin)
            List<GMapType> gMapTypes = _gMapTypeService.GetByKeywordOrCreate(gMapTypeDtos);
            //Ajout des type sur ladresse
            foreach(var gMapType in gMapTypes)
            {
                GMapAddressType gMapAddressType = new GMapAddressType { IdGMapAddress = idGMapAddress, IdGMapType = gMapType.Id };
                _gMapAddressTypeRepository.Create(gMapAddressType);
            }

            return _gMapAddressTypeRepository.GetGMapTypeByIdGMapAddress(idGMapAddress); 
        }

        public List<GMapTypeDto> GetByIdGMapAddress(int id, EnumLanguage enumLanguage)
        {
            var results = _gMapAddressTypeRepository.GetGMapTypeByIdGMapAddress(id);

            return _gMapTypeService.GetGMapTypeDto(results, enumLanguage);
        }

        private void DeleteByIdGMapAddress(int idGMapAddress)
        {
            var gMapAdressTypes = _gMapAddressTypeRepository.GetByIdGMapAddress(idGMapAddress);
            foreach(var gMapAdressType in gMapAdressTypes)
            {
                _gMapAddressTypeRepository.Delete(gMapAdressType);
            }
        }




    }


}
