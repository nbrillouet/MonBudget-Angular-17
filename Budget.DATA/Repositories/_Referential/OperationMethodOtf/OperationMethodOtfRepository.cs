using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class OperationMethodOtfRepository : BaseRepository<OperationMethodOtf>, IOperationMethodOtfRepository
    {
        public OperationMethodOtfRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationTypeFamily> GetOtfList(int idOperationMethod)
        {
            return Context.OperationMethodOtf
                .Where(x=>x.IdOperationMethod== idOperationMethod)
                .Include(x => x.OperationTypeFamily.Asset)
                .Select(x=>x.OperationTypeFamily)
                .ToList();
        }
    }
}
