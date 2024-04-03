using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        PagedList<User> GetUserTable(FilterUserTableSelected filter);
        List<User> GetByIdUserGroup(int idUserGroup);
        User GetByUsername(string username);
        User GetForDetailById(int id);
        User GetLast();
        User GetByActivationCode(string activationCode);
        User GetByMail(string mail);
        User GetForNoTrace(int idUser);
        int GetNewUserGroup();
        UserPreference GetUserPreference(int idUser);
    }

}
