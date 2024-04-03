using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapTypeLanguageRepository
    {
        GMapTypeLanguage Get(int idGMapType, EnumLanguage enumLanguage);
    }
}
