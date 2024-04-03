using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapNeighborhoodService
    {
        GMapNeighborhood GetByLabelOrCreate(string label);
    }


}
