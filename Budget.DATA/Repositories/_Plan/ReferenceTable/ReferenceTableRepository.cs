using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class ReferenceTableRepository : BaseRepository<ReferenceTable>, IReferenceTableRepository
    {
        public ReferenceTableRepository(BudgetContext context) : base(context)
        {

        }
    }


}
