using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.GMap
{
    public interface IGMapStreetNumberRepository
    {
        GMapStreetNumber GetByLabelOrCreate(string label);
    }


}
