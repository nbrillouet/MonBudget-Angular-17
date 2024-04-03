using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        PagedList<Account> GetForTable(FilterAccountTableSelected filterAccountTableSelected);
        Account GetForDetail(int idAccount);
        Account GetByNumber(string number);
        List<Account> GetByIdBankAgency(int idBankAgency);

        new Account Create(Account account);

    }
}
