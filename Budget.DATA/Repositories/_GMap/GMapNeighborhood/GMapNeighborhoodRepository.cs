using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapNeighborhoodRepository : BaseRepository<GMapNeighborhood>, IGMapNeighborhoodRepository
    {
        public GMapNeighborhoodRepository(BudgetContext context) : base(context)
        {
        }

        public GMapNeighborhood GetByLabelOrCreate(string label)
        {
            var result = Context.GMapNeighborhood
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapNeighborhood { Id = 0, Label = label });
        }

    }

}
