using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapStreetNumberRepository : BaseRepository<GMapStreetNumber>, IGMapStreetNumberRepository
    {
        public GMapStreetNumberRepository(BudgetContext context) : base(context)
        {
        }

        public GMapStreetNumber GetByLabelOrCreate(string label)
        {
            var result = Context.GMapStreetNumber
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapStreetNumber { Id = 0, Label = label });
        }

    }


}
