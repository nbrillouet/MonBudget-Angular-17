using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE.GMap
{
    public interface IGMapPostalCodeService
    {
        GMapPostalCode GetByLabelOrCreate(string label);
    }


}
