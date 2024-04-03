using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapSublocalityLevel2Service
    {
        GMapSublocalityLevel2 GetByLabelOrCreate(string label);
    }


}
