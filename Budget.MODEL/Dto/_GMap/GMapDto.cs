using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class GMapAddressDto
    {
        public int Id { get; set; }
        public string FormattedAddress { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Select GMapAdministrativeAreaLevel1 { get; set; }
        public Select GMapAdministrativeAreaLevel2 { get; set; }
        public Select GMapCountry { get; set; }
        public Select GMapLocality { get; set; }
        public Select GMapNeighborhood { get; set; }
        public Select GMapPostalCode { get; set; }
        public Select GMapRoute { get; set; }
        public Select GMapStreetNumber { get; set; }
        public Select GMapSublocalityLevel1 { get; set; }
        public Select GMapSublocalityLevel2 { get; set; }
        public List<GMapTypeDto> GMapTypes { get; set; }
    }

    public class GMapTypeDto: SelectCode
    {
        //public int Id { get; set; }
        //public string Keyword { get; set; }
        //public string Label { get; set; }
    }
    
}
