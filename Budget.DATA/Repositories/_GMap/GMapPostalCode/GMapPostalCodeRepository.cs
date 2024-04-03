using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapPostalCodeRepository : BaseRepository<GMapPostalCode>, IGMapPostalCodeRepository
    {
        public GMapPostalCodeRepository(BudgetContext context) : base(context)
        {
        }

        public GMapPostalCode GetByLabelOrCreate(string label)
        {
            var result = Context.GMapPostalCode
                .Where(x => x.Label == label)
                .FirstOrDefault();

            if (result != null)
                return result;

            return Create(new GMapPostalCode { Id = 0, Label = label });
        }

    }


}
