using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapSublocalityLevel2Service : IGMapSublocalityLevel2Service
    {
        private readonly IGMapSublocalityLevel2Repository _gMapSublocalityLevel2Repository;

        public GMapSublocalityLevel2Service(IGMapSublocalityLevel2Repository gMapSublocalityLevel2Repository)
        {
            _gMapSublocalityLevel2Repository = gMapSublocalityLevel2Repository;
        }

        public GMapSublocalityLevel2 GetByLabelOrCreate(string label)
        {
            return _gMapSublocalityLevel2Repository.GetByLabelOrCreate(label);
        }

    }


}
