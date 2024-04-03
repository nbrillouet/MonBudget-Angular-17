using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapSublocalityLevel1Repository
    {
        GMapSublocalityLevel1 GetByLabelOrCreate(string label);
    }

}
