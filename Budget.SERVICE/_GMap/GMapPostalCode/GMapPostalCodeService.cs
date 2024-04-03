using Budget.DATA.Repositories.GMap;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public class GMapPostalCodeService : IGMapPostalCodeService
    {
        private readonly IGMapPostalCodeRepository _gMapPostalCodeRepository;

        public GMapPostalCodeService(IGMapPostalCodeRepository gMapPostalCodeRepository)
        {
            _gMapPostalCodeRepository = gMapPostalCodeRepository;
        }

        public GMapPostalCode GetByLabelOrCreate(string label)
        {
            return _gMapPostalCodeRepository.GetByLabelOrCreate(label);
        }


    }

}
