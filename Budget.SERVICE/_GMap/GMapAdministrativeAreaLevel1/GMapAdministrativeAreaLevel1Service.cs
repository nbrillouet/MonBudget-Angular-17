using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapAdministrativeAreaLevel1Service : IGMapAdministrativeAreaLevel1Service
    {
        private readonly IGMapAdministrativeAreaLevel1Repository _gMapAdministrativeAreaLevel1Repository;

        public GMapAdministrativeAreaLevel1Service(IGMapAdministrativeAreaLevel1Repository gMapAdministrativeAreaLevel1Repository)
        {
            _gMapAdministrativeAreaLevel1Repository = gMapAdministrativeAreaLevel1Repository;
        }

        public GMapAdministrativeAreaLevel1 GetByLabelOrCreate(string label)
        {
            return _gMapAdministrativeAreaLevel1Repository.GetByLabelOrCreate(label);
        }

    }

}
