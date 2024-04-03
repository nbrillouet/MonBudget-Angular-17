using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapSublocalityLevel1Service : IGMapSublocalityLevel1Service
    {
        private readonly IGMapSublocalityLevel1Repository _gMapSublocalityLevel1Repository;

        public GMapSublocalityLevel1Service(IGMapSublocalityLevel1Repository gMapSublocalityLevel1Repository)
        {
            _gMapSublocalityLevel1Repository = gMapSublocalityLevel1Repository;
        }

        public GMapSublocalityLevel1 GetByLabelOrCreate(string label)
        {
            return _gMapSublocalityLevel1Repository.GetByLabelOrCreate(label);
        }


    }

}
