using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapNeighborhoodService : IGMapNeighborhoodService
    {
        private readonly IGMapNeighborhoodRepository _gMapNeighborhoodRepository;

        public GMapNeighborhoodService(IGMapNeighborhoodRepository gMapNeighborhoodRepository)
        {
            _gMapNeighborhoodRepository = gMapNeighborhoodRepository;
        }

        public GMapNeighborhood GetByLabelOrCreate(string label)
        {
            return _gMapNeighborhoodRepository.GetByLabelOrCreate(label);
        }


    }
}
