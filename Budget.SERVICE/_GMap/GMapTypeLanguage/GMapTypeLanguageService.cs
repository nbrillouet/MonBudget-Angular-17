using AutoMapper;
using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapTypeLanguageService : IGMapTypeLanguageService
    {
        private readonly IMapper _mapper;
        private readonly IGMapTypeLanguageRepository _gMapTypeLanguageRepository;

        public GMapTypeLanguageService(
            IGMapTypeLanguageRepository gMapTypeLanguageRepository,
            IMapper mapper)
        {
            _gMapTypeLanguageRepository = gMapTypeLanguageRepository;
            _mapper = mapper;
        }

        public GMapTypeLanguage Get(int idGMapType, EnumLanguage enumLanguage)
        {
            var result = _gMapTypeLanguageRepository.Get(idGMapType, enumLanguage);

            return result;

        }

    }
}
