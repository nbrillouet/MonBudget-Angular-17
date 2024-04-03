using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IFilterMainService
    {
        FilterAsMainSelection GetFilterAsMainSelection(FilterAsMainSelected filter);
    }
}
