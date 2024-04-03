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
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public OperationRepository(BudgetContext context) : base(context)
        {
        }

        public List<Operation> GetSelectList(int idUserGroup)
        {
            var results = Context.Operation
                .Where(x => x.IdUserGroup == idUserGroup)
                .OrderBy(x => x.Label);

            return results.ToList(); ;
        }

        public List<Operation> GetSelectList(int idUserGroup, int idOperationMethod, int idOperationType)
        {
            var results = Context.Operation
                .Where(x => x.IdUserGroup == idUserGroup
                    && x.IdOperationMethod == idOperationMethod
                    && x.IdOperationType == idOperationType)
                .OrderBy(x => x.Label);

            return results.ToList(); ;
        }

        public List<Operation> GetSelectList(int idUserGroup, List<Select> operationMethodList, List<Select> operationTypeFamilyList, List<Select> operationTypeList)
        {
            var idOperationMethodList = (operationMethodList != null && operationMethodList.Any())
                ? operationMethodList.Select(x => x.Id).ToList()
                : null;
            var idOperationTypeFamilyIdList = (operationTypeFamilyList != null && operationTypeFamilyList.Any())
                ? operationTypeFamilyList.Select(x => x.Id).ToList()
                : null;
            var idOperationTypeList = (operationTypeList != null && operationTypeList.Any())
                ? operationTypeList.Select(x => x.Id).ToList()
                : null;

            var results = Context.Operation
                    .Where(x => x.IdUserGroup == idUserGroup);

            if (idOperationMethodList!=null)
            {
                results = results.Where(x => idOperationMethodList.Contains(x.IdOperationMethod));
            }
            if(idOperationTypeFamilyIdList!=null)
            {
                results = results.Where(x => idOperationTypeFamilyIdList.Contains(x.OperationType.OperationTypeFamily.Id));
            }
            if(idOperationTypeList!=null)
            {
                results = results.Where(x => idOperationTypeList.Contains(x.IdOperationType));
            }
            //List<Operation> results;
            //if (operationTypes == null || !operationTypes.Any())
            //{
            //    results = Context.Operation
            //        .Where(x => x.IdUserGroup == idUserGroup)
            //        .OrderBy(x=>x.Label)
            //        .ToList();
            //}
            //else
            //{
            //    var idOperationTypes = operationTypes.Select(x => x.Id).ToList();
            //    results = Context.Operation
            //        .Where(x=> idOperationTypes.Contains(x.IdOperationType))
            //        .OrderBy(x => x.Label)
            //        .ToList();
            //}
            results = results.OrderBy(x => x.Label);
                
            return results.ToList();
        }

        public List<Operation> GetByIdMovement(int idUserGroup, EnumMovement enumMovement)
        {
            var results = Context.Operation
                .Where(x => x.IdUserGroup == idUserGroup
                    && ( x.OperationType.OperationTypeFamily.IdMovement == (int)enumMovement 
                        || x.OperationType.OperationTypeFamily.IdMovement == (int)EnumMovement.TwoWays))
                .Include(x => x.OperationType);

            return results.ToList();
        }

        public List<Operation> GetByIdList(List<int> idList)
        {
            List<Operation> operations = Context.Operation
                .Where(x=> idList.Contains(x.Id))
                .ToList();

            return operations;
        }

        public Operation GetUnknown(int idUserGroup)
        {
            var operation = Context.Operation
                .Where(x => x.IdUserGroup == idUserGroup 
                    && x.Label=="INCONNU")
                .FirstOrDefault();

            return operation;
        }

        public PagedList<Operation> GetForTable(FilterOperationTableSelected filter)
        {
            var operations = Context.Operation
                .Where(x => x.IdUserGroup == filter.User.IdUserGroup)
                .Include(x => x.OperationType)
                .Include(x => x.OperationMethod)
                .AsQueryable();

            operations = GenericTableFilter.GetGenericFilters(operations, filter);

            var results = PagedListRepository<Operation>.Create(operations, filter.Pagination);
            return results;
        }

        public Operation GetForDetail(int idOperation)
        {
            var operation = Context.Operation
                .Where(x => x.Id == idOperation)
                .Include(x => x.OperationMethod)
                .Include(x=>x.OperationType)
                .FirstOrDefault();

            return operation;
        }

        public bool HasOt(int idOt)
        {
            var operation = Context.Operation
                .Where(x => x.IdOperationType == idOt)
                .Any();

            return operation;
        }

        public bool IsDuplicate(OperationForDetail oForDetail)
        {
            var result = Context.Operation
                .Where(x => x.IdUserGroup == oForDetail.User.IdUserGroup)
                .Where(x => x.IdOperationMethod == oForDetail.OperationMethod.Id)
                .Where(x => x.IdOperationType == oForDetail.OperationType.Id)
                .Where(x => x.Label == oForDetail.Label)
                .Any();

            return result;
        }
        //public void DeleteWithEscalation(Operation operation)
        //{
        //    //suppression operations type liés
        //    var ots = Context.OperationType
        //        .Where(x => x.IdOperationTypeFamily == operationTypeFamily.Id)
        //        .ToList();

        //    foreach (var ot in ots)
        //    {
        //        //suppression des opérations liées
        //        var os = Context.Operation
        //            .Where(x => x.IdOperationType == ot.Id)
        //            .ToList();
        //        foreach (var o in os)
        //        {
        //            _operationRepository.DeleteWithTran(o);
        //        }

        //        _operationTypeRepository.DeleteWithTran(ot);

        //    }

        //    DeleteWithTran(operationTypeFamily);

        //    Context.SaveChanges();

        //}
    }
}
