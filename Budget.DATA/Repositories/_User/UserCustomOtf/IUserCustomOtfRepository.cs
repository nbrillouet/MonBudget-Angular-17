using Budget.MODEL.Database;
using System.Collections.Generic;

namespace Budget.DATA.Repositories
{
    public interface IUserCustomOtfRepository : IBaseRepository<UserCustomOtf>
    {
        List<OperationTypeFamily> GetOperationTypeFamilySelect(int idUser,int? idAccount);
        List<UserCustomOtf> Get(int idUser, int? idAccount);
        bool HasOtf(int idOtf);
    }
}
