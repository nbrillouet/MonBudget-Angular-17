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

namespace Budget.DATA.Repositories
{
    public class OperationTypeRepository : BaseRepository<OperationType>, IOperationTypeRepository
    {
        private readonly IOperationRepository _operationRepository;

        public OperationTypeRepository(BudgetContext context,
            IOperationRepository operationRepository) : base(context)
        {
            _operationRepository = operationRepository;
        }

        public OperationType Get(EnumOperationType enumOperationType, int idUserGroup)
        {
            var result = Context.OperationType
                .Where(x => x.Code == enumOperationType.ToString())
                .Where(x => x.IdUserGroup == idUserGroup);

            return result.FirstOrDefault();

        }

        public List<OperationType> GetByIdOperationTypeFamily(int idOperationTypeFamily)
        {
            var results = Context.OperationType
                .Where(x => x.IdOperationTypeFamily == idOperationTypeFamily);

            return results.OrderBy(x => x.Label)
                .ToList();
        }

        public List<OperationType> GetForViri(int idAccount, int idMovement, int idOperationTypeFamily)
        {
            //recuperation numero de compte pour exclusionde la liste
            var account = Context.Account
                .Where(x => x.Id == idAccount)
                .FirstOrDefault();
            //Code de mouvement C ou D
            var code = idMovement == 1 ? "VIRIC" : "VIRID";

            //Recherche de la liste des virements internes
            var results = Context.OperationType
                .Where(x=>x.IdOperationTypeFamily== idOperationTypeFamily)
                .Where(x=>x.Code == code)
                .Where(x => !x.Label.Contains(account.Number))
                .ToList();

            return results;
        }

        public List<OperationType> GetByIdUserGroup(int idUserGroup)
        {
            var results = Context.OperationType
                .Where(x => x.IdUserGroup == idUserGroup);

            return results.OrderBy(x => x.Label)
                .ToList();
        }

        public List<OperationType> GetByOperationTypeFamilies(int idUserGroup, List<Select> OperationTypeFamilies)
        {
            List<OperationType> results;
            if (OperationTypeFamilies == null || !OperationTypeFamilies.Any())
            {
                results = Context.OperationType
                    .Where(x => x.IdUserGroup == idUserGroup)
                    .OrderBy(x => x.Label)
                    .ToList();
            }
            else
            {
                var idOperationTypeFamilies = OperationTypeFamilies.Select(x => x.Id).ToList();
                results = Context.OperationType
                    .Where(x => idOperationTypeFamilies.Contains(x.IdOperationTypeFamily))
                    .ToList();
            }

            return results;
        }

        public OperationType GetByIdWithOperationTypeFamily(int idOperationType)
        {
            return Context.OperationType
                .Where(x=>x.Id == idOperationType)
                .Include(x => x.OperationTypeFamily).FirstOrDefault();
        }

        public List<OperationType> GetByIdMovement(int idUserGroup, EnumMovement enumMovement)
        {
            var otfs = Context.OperationTypeFamily
                .Where(x => x.IdUserGroup == idUserGroup 
                    && (x.IdMovement == (int)enumMovement || x.IdMovement==(int)EnumMovement.TwoWays))
                .ToList();

            var ids = new int[otfs.Count()];
            for (int i = 0; i < otfs.Count(); i++)
            {
                ids[i] = otfs[i].Id;
            }

            List<OperationType> operationTypes = Context.OperationType
                .Where( x => ids.Contains(x.IdOperationTypeFamily))
                .ToList();

            return operationTypes;
        }

        public List<OperationType> GetByIdList(List<int> idList)
        {
            List<OperationType> operationTypes = Context.OperationType
                .Where(x => idList.Contains(x.Id))
                .ToList();

            return operationTypes;
        }

        public List<OperationType> GetByIdMovement(EnumMovement enumMovement)
        {
            List<OperationTypeFamily> operationTypeFamilies = Context.OperationTypeFamily.Where(x => x.IdMovement == (int)enumMovement).ToList();
            var ids = new int[operationTypeFamilies.Count()];
            for (int i = 0; i < operationTypeFamilies.Count(); i++)
            {
                ids[i] = operationTypeFamilies[i].Id;
            }

            List<OperationType> operationTypes = Context.OperationType.Where(x => ids.Contains(x.IdOperationTypeFamily)).ToList();

            return operationTypes;
        }

        public OperationType GetUnknown(int idUserGroup)
        {
            var operationType = Context.OperationType
                .Where(x => x.IdUserGroup == idUserGroup
                    && x.Label == "INCONNU")
                .FirstOrDefault();

            return operationType;
        }

        public PagedList<OperationType> GetForTable(FilterOtTableSelected filter)
        {
            var operationTypes = Context.OperationType
                .Where(x => x.IdUserGroup == filter.User.IdUserGroup)
                .Include(x => x.OperationTypeFamily)
                .AsQueryable();

            operationTypes = GenericTableFilter.GetGenericFilters(operationTypes, filter);

            var results = PagedListRepository<OperationType>.Create(operationTypes, filter.Pagination);
            return results;
        }

        public OperationType GetForDetail(int idOt)
        {
            var operationType = Context.OperationType
                .Where(x => x.Id == idOt)
                .Include(x => x.OperationTypeFamily)
                .FirstOrDefault();

            return operationType;
        }

        //public OperationType GetOtDetail(int idOperationType)
        //{
        //    var operationType = Context.OperationType
        //        .Where(x => x.Id == idOperationType)
        //        .Include(x => x.OperationTypeFamily)
        //        .FirstOrDefault();

        //    return operationType;
        //}

        public bool HasOtf(int idOtf)
        {
            var result = Context.OperationType
                .Where(x => x.IdOperationTypeFamily == idOtf)
                .Any();

            return result;
        }

        public void DeleteWithEscalation(OperationType operationType)
        {
            //suppression des opérations liées
            var os = Context.Operation
                .Where(x => x.IdOperationType == operationType.Id)
                .ToList();
            foreach (var o in os)
            {
                _operationRepository.DeleteWithTran(o);
            }

            DeleteWithTran(operationType);

            Context.SaveChanges();
        }


    }


    
}
