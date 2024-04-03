using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapAdministrativeAreaLevel1Repository : BaseRepository<GMapAdministrativeAreaLevel1>, IGMapAdministrativeAreaLevel1Repository
    {
        public GMapAdministrativeAreaLevel1Repository(BudgetContext context) : base(context)
        {
        }

        public GMapAdministrativeAreaLevel1 GetByLabelOrCreate(string label)
        {
            var result = Context.GMapAdministrativeAreaLevel1
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            result = Create(new GMapAdministrativeAreaLevel1 { Id=0, Label= label});
            return result;
        }

    }

}
