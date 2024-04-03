using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapAddressTypeRepository : IBaseRepository<GMapAddressType>
    {
        //GMapAddressType Create(GMapAddressType gMapAddressType);
        List<GMapType> GetGMapTypeByIdGMapAddress(int idGMapAddress);
        List<GMapAddressType> GetByIdGMapAddress(int idGMapAddress);
    }


}
