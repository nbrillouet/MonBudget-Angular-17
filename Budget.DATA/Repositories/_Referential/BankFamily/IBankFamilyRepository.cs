using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IBankFamilyRepository : IBaseRepository<BankFamily>
    {
        List<BankFamily> GetAllOrdering();
        BankFamily GetByCode(string code);
    }

}
