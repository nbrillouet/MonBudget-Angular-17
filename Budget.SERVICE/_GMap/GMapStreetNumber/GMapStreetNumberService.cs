using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapStreetNumberService : IGMapStreetNumberService
    {
        private readonly IGMapStreetNumberRepository _gMapStreetNumberRepository;

        public GMapStreetNumberService(IGMapStreetNumberRepository gMapStreetNumberRepository)
        {
            _gMapStreetNumberRepository = gMapStreetNumberRepository;
        }

        public GMapStreetNumber GetByLabelOrCreate(string label)
        {
            return _gMapStreetNumberRepository.GetByLabelOrCreate(label);
        }


    }

}
