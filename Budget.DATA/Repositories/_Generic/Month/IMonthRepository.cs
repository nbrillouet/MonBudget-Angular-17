using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IMonthRepository : IBaseRepository<Month>
    {
        List<Month> GetAllByOrder();
        List<Month> GetAnnual();

    }


}
