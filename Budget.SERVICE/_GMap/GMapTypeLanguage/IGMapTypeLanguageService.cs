using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapTypeLanguageService
    {
        GMapTypeLanguage Get(int idGMapType, EnumLanguage enumLanguage);

    }
}
