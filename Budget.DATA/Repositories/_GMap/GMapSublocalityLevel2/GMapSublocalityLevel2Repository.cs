using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapSublocalityLevel2Repository : BaseRepository<GMapSublocalityLevel2>, IGMapSublocalityLevel2Repository
    {
        public GMapSublocalityLevel2Repository(BudgetContext context) : base(context)
        {
        }

        public GMapSublocalityLevel2 GetByLabelOrCreate(string label)
        {
            var result = Context.GMapSublocalityLevel2
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapSublocalityLevel2 { Id = 0, Label = label });
        }

    }

}
