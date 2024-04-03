using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IReferenceTableService
    {
        List<ReferenceTable> GetAll();
    }


}
