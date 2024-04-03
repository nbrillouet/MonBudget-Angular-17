using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapLocalityService : IGMapLocalityService
    {
        private readonly IGMapLocalityRepository _gMapLocalityRepository;

        public GMapLocalityService(IGMapLocalityRepository gMapLocalityRepository)
        {
            _gMapLocalityRepository = gMapLocalityRepository;
        }

        public GMapLocality GetByLabelOrCreate(string label)
        {
            return _gMapLocalityRepository.GetByLabelOrCreate(label);
        }


    }

}
