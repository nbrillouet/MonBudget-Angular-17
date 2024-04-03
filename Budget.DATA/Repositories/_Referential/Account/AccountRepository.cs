using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(BudgetContext context) : base(context)
        {
        }

        public PagedList<Account> GetForTable(FilterAccountTableSelected filter)
        {
            //retrouver UserAccounts/Account
            var accounts = Context.Account
                //.Where(x => x.UserAccounts.Any(o => o.IdUser == filter.User.Id))
                .Include(x => x.BankAgency)
                .Include(x=>x.BankAgency.BankSubFamily)
                .Include(x => x.BankAgency.BankSubFamily.BankFamily)
                        //.ThenInclude(x => x.BankSubFamily)
                        .ThenInclude(x => x.Asset)
                .Include(x => x.AccountType)
                //.Include(x => x.UserAccounts)
                    //.ThenInclude(ua => ua.User)
                
                .AsQueryable();


            accounts = GenericTableFilter.GetGenericFilters(accounts, filter);
            if(filter.BankFamily!=null && filter.BankFamily.Count>0)
            {
                List<int> bankFamilyIdList = filter.BankFamily.Select(x => x.Id).ToList();
                accounts = accounts.Where(x => bankFamilyIdList.Contains(x.BankAgency.BankSubFamily.BankFamily.Id));//  x.BankAgency.BankSubFamily.BankFamily.Id)
            }

            var results = PagedListRepository<Account>.Create(accounts, filter.Pagination);
            return results;
        }

        public Account GetForDetail(int idAccount)
        {
            return Context.Account
                .Where(x => x.Id == idAccount)
                .Include(x => x.BankAgency.GMapAddress)
                .Include(x => x.BankAgency)
                    .ThenInclude(x => x.BankSubFamily)
                        .ThenInclude(x => x.BankFamily)
                            .ThenInclude(x => x.Asset)
                .Include(x => x.AccountType)
                .FirstOrDefault();
        }

        public Account GetByNumber(string number)
        {
            return Context.Account
                .Where(x => x.Number == number)
                .Include(x=>x.BankAgency)
                    .ThenInclude(x=>x.BankSubFamily)
                        .ThenInclude(x=>x.BankFamily)
                .FirstOrDefault();
        }

        //public new Account Create(Account account)
        //{
        //    Context.Set<Account>().Add(account);
        //    Context.SaveChanges();

        //    return account;
        //}

        public List<Account> GetByIdBankAgency(int idBankAgency)
        {
            return Context.Account
                .Where(x => x.Id != (int)EnumAccount.Inconnu 
                    && x.IdBankAgency == idBankAgency)
                .ToList();
        }
    }
}
