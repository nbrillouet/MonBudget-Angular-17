using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public interface IOperationMethodOtfRepository : IBaseRepository<OperationMethodOtf>
    {
        List<OperationTypeFamily> GetOtfList(int idOperationMethod);
    }


}
