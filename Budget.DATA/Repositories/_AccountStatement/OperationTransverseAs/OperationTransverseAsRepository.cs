using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class OperationTransverseAsRepository : BaseRepository<OperationTransverseAs>, IOperationTransverseAsRepository
    {
        public OperationTransverseAsRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationTransverse> GetOperationTransverseList(int IdAccountStatement)
        {
            var results = Context.OperationTransverseAs
                .Where(x => x.IdAccountStatement == IdAccountStatement)
                .Select(x => x.OperationTransverse)
                .ToList();

            return results;
        }

        public List<OperationTransverseAs> GetByIdAs(int idAs)
        {
            var results = Context.OperationTransverseAs
                .Where(x => x.IdAccountStatement == idAs)
                .ToList();

            return results;
        }

        //public OperationTransverseAs Update(OperationTransverseAs operationTransverseAs)
        //{
        //    return Updtae(operationTransverseAs);
        //}

        public bool Update(List<Select> operationTransverses, int idAs)
        {
            //suppression des liaisons pour l' idAs
            var toDeletes = GetByIdAs(idAs);
            foreach (var toDelete in toDeletes)
            {
                Delete(toDelete);
            }

            foreach (var item in operationTransverses)
            {
                var operationTransverseAs = new OperationTransverseAs
                {
                    Id = 0,
                    IdAccountStatement = idAs,
                    IdOperationTransverse = item.Id
                };

                Create(operationTransverseAs);
            }

            return true;

        }

    }

}
