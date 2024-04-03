using Budget.MODEL;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IUserAccountRepository : IBaseRepository<UserAccount>
    {
        UserAccount Get(int idUser, int idAccount);
        List<User> GetUsers(string accountNumber);
        List<Account> GetAccounts(int idUser);
        List<Account> GetAccounts(int idUser, int idBankAgency);
        List<User> GetLinkedUsers(int idAccount, int idUserExcluded);
        User GetUserOwner(string accountNumber);
        List<BankAgency> GetBankAgencies(int idUser);
        List<BankAgency> GetBankAgenciesByIdUserGroup(int idUserGroup);
        List<BankFamily> GetBankFamily(int idUser);

    }
}
