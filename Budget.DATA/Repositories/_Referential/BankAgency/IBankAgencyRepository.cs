using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IBankAgencyRepository : IBaseRepository<BankAgency>
    {
        List<BankAgency> GetByIdBankSubFamily(int idBankSubFamily);
        List<BankAgency> GetAllOrdering();
    }


}
