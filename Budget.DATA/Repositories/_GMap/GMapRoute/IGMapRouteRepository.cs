using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapRouteRepository
    {
        GMapRoute GetByLabelOrCreate(string label);
    }


}
