using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapAddressRepository 
    {
        GMapAddress Create(GMapAddress gMapAddressType);
        GMapAddress GetById(int id);
        GMapAddress GetByGMapAddress(GMapAddress gMapAddress);
    }
}
