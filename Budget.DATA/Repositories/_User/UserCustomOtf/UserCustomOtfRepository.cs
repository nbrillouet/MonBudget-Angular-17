using Budget.MODEL.Database;
using System.Collections.Generic;
using System.Linq;


namespace Budget.DATA.Repositories
{
    public class UserCustomOtfRepository : BaseRepository<UserCustomOtf>, IUserCustomOtfRepository
    {
        public UserCustomOtfRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationTypeFamily> GetOperationTypeFamilySelect(int idUser, int? idAccount)
        {
            var results = Context.UserCustomOtf
                .Where(x => x.IdUser == idUser)
                .AsQueryable();

            if(idAccount.HasValue)
            {
                results = results.Where(x => x.IdAccount == idAccount.Value);
            }

            var output = results.Select(x => x.OperationTypeFamily);

            return output.ToList();
        }

        public List<UserCustomOtf> Get(int idUser, int? idAccount)
        {
            var results = Context.UserCustomOtf
                .Where(x => x.IdUser == idUser)
                .AsQueryable();

            if (idAccount.HasValue)
            {
                results = results.Where(x => x.IdAccount == idAccount.Value);
            }

            return results.ToList(); ;
        }

        public bool HasOtf(int idOtf)
        {
            var result = Context.UserCustomOtf
                .Where(x => x.IdOperationTypeFamily == idOtf)
                .Any();

            return result;
        }

    }
}
