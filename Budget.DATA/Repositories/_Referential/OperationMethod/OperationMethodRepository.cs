using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class OperationMethodRepository : BaseRepository<OperationMethod>, IOperationMethodRepository
    {
        public OperationMethodRepository(BudgetContext context) : base(context)
        {
        }
        public List<OperationMethod> GetAllByOrder()
        {
            return Context.OperationMethod.ToList().OrderBy(x => x.Label).ToList();
        }
        public List<OperationMethod> GetAllForEdit()
        {
            return Context.OperationMethod
                .Where(x => x.Id != (int)EnumOperationMethod.Inconnu)
                .OrderBy(x => x.Label).ToList();
        }

        public new int Create(OperationMethod operationMethod)
        {
            Context.Set<OperationMethod>().Add(operationMethod);
            Context.SaveChanges();

            return operationMethod.Id;
        }
        
    }
}
