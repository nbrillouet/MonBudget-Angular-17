using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapTypeRepository : BaseRepository<GMapType>, IGMapTypeRepository
    {
        public GMapTypeRepository(BudgetContext context) : base(context)
        {
        }

        public List<GMapType> GetByKeywordOrCreate(List<GMapType> gMapTypes)
        {
            List<GMapType> results = new List<GMapType>();

            foreach (var gMapType in gMapTypes)
            {
                var result = Context.GMapType
                    .Where(x => x.Keyword == gMapType.Keyword.ToUpper())
                    .FirstOrDefault();

                if (result != null)
                {
                    results.Add(result);
                }
   
                else
                {
                    gMapType.Id = 0;
                    results.Add(Create(gMapType));
                }
            }

            return results;
        }

    }


}
