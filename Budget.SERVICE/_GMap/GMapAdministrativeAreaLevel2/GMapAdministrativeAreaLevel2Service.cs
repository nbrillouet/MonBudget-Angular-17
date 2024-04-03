using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapAdministrativeAreaLevel2Service : IGMapAdministrativeAreaLevel2Service
    {
        private readonly IGMapAdministrativeAreaLevel2Repository _gMapAdministrativeAreaLevel2Repository;

        public GMapAdministrativeAreaLevel2Service(IGMapAdministrativeAreaLevel2Repository gMapAdministrativeAreaLevel2Repository)
        {
            _gMapAdministrativeAreaLevel2Repository = gMapAdministrativeAreaLevel2Repository;
        }

        public GMapAdministrativeAreaLevel2 GetByLabelOrCreate(string label)
        {
            return _gMapAdministrativeAreaLevel2Repository.GetByLabelOrCreate(label);
        }

    }
}
