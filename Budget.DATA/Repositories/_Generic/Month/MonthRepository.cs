using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class MonthRepository : BaseRepository<Month>, IMonthRepository
    {
        public MonthRepository(BudgetContext context) : base(context)
        {

        }

        //prendre tous les mois sauf celui du lissage sur année
        public List<Month> GetAllByOrder()
        {
            var months = Context.Month
                .Where(x=>x.Number!="XX")
                .OrderBy(x=>x.Id)
                .ToList();
            return months;
        }

        public List<Month> GetAnnual()
        {
            var months = Context.Month
                .Where(x => x.Number == "XX")
                .OrderBy(x => x.Id)
                .ToList();
            return months;
        }
    }
}
