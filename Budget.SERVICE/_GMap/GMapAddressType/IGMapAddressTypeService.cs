using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapAddressTypeService
    {
        GMapAddressType Create(GMapAddressType gMapAddressType);
        List<GMapType> Update(int idGMapAddress, List<GMapTypeDto> gMapTypeDtos);
        //List<GMapAddressType> Create(int idGMapAddress,List<GMapTypeDto> gMapTypes);
        List<GMapTypeDto> GetByIdGMapAddress(int id, EnumLanguage enumLanguage);
    }


}
