using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapCountryRepository : BaseRepository<GMapCountry>, IGMapCountryRepository
    {
        public GMapCountryRepository(BudgetContext context) : base(context)
        {
        }

        public GMapCountry GetByLabelOrCreate(string label)
        {
            var result = Context.GMapCountry
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapCountry { Id = 0, Label = label });
        }

    }


}
