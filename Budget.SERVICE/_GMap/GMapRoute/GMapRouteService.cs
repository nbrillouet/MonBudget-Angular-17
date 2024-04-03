using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapRouteService : IGMapRouteService
    {
        private readonly IGMapRouteRepository _gMapRouteRepository;

        public GMapRouteService(IGMapRouteRepository gMapRouteRepository)
        {
            _gMapRouteRepository = gMapRouteRepository;
        }

        public GMapRoute GetByLabelOrCreate(string label)
        {
            return _gMapRouteRepository.GetByLabelOrCreate(label);
        }


    }


}
