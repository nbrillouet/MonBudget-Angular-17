using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class UserPreferenceRepository : BaseRepository<UserPreference>, IUserPreferenceRepository
    {
        public UserPreferenceRepository(BudgetContext context) : base(context)
        {
            
        }

        public UserPreference GetByIdUser(int idUser)
        {
            var result = Context.User
                .Where(x => x.Id == idUser)
                .Select(x => x.UserPreference)
                .FirstOrDefault();

            return result;
        }

    }
}

