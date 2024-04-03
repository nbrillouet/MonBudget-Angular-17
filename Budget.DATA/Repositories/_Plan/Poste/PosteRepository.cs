using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class PosteRepository : BaseRepository<Poste>, IPosteRepository
    {
        public PosteRepository(BudgetContext context) : base(context)
        {

        }

        public List<Poste> GetAllEager()
        {
            var results = Context.Poste
                .Include(x => x.Movement)
                .ToList();

            return results;
        }
    }

}
