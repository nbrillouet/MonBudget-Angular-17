using Budget.MODEL;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class MovementRepository : BaseRepository<Movement>, IMovementRepository
    {
        public MovementRepository(BudgetContext context) : base(context)
        {
        }

        public List<Movement> GetAllOrdering()
        {
            return Context.Movement
                .OrderBy(x => x.Label)
                .ToList();
        }

    }

}
