using Budget.DATA.Repositories;
using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class UserShortcutService : IUserShortcutService
    {
        private readonly IUserShortcutRepository _userShortcutRepository;

        public UserShortcutService(IUserShortcutRepository userShortcutRepository)
        {
            _userShortcutRepository = userShortcutRepository;
        }

        //public ValueTask<UserShortcut> GetByIdAsync(int id)
        //{
        //    return _userShortcutRepository.GetByIdAsync(id);
        //}

        public UserShortcut GetById(int id)
        {
            return _userShortcutRepository.GetById(id);
        }

        public UserShortcut Create(UserShortcut shortcut)
        {
            return _userShortcutRepository.Create(shortcut);
        }

        public void Delete(UserShortcut shortcut)
        {
            _userShortcutRepository.Delete(shortcut);
        }
    }
}
