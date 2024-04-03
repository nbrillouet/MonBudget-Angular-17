using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Budget.DATA.Repositories
{ 
    public class OperationMethodLexicalRepository : BaseRepository<OperationMethodLexical>, IOperationMethodLexicalRepository
    {
        public OperationMethodLexicalRepository(BudgetContext context) : base(context)
        {
        }
        public List<OperationMethodLexical> GetAllByOrder()
        {
            return Context.OperationMethodLexical.OrderBy(x => x.OrderId).ToList();
        }
    }
}
