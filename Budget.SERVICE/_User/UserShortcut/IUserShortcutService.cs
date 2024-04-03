using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IUserShortcutService
    {
        //ValueTask<UserShortcut> GetByIdAsync(int id);
        UserShortcut GetById(int id);
        void Delete(UserShortcut shortcut);

        UserShortcut Create(UserShortcut shortcut);
    }
}
