using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapTypeService
    {
        List<GMapType> GetByKeywordOrCreate(List<GMapTypeDto> gMapTypeDtos);
        List<GMapTypeDto> GetByKeywordOrCreate(List<GMapType> gMapTypes, EnumLanguage enumLanguage);
        List<GMapTypeDto> GetGMapTypeDto(List<GMapType> gMapTypes, EnumLanguage enumLanguage);
        List<GMapTypeDto> ChangeGMapType(List<GMapTypeDto> GMapTypes, string language);
    }


}
