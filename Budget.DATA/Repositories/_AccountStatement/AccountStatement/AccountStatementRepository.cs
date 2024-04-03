using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Budget.MODEL.Enum;

namespace Budget.DATA.Repositories
{
    public class AccountStatementRepository : BaseRepository<AccountStatement>, IAccountStatementRepository
    {
        public AccountStatementRepository(BudgetContext context) : base(context)
        {
        }

        public PagedList<AccountStatement> GetAsTable(FilterAsTableSelected filter)
        {
            var accountStatements = Context.AccountStatement
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationType.OperationTypeFamily)
                .AsQueryable();

            //if (filter.MonthYear != null)
            //{
            //    var date = Convert.ToDateTime($"01/{filter.MonthYear.Month.Id}/{filter.MonthYear.Year}");
            //    var dateMin = DateHelper.GetFirstDayOfMonth(date);
            //    var dateMax = DateHelper.GetLastDayOfMonth(date);

            //    accountStatements = accountStatements
            //            .Where(x => x.DateIntegration >= dateMin && x.DateIntegration <= dateMax);

            //}

            accountStatements = GenericTableFilter.GetGenericFilters(accountStatements, filter);
            var results = accountStatements.ToList();

            return PagedListRepository<AccountStatement>.Create(accountStatements, filter.Pagination);
        }

        public PagedList<AccountStatement> GetPlanNotAsTable(FilterPlanNotAsTableGroupSelected filter)
        {
            var accountStatements = Context.AccountStatement
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationType.OperationTypeFamily)
                .AsQueryable();

            accountStatements = accountStatements.Where(x => x.DateIntegration.Value.Year == filter.FilterFixedPlanNotAsTableSelected.Year);
            //accountStatements = accountStatements.Where(x => x.OperationTypeFamily.Id != filter.FilterFixedPlanNotAsTableSelected.IdInternalTransfert);
            accountStatements = accountStatements.Where(x => filter.FilterFixedPlanNotAsTableSelected.Accounts.Contains(x.IdAccount));
            accountStatements = accountStatements.Where(x => !filter.FilterFixedPlanNotAsTableSelected.AsInPlan.Contains(x.Id));

            accountStatements = GenericTableFilter.GetGenericFilters(accountStatements, filter.FilterPlanNotAsTableSelected);

            return PagedListRepository<AccountStatement>.Create(accountStatements, filter.FilterPlanNotAsTableSelected.Pagination);
        }

        public int GetPlanNotAsCount(FilterFixedPlanNotAsTableSelected filterFixed)
        {
            var accountStatements = Context.AccountStatement
                .AsQueryable();

            accountStatements = accountStatements.Where(x => x.DateIntegration.Value.Year == filterFixed.Year);
            accountStatements = accountStatements.Where(x => x.OperationTypeFamily.Id != filterFixed.IdInternalTransfert);
            accountStatements = accountStatements.Where(x => filterFixed.Accounts.Contains(x.IdAccount));
            accountStatements = accountStatements.Where(x => !filterFixed.AsInPlan.Contains(x.Id));

            return accountStatements.ToList().Count();
        }

        public AccountStatement GetForDetail(int id)
        {
            var accountStatement = Context.AccountStatement
                .Include(x=>x.Account)
                .Include(x => x.AccountStatementImport)
                    .Include(x=>x.AccountStatementImport.User)
                .Include(x=>x.OperationDetail)
                    .Include(x => x.OperationDetail.OperationPlace)
                    .Include(x => x.OperationDetail.GMapAddress)
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationTypeFamily)
                    .Include(x=>x.OperationTypeFamily.Asset)
                .Include(x => x.OperationDetail)
                    .Include(x => x.OperationDetail.GMapAddress.GMapAdministrativeAreaLevel1)
                    .Include(x => x.OperationDetail.GMapAddress.GMapAdministrativeAreaLevel2)
                    .Include(x => x.OperationDetail.GMapAddress.GMapCountry)
                    .Include(x => x.OperationDetail.GMapAddress.GMapLocality)
                    .Include(x => x.OperationDetail.GMapAddress.GMapNeighborhood)
                    .Include(x => x.OperationDetail.GMapAddress.GMapPostalCode)
                    .Include(x => x.OperationDetail.GMapAddress.GMapRoute)
                    .Include(x => x.OperationDetail.GMapAddress.GMapStreetNumber)
                    .Include(x => x.OperationDetail.GMapAddress.GMapSublocalityLevel1)
                    .Include(x => x.OperationDetail.GMapAddress.GMapSublocalityLevel2)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return accountStatement;
        }

        public List<AccountStatement> GetByDateIdOperationTypeFamilyList(List<int> idOperationtypeFamilyList, DateTime dateMin,DateTime dateMax)
        {
            var results = Context.AccountStatement
                .Where(x => idOperationtypeFamilyList.Contains(x.IdOperationTypeFamily)
                    && x.DateIntegration >= dateMin 
                    && x.DateIntegration <= dateMax)
                .ToList();

            return results;
        }

        public List<AccountStatement> GetByDatePlanPosteReferenceList(Poste poste, List<PlanAccount> planAccounts, List<PlanPosteReference> planPosteReferences, DateTime dateMin, DateTime dateMax)
        {
            var accountStatements = Context.AccountStatement
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationType.OperationTypeFamily)
                .AsQueryable();

            //IdAccounts
            var idAccounts = planAccounts
                 .Select(x => x.IdAccount)
                 .ToList();

            accountStatements = accountStatements
                .Where(x=> idAccounts.Contains(x.IdAccount))
                .Where(x=>x.IdMovement == poste.IdMovement)
                .AsQueryable();

            // IdReferenceTable
            //case 1: //OPERATION_TYPE_FAMILY
            var idOperationTypeFamilyList = planPosteReferences
                .Where(x => x.IdReferenceTable == 1)
                .Select(x => x.IdReference)
                .ToList();

            var resultOperationTypeFamilies = accountStatements
                .Where(x => idOperationTypeFamilyList.Contains(x.IdOperationTypeFamily)
                    && x.DateIntegration >= dateMin
                    && x.DateIntegration <= dateMax)
                .ToList();

            //case 2: // "OPERATION_TYPE"
            var idOperationTypeList = planPosteReferences
                .Where(x => x.IdReferenceTable == 2)
                .Select(x => x.IdReference)
                .ToList();

            var resultOperationTypes = accountStatements
                .Where(x => idOperationTypeList.Contains(x.IdOperationType)
                    && x.DateIntegration >= dateMin
                    && x.DateIntegration <= dateMax)
                .ToList();

            //case 3: OPERATION
            var idOperationList = planPosteReferences
               .Where(x => x.IdReferenceTable == 3)
               .Select(x => x.IdReference)
               .ToList();

            var resultOperations = accountStatements
                .Where(x => idOperationList.Contains(x.IdOperation)
                    && x.DateIntegration >= dateMin
                    && x.DateIntegration <= dateMax)
                .ToList();

            resultOperationTypeFamilies.AddRange(resultOperationTypes);
            resultOperationTypeFamilies.AddRange(resultOperations);

            return resultOperationTypeFamilies;
        }

        //public Boolean Save(List<AccountStatement> accountStatements)
        //{
        //    //Enregistrement si la ligne d'operation n'existe pas deja en base
        //    foreach (var item in accountStatements)
        //    {
        //        Save(item);
        //        //var duplicate = Context.AccountStatement
        //        //    .Where(x => x.DateOperation == item.DateOperation
        //        //    && x.IdAccount == item.IdAccount
        //        //    && x.IdMovement == item.IdMovement
        //        //    && x.IdOperation == item.IdOperation
        //        //    && x.IdOperationMethod == item.IdOperationMethod
        //        //    && x.DateIntegration == item.DateIntegration
        //        //    && x.LabelOperation == item.LabelOperation
        //        //    && x.AmountOperation == item.AmountOperation).FirstOrDefault();

        //        //if (duplicate == null)
        //        //{
        //        //    Create(item);
        //        //}
        //    }

        //    return true;
        //}

        public bool IsDuplicate(AccountStatement accountStatement)
        {
            return Context.AccountStatement
                    .Where(x => x.DateOperation == accountStatement.DateOperation
                    && x.IdAccount == accountStatement.IdAccount
                    && x.IdMovement == accountStatement.IdMovement
                    && x.IdOperation == accountStatement.IdOperation
                    && x.IdOperationMethod == accountStatement.IdOperationMethod
                    && x.IdOperationDetail == accountStatement.IdOperationDetail
                    && x.DateIntegration == accountStatement.DateIntegration
                    && x.LabelAs == accountStatement.LabelAs
                    && x.AmountOperation == accountStatement.AmountOperation)
                    .Any();
        }

        //public new AccountStatement Create(AccountStatement accountStatement)
        //{
        //    var duplicate = Context.AccountStatement
        //            .Where(x => x.DateOperation == accountStatement.DateOperation
        //            && x.IdAccount == accountStatement.IdAccount
        //            && x.IdMovement == accountStatement.IdMovement
        //            && x.IdOperation == accountStatement.IdOperation
        //            && x.IdOperationMethod == accountStatement.IdOperationMethod
        //            && x.IdOperationDetail == accountStatement.IdOperationDetail
        //            && x.DateIntegration == accountStatement.DateIntegration
        //            && x.LabelAs == accountStatement.LabelAs
        //            && x.AmountOperation == accountStatement.AmountOperation).FirstOrDefault();

        //    if (duplicate == null)
        //    {
        //        return Create(accountStatement);
        //    }

        //    return accountStatement;
        //}

        public SoldeDto GetSolde(int? idUser, int? idAccount, DateTime dateMin, DateTime dateMax, bool isWithITransfer)
        {
            //FromSqlInterpolated($"StoredProcedureName {param1},{param2}").tolist()
            //var books = Context.AccountStatement
            //    .FromSqlRaw("EXEC [as].spGetSolde @idUser,@idAccount,@dateStart,@isWithITransfer",
            //        idUser ?? (object)DBNull.Value,
            //        idAccount ?? (object)DBNull.Value,
            //        dateMin,
            //        dateMax,
            //        isWithITransfer)
            //    .ToList();


            var result = Context.Set<SoldeDto>()
                .FromSqlRaw("EXEC [as].spGetSolde @idUser,@idAccount,@dateStart,@dateEnd,@isWithITransfer",
                    new SqlParameter("@idUser", idUser ?? (object)DBNull.Value),
                    new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
                    new SqlParameter("@dateStart", dateMin),
                    new SqlParameter("@dateEnd", dateMax),
                    new SqlParameter("@isWithITransfer", isWithITransfer))
                //.IgnoreQueryFilters()
                .ToList();
            return result.FirstOrDefault();
        }

        public List<AccountStatement> GetAsInternalTransfer(int idUserGroup, int? idAccount, DateTime dateMin, DateTime dateMax)
        {
            //Recherche du virement interne dans referentiel
            var virementInterne = Context.OperationType
                .Where(x => x.Code == EnumOperationType.VIRI.ToString() 
                && x.IdUserGroup == idUserGroup)
                .FirstOrDefault();

            //Recherche des virement internes dans as
            var its = Context.AccountStatement
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationType.OperationTypeFamily)
                .Include(x => x.Account.BankAgency)
                .AsQueryable();

            if (idAccount.HasValue)
            {
                its = its.Where(x => x.IdAccount == idAccount.Value);
            }
            //var toto = its.ToList();
            its = its.Where(
                x => x.DateIntegration >= dateMin && 
                x.DateIntegration <= dateMax && 
                x.IdOperationType== virementInterne.Id);

            return its.ToList();
        }

        public AccountStatement GetAsInternalTransferCouple(int idUserGroup, int idAccountStatement)
        {
            var results = Context.Set<AccountStatement>()
               .FromSqlRaw("[as].spGetAsInternalTransferCouple @idAccountStatement,@idUserGroup",
                   new SqlParameter("@idAccountStatement", idAccountStatement),
                   new SqlParameter("@idUserGroup", idUserGroup))
               .ToList();

            return results.FirstOrDefault();
            //return Context.Set<AccountStatement>()
            //   .FromSqlRaw("[as].spGetAsInternalTransferCouple @idAccountStatement,@idUserGroup",
            //       new SqlParameter("@idAccountStatement", idAccountStatement),
            //       new SqlParameter("@idUserGroup", idUserGroup))
            //   .FirstOrDefault();
        }

        public List<AccountStatement> GetAsInternalTransferOrphan(int idUserGroup)
        {
            var results = Context.Set<AccountStatement>()
                .Where(x=>x.OperationTypeFamily.IdUserGroup== idUserGroup)
                .Where(x => x.OperationTypeFamily.Code == EnumOtf.VIRI.ToString())
                .Where(x => x.IdAccountIt == null)
                .ToList();
            //var accountStatements = Context.Set<AccountStatement>()
            //   .FromSqlRaw("[as].spGetAsInternalTransferOrphan @idUserGroup",
            //       new SqlParameter("@idUserGroup", idUserGroup))
            //   .ToList();
            return results;
        }

        /// <summary>
        /// trouver couple virement interne via solde/jour
        /// </summary>
        /// <param name="asOrphan"></param>
        /// <returns></returns>
        public List<AccountStatement> GetAsInternalTransferCouple(AccountStatement asOrphan)
        {
            var results = Context.Set<AccountStatement>()
                .Where(x => x.DateIntegration == asOrphan.DateIntegration)
                .Where(x => x.AmountOperation == -asOrphan.AmountOperation)
                .ToList();

            return results;
        }

        //rechercher les années disponibles pour un compte et un user entré en parametre
        public List<int> GetYearAvailable(int idUser, int idAccount)
        {
            var results = Context.AccountStatement
                .Where(x => x.AccountStatementImport.IdUser == idUser)
                .Where(x => x.IdAccount == idAccount)
                .GroupBy(x => new { x.DateIntegration.Value.Year })
                    .Select(g => g.Key.Year)
                    .OrderByDescending(x=>x)
                .ToList();

            return results;

        }

        public bool HasOperation(int idOperation)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdOperation == idOperation)
                .Any();

            return result;
        }

        public bool HasOt(int idOt)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdOperationType == idOt)
                .Any();

            return result;
        }

        public bool HasOtf(int idOtf)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdOperationTypeFamily == idOtf)
                .Any();

            return result;
        }

        public bool HasAsi(int idAsi)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdImport == idAsi)
                .Any();

            return result;
        }

        public AccountStatement GetLastAccountStatement(int idAccount)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdAccount == idAccount)
                .OrderByDescending(x => x.DateIntegration)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// recherche du couple virement interne a partir:
        /// -id account du source
        /// -jour de la transaction
        /// -montant de la transaction
        /// </summary>
        /// <param name="accountStatement"></param>
        /// <returns></returns>
        public AccountStatement SearchInternalTransferCouple(AccountStatement accountStatement)
        {
            var result = Context.AccountStatement
                .Where(x => x.IdAccount == accountStatement.IdAccountIt)
                .Where(x => x.DateIntegration == accountStatement.DateIntegration)
                .Where(x => Math.Abs(x.AmountOperation) == Math.Abs(accountStatement.AmountOperation))
                .ToList();

            if (result.Count == 1)
                return result[0];
            else
                return null;
        }


    }
}
