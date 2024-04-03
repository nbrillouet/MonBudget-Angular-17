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
    public class GMapTypeService : IGMapTypeService
    {
        private readonly IMapper _mapper;
        private readonly IGMapTypeLanguageService _gMapTypeLanguageService;
        private readonly IGMapTypeRepository _gMapTypeRepository;

        public GMapTypeService(
            IGMapTypeLanguageService gMapTypeLanguageService,
            IGMapTypeRepository gMapTypeRepository,
            IMapper mapper)
        {
            _gMapTypeLanguageService = gMapTypeLanguageService;
            _gMapTypeRepository = gMapTypeRepository;
            _mapper = mapper;
        }

        public List<GMapTypeDto> GetByKeywordOrCreate(List<GMapType> gMapTypes, EnumLanguage enumLanguage)
        {
            var results = _gMapTypeRepository.GetByKeywordOrCreate(gMapTypes);

            return GetGMapTypeDto(results,enumLanguage);

        }

        public List<GMapTypeDto> GetGMapTypeDto (List<GMapType> gMapTypes, EnumLanguage enumLanguage)
        {
            List<GMapTypeDto> GMapTypeDtos = new List<GMapTypeDto>();
            foreach (var item in gMapTypes)
            {
                GMapTypeLanguage gMapTypeLanguage = _gMapTypeLanguageService.Get(item.Id,enumLanguage);
                GMapTypeDto gMapTypeDto = _mapper.Map<GMapTypeDto>(item);
                gMapTypeDto.Label = gMapTypeLanguage != null ? gMapTypeLanguage.Label : item.Keyword;

                GMapTypeDtos.Add(gMapTypeDto);
            }

            return GMapTypeDtos;
        }

        public List<GMapType> GetByKeywordOrCreate(List<GMapTypeDto> gMapTypeDtos)
        {
            var gMapTypes = _mapper.Map<List<GMapType>>(gMapTypeDtos);
            var results = _gMapTypeRepository.GetByKeywordOrCreate(gMapTypes);

            return results;
        }

        //maj coté front de ladresse-> mettre a jour gmaptype avec donnée de la base
        public List<GMapTypeDto> ChangeGMapType(List<GMapTypeDto> GMapTypes, string language)
        {
            List<GMapType> gMapTypes = GetByKeywordOrCreate(GMapTypes);

            return _mapper.Map<List<GMapTypeDto>>(gMapTypes);
        }


    }
}
