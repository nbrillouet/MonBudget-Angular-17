using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public class AccountStatementImportFileRepository : BaseRepository<AccountStatementImportFile>, IAccountStatementImportFileRepository
    {
        public AccountStatementImportFileRepository(BudgetContext context) : base(context)
        {
        }

        public List<AccountStatementImportFile> GetByIdImport(int IdImport)
        {
            var results = Context.AccountStatementImportFile
                .Where(x => x.IdImport == IdImport)
                .Include(x => x.AccountStatementImport.User)
                .ToList();

            return results;

        }

        public AccountStatementImportFile GetForDetail(int id)
        {
            var accountStatementImportFile = Context.AccountStatementImportFile
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationTypeFamily)
                    .Include(x => x.OperationTypeFamily.Asset)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return  accountStatementImportFile;
        }

        public bool IsAccountStatementSaveable(int idImport)
        {
            var result = Context.AccountStatementImportFile
                .Where(x=>x.IdImport== idImport)
                .Where(x => x.IdState != (int)EnumStateAsif.Complete)
                .Any();

            return !result;
        }

        public List<string> GetDistinctAccountNumber(int idImport)
        {
            List<string> accounts = new List<string>();
            var accountList = Context.AccountStatementImportFile
                .Where(x => x.IdImport == idImport)
                .Select(x => x.Account.Number)
                .Distinct()
                .ToList();
            foreach (var account in accountList)
            {
                accounts.Add(account);
            }
            return accounts;
        }

        public PagedList<AccountStatementImportFile> GetAsifTable(FilterAsifTableSelected filter)
        {
            var accountStatementImportFiles = Context.AccountStatementImportFile
                .Include(x => x.Operation)
                .Include(x => x.OperationMethod)
                .Include(x => x.OperationType)
                .Include(x => x.OperationTypeFamily)
                .AsQueryable();

            accountStatementImportFiles = GenericTableFilter.GetGenericFilters(accountStatementImportFiles, filter);

            return PagedListRepository<AccountStatementImportFile>.Create(accountStatementImportFiles, filter.Pagination); ;
        }

        public List<Select> GetAsifStates (int idImport, int idAccount)
        {
            List<Select> asifStates = new List<Select>();

            if(HasAsifMethodLess(idImport, idAccount))
            {
                asifStates.Add(new Select { Id = (int)EnumStateAsif.MethodLess, Label = "Erreur méthode" });
            }
            if (HasAsifOperationLess(idImport, idAccount))
            {
                asifStates.Add(new Select { Id = (int)EnumStateAsif.OperationLess, Label = "Erreur opération" });
            }
            if (HasAsifComplete(idImport, idAccount))
            {
                asifStates.Add(new Select { Id = (int)EnumStateAsif.Complete, Label = "complet" });
            }

            return asifStates;
        }

        private Boolean HasAsifComplete(int idImport, int idAccount)
        {
            return Context.AccountStatementImportFile
                .Where(x => x.IdImport == idImport &&
                x.IdAccount == idAccount &&
                x.IdState == (int)EnumStateAsif.Complete)
                .Any();
        }

        private Boolean HasAsifOperationLess(int idImport, int idAccount)
        {
            return Context.AccountStatementImportFile
                .Where(x => x.IdImport == idImport &&
                x.IdAccount == idAccount &&
                x.IdState == (int)EnumStateAsif.OperationLess)
                .Any();
        }

        private Boolean HasAsifMethodLess(int idImport, int idAccount)
        {
            return Context.AccountStatementImportFile
                .Where(x => x.IdImport == idImport &&
                x.IdAccount == idAccount &&
                x.IdState == (int)EnumStateAsif.MethodLess)
                .Any();
        }

        //public List<AccountStatementImportFile> GetAsifFull(int idImport, int idAccount)
        //{
          
        //    var tat = Context.AccountStatementImport.Where(x => x.Id == 160);
        //    var toto =
        //     Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == idImport &&
        //        x.IdAccount == idAccount)
        //        //.Include(x => x.AccountStatementImport)
        //        //.Include(x => x.OperationType.OperationTypeFamily)
        //        //.Include(x => x.Operation)
        //        //.Include(x => x.OperationMethod)
        //        //.Include(x => x.OperationPlace)
        //        .OrderBy(x => x.DateOperation).ToList();

        //    return toto;

        //}

        

        //public List<AccountStatementImportFile> GetAsifComplete(int idImport, int idAccount)
        //{
        //    return Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == idImport &&
        //        x.IdAccount == idAccount &&
        //        x.EnumAsifState == EnumAsifState.Complete)
        //        .Include(x => x.OperationType.OperationTypeFamily)
        //        .Include(x => x.Operation)
        //        .Include(x => x.OperationMethod)
        //        .Include(x => x.GMapAddress)
        //        .OrderBy(x => x.DateOperation).ToList();
        //}
        //public List<AccountStatementImportFile> GetAsifMethodLess(int idImport, int idAccount)
        //{
        //    return Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == idImport &&
        //        x.IdAccount == idAccount &&
        //        x.EnumAsifState == EnumAsifState.MethodLess)
        //        .Include(x => x.OperationType.OperationTypeFamily)
        //        .Include(x => x.Operation)
        //        .Include(x => x.OperationMethod)
        //        //.Include(x => x.GMapAddress)
        //        .OrderBy(x => x.DateOperation).ToList();
        //}
        //public List<AccountStatementImportFile> GetAsifOperationLess(int idImport, int idAccount)
        //{
        //    return Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == idImport &&
        //        x.IdAccount == idAccount &&
        //        x.EnumAsifState == EnumAsifState.OperationLess)
        //        .Include(x => x.OperationType.OperationTypeFamily)
        //        .Include(x => x.Operation)
        //        .Include(x => x.OperationMethod)
        //        .Include(x => x.GMapAddress)
        //        .OrderBy(x => x.DateOperation).ToList();
        //}

        //public bool HasAccountStatementImportFileWihoutPlace(int IdImport, int idAccount)
        //{
        //    return Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == IdImport
        //        && x.IdAccount == idAccount
        //        && x.IdOperationPlace == (int)EnumOperation.Inconnu
        //        && (x.IdOperationMethod == (int)EnumOperationMethod.PaiementCarte || x.IdOperationMethod == (int)EnumOperationMethod.RetraitCarte)).Any();
        //}

        public new int CreateWithTran(AccountStatementImportFile accountStatementImportFile)
        {
            accountStatementImportFile.Id = 0;
            accountStatementImportFile.Account = null;
            accountStatementImportFile.OperationType = null;
            accountStatementImportFile.OperationMethod = null;
            accountStatementImportFile.AccountStatementImport = null;
            accountStatementImportFile.Operation = null;
            accountStatementImportFile.OperationDetail = null;

            ////Context.AccountStatement.Add(aStatement);
            //if (accountStatementImportFile.Account != null)
            //    Context.Account.Attach(accountStatementImportFile.Account);
            //if (accountStatementImportFile.OperationType != null)
            //    Context.OperationType.Attach(accountStatementImportFile.OperationType);
            //if (accountStatementImportFile.OperationMethod != null)
            //    Context.OperationMethod.Attach(accountStatementImportFile.OperationMethod);
            //if (accountStatementImportFile.AccountStatementImport != null)
            //    Context.AccountStatementImport.Attach(accountStatementImportFile.AccountStatementImport);
            //if (accountStatementImportFile.Operation != null)
            //    Context.Operation.Attach(accountStatementImportFile.Operation);
            //if (accountStatementImportFile.OperationDetail != null)
            //    Context.OperationDetail.Attach(accountStatementImportFile.OperationDetail);

            Context.AccountStatementImportFile.Add(accountStatementImportFile);

            //Context.SaveChanges();

            return accountStatementImportFile.Id;
        }

        public bool SaveWithTran(List<AccountStatementImportFile> accountStatementImportFiles)
        {

            foreach (AccountStatementImportFile item in accountStatementImportFiles)
            {
                AccountStatementImportFile accountStatementImportFile = item;
                accountStatementImportFile = UpdateAsifState(item);

                CreateWithTran(accountStatementImportFile);

            }

            return true;
        }

        public AccountStatementImportFile Save(AccountStatementImportFile accountStatementImportFile)
        {
            accountStatementImportFile = UpdateAsifState(accountStatementImportFile);

            accountStatementImportFile = accountStatementImportFile.Id==0
                ? Create(accountStatementImportFile)
                : Update(accountStatementImportFile);

            return accountStatementImportFile;
        }

        //public void UpdateAsifStates(int idImport)
        //{
        //    var asifs = GetByIdImport(idImport);
        //    foreach(var asif in asifs)
        //    {
        //        UpdateAsifState(asif);
        //        Update(asif);
        //    }

        //}

        public void UpdateAsifStates(AccountStatementImportFile asif)
        {
            UpdateAsifState(asif);
            Update(asif);
        }

        //private List<AccountStatementImportFile> GetByIdImport(int idImport)
        //{
        //    return Context.AccountStatementImportFile
        //        .Where(x => x.IdImport == idImport)
        //        .ToList();
        //}

        public AccountStatementImportFile UpdateAsifState(AccountStatementImportFile item)
        {
            //Flager la ligne d'operation si elle existe deja dans la table AccountStatement
            var duplicate = Context.AccountStatement
                    //.Where(x => x.DateOperation == item.DateOperation
                    .Where(x => x.IdAccount == item.IdAccount
                    && x.IdMovement == item.IdMovement
                    && x.IdOperation == item.IdOperation
                    && x.IdOperationTypeFamily == item.IdOperationTypeFamily
                    && x.IdOperationMethod == item.IdOperationMethod
                    && x.DateIntegration == item.DateIntegration
                    && x.IdOperationDetail == item.IdOperationDetail
                    && x.AmountOperation == item.AmountOperation)
                .FirstOrDefault();

            //if (duplicate != null)
            //{
            //    item.IsDuplicated = true;
            //}
            item.IsDuplicated = duplicate!=null;

            //determination du State
            if (item.IdOperation != null && item.IdOperationMethod != null && item.IdOperationDetail != null)
                item.IdState = (int)EnumStateAsif.Complete;
            else if (item.IdOperationMethod == null)
                item.IdState = (int)EnumStateAsif.MethodLess;
            else
                item.IdState = (int)EnumStateAsif.OperationLess;
            //if (item.IdOperation != item.UnknownId.IdOperation && item.IdOperationMethod != item.UnknownId.IdOperationMethod && item.IdOperationDetail!= item.UnknownId.IdOperationDetail)
            //    item.IdState = (int)EnumStateAsif.Complete;
            //else if (item.IdOperationMethod == item.UnknownId.IdOperationMethod)
            //    item.IdState = (int)EnumStateAsif.MethodLess;
            //else
            //    item.IdState = (int)EnumStateAsif.OperationLess;

            //if (item.OperationDetail.IdGMapAddress == (int)EnumGMapAddress.Inconnu && (item.IdOperationMethod == (int)EnumOperationMethod.PaiementCarte || item.IdOperationMethod == (int)EnumOperationMethod.RetraitCarte))
            //    item.EnumAsifState = EnumAsifState.OperationLess;

            return item;
        }

        public List<AccountStatementImportFile> GetAsifsWithoutDuplicate(int idImport)
        {
            var results = Context.AccountStatementImportFile
                .Where(x=>x.IdImport== idImport)
                .Where(x => x.IsDuplicated == false)
                .ToList();

            return results;
        }

        public bool HasOperation(int idOperation)
        {
            var result = Context.AccountStatementImportFile
                .Where(x => x.IdOperation == idOperation)
                .Any();

            return result;
        }

        public bool HasOt(int idOt)
        {
            var result = Context.AccountStatementImportFile
                .Where(x => x.IdOperationType == idOt)
                .Any();

            return result;
        }

        public bool HasOtf(int idOtf)
        {
            var result = Context.AccountStatementImportFile
                .Where(x => x.IdOperationTypeFamily == idOtf)
                .Any();

            return result;
        }
    }
}
