using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IUserAccountService
    {
        UserAccount Get(int idUser, int idAccount);
        List<User> GetUsers(string accountNumber);
        List<Account> GetAccounts(int idUser);
        List<AccountForDetail> GetAccountsForDetail(int idUser);
        List<AccountForDetail> GetAccountsForDetail(int idUser, int idBankAgency);
        List<AccountForList> GetAccountsForList(int idUser, int idBankAgency);
        User GetUserOwner(string accountNumber);
        List<BankAgencyWithAccountsDto> GetBankAgencies(int idUser);
        List<SelectGroupDto> GetBankSubFamilySelectGroup(int idUser);
        List<SelectCodeUrl> GetBankFamily(int idUser);

        UserAccount Create(UserAccount userAccount);
        void Update(UserAccount userAccount);
        void Delete(UserAccount userAccount);
    }
}
