using Budget.MODEL;
using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class AccountStatementImportRepository : BaseRepository<AccountStatementImport>, IAccountStatementImportRepository
    {
        public AccountStatementImportRepository(BudgetContext context) : base(context)
        {
        }

        public AccountStatementImport GetByIdForDetail(int id)
        {
            return Context.AccountStatementImport
                .Where(x => x.Id == id)
                .Include(x => x.User)
                .Include(x => x.BankAgency)
                .First();
        }
        public PagedList<AccountStatementImport> GetAsiTable(FilterAsiTableSelected filter)
        {
            var accountStatementImports = Context.AccountStatementImport
                .Include(x => x.User)
                .AsQueryable();
            accountStatementImports = GenericTableFilter.GetGenericFilters(accountStatementImports, filter);

            //if (filter.IdUser.HasValue)
            //{
            //    accountStatementImports = accountStatementImports.Where(x => x.IdUser == filter.IdUser);
            //}
            //if (filter.IdBankAgency.HasValue)
            //{
            //    accountStatementImports = accountStatementImports.Where(x => x.IdBankAgency == filter.IdBankAgency);
            //}

            //if (filter.Pagination.SortDirection == "asc")
            //{
            //    accountStatementImports = accountStatementImports.OrderBy(filter.Pagination.SortColumn);
            //}
            //else
            //{
            //    accountStatementImports = accountStatementImports.OrderByDescending(filter.Pagination.SortColumn);
            //}
            var results = PagedListRepository<AccountStatementImport>.Create(accountStatementImports, filter.Pagination);

            return results;
        }
        
        public List<AccountStatementImport> GetByIdBankAgency(int idBankAgency, int idUser)
        {
            var results = Context.AccountStatementImport
                 .Where(x => x.IdUser == idUser)
                 .Where(x => x.IdBankAgency == idBankAgency)
                 .ToList();

            return results;
        }

        public AccountStatementImport GetEagerById(int idImport)
        {
            var result = Context.AccountStatementImport
                .Where(x=>x.Id== idImport)
                .Include(x => x.BankAgency)
                .Include(x => x.User)
                .FirstOrDefault();

            return result;
        }

        public List<BankAgency> GetDistinctBankAgencies(int idUser)
        {
            var accountStatementImport = Context.AccountStatementImport
                .Include(x => x.BankAgency)
                    .ThenInclude(x => x.BankSubFamily)
                        .ThenInclude(x => x.Asset)
                .Include(x => x.BankAgency)
                    .ThenInclude(x => x.BankSubFamily)
                        .ThenInclude(x => x.BankFamily)
                            .ThenInclude(x=>x.Asset)
                .Where(x => x.IdUser == idUser)

                .ToList();
            var bankAgencies = accountStatementImport
                .Select(x => x.BankAgency)
                .Distinct()
                .ToList();

            return bankAgencies;
        }

        public User GetUser(int idImport)
        {
            var result = Context.AccountStatementImport
                .Include(x => x.User)
                .Select(x => x.User)
                .FirstOrDefault();

            return result;
        }

        //public new int Create(AccountStatementImport entity)
        //{
        //    Context.Set<AccountStatementImport>().Add(entity);

        //    Context.SaveChanges();

        //    return entity.Id;
        //}

        

        public List<AccountStatement> ImportFile()
        {
            return null;
        }

    }
}
