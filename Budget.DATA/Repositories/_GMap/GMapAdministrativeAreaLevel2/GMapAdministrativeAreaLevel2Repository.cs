using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapAdministrativeAreaLevel2Repository : BaseRepository<GMapAdministrativeAreaLevel2>, IGMapAdministrativeAreaLevel2Repository
    {
        public GMapAdministrativeAreaLevel2Repository(BudgetContext context) : base(context)
        {
        }

        public GMapAdministrativeAreaLevel2 GetByLabelOrCreate(string label)
        {
            var result = Context.GMapAdministrativeAreaLevel2
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapAdministrativeAreaLevel2 { Id = 0, Label = label });
        }

    }
}
