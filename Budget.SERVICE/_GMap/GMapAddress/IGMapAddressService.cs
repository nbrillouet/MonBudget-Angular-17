using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapAddressService
    {
        //GMapAddressDto Create(GMapAddressDto gMapAddressDto);
        GMapAddressDto GetById(int id, EnumLanguage enumLanguage);
        GMapAddress CheckValues(GMapAddressDto gMapAddressDto, EnumOperationPlace enumOperationPlace);
    }
}
