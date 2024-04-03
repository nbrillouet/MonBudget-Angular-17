using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public class GMapTypeLanguageRepository : BaseRepository<GMapTypeLanguage>, IGMapTypeLanguageRepository
    {
        public GMapTypeLanguageRepository(BudgetContext context) : base(context)
        {
        }

        public GMapTypeLanguage Get(int idGMapType, EnumLanguage enumLanguage)
        {
            var result = Context.GMapTypeLanguage
                .Where(x => x.CountryCode == enumLanguage.ToString()
                    && x.IdGMapType == idGMapType)
                .FirstOrDefault();

            return result;
        }

    }
}
