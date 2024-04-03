using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(BudgetContext context) : base(context)
        {

        }

        public UserAccount Get(int idUser, int idAccount)
        {
            return Context.UserAccount
                .Where(x => x.IdUser == idUser
                    && x.IdAccount == idAccount)
                .FirstOrDefault();
        }

        public List<User> GetUsers(string accountNumber)
        {
            return Context.UserAccount
                .Where(x => x.Account.Number == accountNumber)
                .Select(x => x.User)
                .ToList();
        }

        public List<Account> GetAccounts(int idUser)
        {
            return Context.UserAccount
                .Where(x => x.User.Id == idUser)
                .Include(x => x.Account.AccountType)
                .Select(x => x.Account)
                .ToList();
        }

        public List<Account> GetAccounts(int idUser, int idBankAgency)
        {
            return Context.UserAccount
                .Where(x => x.User.Id == idUser)
                .Where(x=>x.Account.IdBankAgency == idBankAgency)
                .Include(x=>x.Account.AccountType)
                .Select(x => x.Account)
                
                .ToList();
        }

        public List<User> GetLinkedUsers(int idAccount, int idUserExcluded)
        {
            return Context.UserAccount
                .Where(x => x.IdAccount == idAccount)
                .Where(x=>x.IdUser != idUserExcluded)
                .Select(x => x.User)
                .ToList();
        }

        public User GetUserOwner(string accountNumber)
        {
            //recherche du compte
            var account = Context.Account
                .Where(x => x.Number == accountNumber)
                .FirstOrDefault();
            //recherche du user owner
            var user = Context.User
                .Where(x => x.Id == account.IdUserOwner)
                .FirstOrDefault();

            return user;
        }

        public List<BankAgency> GetBankAgencies(int idUser)
        {
            var results = Context.UserAccount
                .Where(x => x.IdUser == idUser)
                .Where(x=>x.ActivationCode==EnumActivationCode.Active.ToString())
                .AsQueryable();

            return GetBankAgencies(results);
        }

        public List<BankAgency> GetBankAgenciesByIdUserGroup(int idUserGroup)
        {
            var results = Context.UserAccount
                .Where(x => x.User.IdUserGroup == idUserGroup)
                .AsQueryable();

            return GetBankAgencies(results);
        }

        public List<BankFamily> GetBankFamily(int idUser)
        {
            var results = Context.UserAccount
                .Where(x => x.IdUser == idUser)
                .Include(x=>x.Account.BankAgency.BankSubFamily.BankFamily.Asset)
                .Select(x => x.Account.BankAgency.BankSubFamily.BankFamily)
                .ToList();

            return results;
        }

        private List<BankAgency> GetBankAgencies(IQueryable<UserAccount> query)
        {
            //TODO retrouver les userAccounts/user
            List<Account> results = query
                .Include(x => x.Account.BankAgency)
                    .ThenInclude(x => x.BankSubFamily)
                    .ThenInclude(x => x.BankFamily)
                        .ThenInclude(x => x.Asset)
                .Include(x => x.Account.AccountType)
                //.Include(x => x.Account.UserAccounts)
                    //.ThenInclude(x => x.User)
                .Select(x => x.Account)
                .ToList();

            var bankAgencies = results.Select(x => x.BankAgency).ToList();
            var distinctBankAgencies = bankAgencies.GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .ToList();

            return distinctBankAgencies;
        }


        //public List<BankSubFamily> GetBankSubFamilies(List<int> idUsers)
        //{
        //    List<Account> results = Context.UserAccount
        //        .Where(x => idUsers.Contains(x.IdUser))
        //        .Select(x => x.Account)
        //        .Include(x => x.BankAgency)
        //            .ThenInclude(x => x.BankSubFamily)
        //            //.ThenInclude(x => x.BankFamily)
        //        //.Include(x => x.AccountType)
        //        //.Include(x => x.UserAccounts)
        //        //    .ThenInclude(ua => ua.User)
        //        .ToList();

        //    var distinctAccounts = results.GroupBy(x => x.Id)
        //        .Select(x => x.FirstOrDefault())
        //        .ToList();

        //    var bankAgencies = results.Select(x => x.BankAgency).ToList();
        //    var bankSubFamilies = bankAgencies.Select(x => x.BankSubFamily).ToList();
        //    return null;
        //}
    }
}
