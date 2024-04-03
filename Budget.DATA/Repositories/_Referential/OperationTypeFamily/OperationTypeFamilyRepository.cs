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
    public class OperationTypeFamilyRepository : BaseRepository<OperationTypeFamily>, IOperationTypeFamilyRepository
    {

        private readonly IOperationRepository _operationRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;

        public OperationTypeFamilyRepository(BudgetContext context,
            IOperationRepository operationRepository,
            IOperationTypeRepository operationTypeRepository) : base(context)
        {
            _operationRepository = operationRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public List<OperationTypeFamily> GetByIdMovement(int idUserGroup, EnumMovement enumMovement)
        {
            var operationTypeFamilies = Context.OperationTypeFamily
                .Where(x=>x.IdUserGroup == idUserGroup 
                    && (x.IdMovement == (int)enumMovement || x.IdMovement == (int)EnumMovement.TwoWays));

            return operationTypeFamilies
                .OrderBy(x => x.Label)
                .ToList();

        }

        public List<OperationTypeFamily> GetByIdUserGroup(int idUserGroup)
        {
            var operationTypeFamilies = Context.OperationTypeFamily
                .Where(x => x.IdUserGroup == idUserGroup);

            return operationTypeFamilies
                .OrderBy(x => x.Label)
                .ToList();
        }

        public List<OperationTypeFamily> GetAllByOrder(int idUserGroup)
        {
            return Context.OperationTypeFamily
                .Where(x => x.IdUserGroup == idUserGroup)
                .ToList()
                .OrderBy(x => x.IdMovement)
                .ThenBy(x => x.Label)
                .ToList();
        }

        public List<OperationTypeFamily> GetByIdList(List<int> idList)
        {
            List<OperationTypeFamily> results = Context.OperationTypeFamily
                .Where(x => idList.Contains(x.Id))
                .ToList();

            return results;
        }

        public PagedList<OperationTypeFamily> GetForTable(FilterOtfTableSelected filter)
        {
            var operationTypeFamilies = Context.OperationTypeFamily
                .Where(x=>x.IdUserGroup == filter.User.IdUserGroup)
                .Include(x => x.Movement)
                .Include(x => x.Asset)
                .AsQueryable();

            operationTypeFamilies = GenericTableFilter.GetGenericFilters(operationTypeFamilies, filter);

            var results = PagedListRepository<OperationTypeFamily>.Create(operationTypeFamilies, filter.Pagination);
            return results;
        }

        public OperationTypeFamily GetForDetail(int idOtf)
        {
            var operationTypeFamily = Context.OperationTypeFamily
                .Where(x => x.Id == idOtf)
                .Include(x=>x.Movement)
                .Include(x=>x.Asset)
                .FirstOrDefault();

            return operationTypeFamily;
        }

        public OperationTypeFamily GetByCodeUserGroup(EnumOtf enumCodeOtf, int idUserGroup)
        {
            var operationTypeFamily = Context.OperationTypeFamily
                .Where(x => x.IdUserGroup == idUserGroup
                    && x.Code == enumCodeOtf.ToString())
                .FirstOrDefault();

            return operationTypeFamily;
        }

        //public OperationTypeFamily GetUnknown(int idUserGroup)
        //{
        //    var operationTypeFamily = Context.OperationTypeFamily
        //        .Where(x => x.IdUserGroup == idUserGroup
        //            && x.Label == "INCONNU")
        //        .FirstOrDefault();

        //    return operationTypeFamily;
        //}

        public void DeleteWithEscalation(OperationTypeFamily operationTypeFamily)
        {
            //suppression operations type liés
            var ots = Context.OperationType
                .Where(x => x.IdOperationTypeFamily == operationTypeFamily.Id)
                .ToList();

            foreach(var ot in ots)
            {
                //suppression des opérations liées
                var os = Context.Operation
                    .Where(x => x.IdOperationType == ot.Id)
                    .ToList();
                foreach(var o in os)
                {
                    _operationRepository.DeleteWithTran(o);
                }

                _operationTypeRepository.DeleteWithTran(ot);

            }

            DeleteWithTran(operationTypeFamily);

            Context.SaveChanges();

        }


    }
}
