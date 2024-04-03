using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class OperationPlaceRepository : BaseRepository<OperationPlace>, IOperationPlaceRepository
    {
        public OperationPlaceRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationPlace> GetSelectListRestrict()
        {
            return Context.OperationPlace
                .Where(x => x.Code == EnumOperationPlace.INTERNET.ToString() || x.Code== EnumOperationPlace.GEO.ToString())
                .OrderBy(x => x.Label)
                .ToList();
        }

    }


}
