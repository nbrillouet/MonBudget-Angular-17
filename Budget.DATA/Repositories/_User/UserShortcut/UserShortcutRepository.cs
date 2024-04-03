using Budget.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class UserShortcutRepository : BaseRepository<UserShortcut>, IUserShortcutRepository
    {
        public UserShortcutRepository(BudgetContext context) : base(context)
        {
        }

        //public Task<Shortcut> GetByIdAsync(int id)
        //{
        //    return Context.Shortcut
        //        .Where(x => x.Id == id)
        //        .FirstOrDefaultAsync();
        //}

        //public new async Task<Shortcut> Create(Shortcut shortcut)
        //{
        //    await Context.Shortcut.AddAsync(shortcut);
        //    await Context.SaveChangesAsync();

        //    return shortcut;
        //}
    }
}
