using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{

    public interface IGMapSublocalityLevel2Repository
    {
        GMapSublocalityLevel2 GetByLabelOrCreate(string label);
    }


}
