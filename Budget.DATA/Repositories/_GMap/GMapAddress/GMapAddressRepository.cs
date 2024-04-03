using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapAddressRepository : BaseRepository<GMapAddress>, IGMapAddressRepository
    {
        public GMapAddressRepository(BudgetContext context) : base(context)
        {
        }

        public new GMapAddress GetById(int id)
        {
            var result = Context.GMapAddress
                .Where(x => x.Id == id)
                .Include(x => x.GMapCountry)
                .Include(x => x.GMapLocality)
                .Include(x => x.GMapNeighborhood)
                .Include(x => x.GMapPostalCode)
                .Include(x => x.GMapRoute)
                .Include(x => x.GMapStreetNumber)
                .Include(x => x.GMapSublocalityLevel1)
                .Include(x => x.GMapSublocalityLevel2)
                .Include(x => x.GMapAdministrativeAreaLevel1)
                .Include(x => x.GMapAdministrativeAreaLevel2)
                .FirstOrDefault();

            return result;
        }

        public GMapAddress GetByGMapAddress(GMapAddress gMapAddress)
        {
            var result = Context.GMapAddress
                .Where(x => x.IdGMapAdministrativeAreaLevel1 == gMapAddress.IdGMapAdministrativeAreaLevel1
                    && x.IdGMapAdministrativeAreaLevel2 == gMapAddress.IdGMapAdministrativeAreaLevel2
                    && x.IdGMapCountry == gMapAddress.IdGMapCountry
                    && x.IdGMapLocality == gMapAddress.IdGMapLocality
                    && x.IdGMapNeighborhood == gMapAddress.IdGMapNeighborhood
                    && x.IdGMapPostalCode == gMapAddress.IdGMapPostalCode
                    && x.IdGMapRoute == gMapAddress.IdGMapRoute
                    && x.IdGMapStreetNumber == gMapAddress.IdGMapStreetNumber
                    && x.IdGMapSublocalityLevel1 == gMapAddress.IdGMapSublocalityLevel1
                    && x.IdGMapSublocalityLevel2 == gMapAddress.IdGMapSublocalityLevel2)
                .FirstOrDefault();

            return result;
        }
    }

}
