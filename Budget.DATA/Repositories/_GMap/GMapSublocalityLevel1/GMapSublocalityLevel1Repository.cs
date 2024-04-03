using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapSublocalityLevel1Repository : BaseRepository<GMapSublocalityLevel1>, IGMapSublocalityLevel1Repository
    {
        public GMapSublocalityLevel1Repository(BudgetContext context) : base(context)
        {
        }

        public GMapSublocalityLevel1 GetByLabelOrCreate(string label)
        {
            var result = Context.GMapSublocalityLevel1
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapSublocalityLevel1 { Id = 0, Label = label });
        }


    }

}
