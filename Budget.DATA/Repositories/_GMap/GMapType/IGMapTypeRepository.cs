using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapTypeRepository
    {
        List<GMapType> GetByKeywordOrCreate(List<GMapType> gMapTypes);
    }

}
