using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BudgetContext context) : base(context)
        {

        }

        public PagedList<User> GetUserTable(FilterUserTableSelected filter)
        {
            var users = Context.User
                //.Include(x => x.Shortcuts)
                .AsQueryable();

            if (filter.Keyword != null)
            {
                users = users.Where(x => x.FirstName.ToUpper().Contains(filter.Keyword.ToUpper())
                    || x.LastName.ToUpper().Contains(filter.Keyword.ToUpper())
                    || x.UserName.ToUpper().Contains(filter.Keyword.ToUpper())
                    );
            }
            
            if (filter.Pagination.SortDirection == "asc")
                users = users.OrderBy(filter.Pagination.SortColumn);
            else
                users = users.OrderByDescending(filter.Pagination.SortColumn);

            var results = PagedListRepository<User>.Create(users, filter.Pagination);

            return results;
        }

        
        public User GetForDetailById(int id)
        {
            return Context.User
                .Where(x => x.Id == id)
                //.Include(x => x.Shortcuts)
                .FirstOrDefault();
        }

        public List<User> GetByIdUserGroup(int idUserGroup)
        {
            return Context.User
                .Where(x => x.IdUserGroup == idUserGroup)
                .OrderBy(x => x.LastName)
                .ToList();
        }

        public UserPreference GetUserPreference(int idUser)
        {
            return Context.User
                .Where(x => x.Id == idUser)
                .Select(x=>x.UserPreference)
                .First();
        }

        public User GetLast()
        {
            return Context.User
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
        }

        public User GetByActivationCode(string activationCode)
        {
            return Context.User
                .Where(x => x.ActivationCode == activationCode)
                .Include(x => x.UserPreference)
                .FirstOrDefault();
        }

        public int GetNewUserGroup()
        {
            var user = Context.User
                .OrderByDescending(x => x.IdUserGroup)
                .FirstOrDefault();

            return user.IdUserGroup + 1;
        }

        public User GetByMail(string mail)
        {
            var user = Context.User
                .Where(x => x.Email == mail)
                .Include(x => x.UserPreference)
                .FirstOrDefault();

            return user;
        }

        public User GetByUsername(string username)
        {
            var user = Context.User
                .Where(x => x.UserName == username)
                .Include(x=>x.UserPreference)
                .FirstOrDefault();

            return user;
        }

        public User GetForNoTrace(int idUser)
        {
            var user = Context.User
                .Where(x => x.Id == idUser)
                .AsNoTracking()
                .FirstOrDefault();

            return user;
        }

    }
}
