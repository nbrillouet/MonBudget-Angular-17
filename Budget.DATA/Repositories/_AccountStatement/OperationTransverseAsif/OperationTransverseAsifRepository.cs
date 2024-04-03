using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class OperationTransverseAsifRepository : BaseRepository<OperationTransverseAsif>, IOperationTransverseAsifRepository
    {
        public OperationTransverseAsifRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationTransverse> GetOperationTransverseList(int IdAccountStatementFile)
        {
            var results = Context.OperationTransverseAsif
                .Where(x => x.IdAccountStatementImportFile == IdAccountStatementFile)
                .Select(x=>x.OperationTransverse)
                .ToList();

            return results;
        }

        public List<OperationTransverseAsif> GetByIdAsif(int idAsif)
        {
            var results = Context.OperationTransverseAsif
                .Where(x => x.IdAccountStatementImportFile == idAsif)
                .ToList();

            return results;
        }

        public bool Update(List<Select> operationTransverses, int idAsif)
        {
            //suppression des liaisons pour l' idAsif
            var toDeletes = GetByIdAsif(idAsif);
            foreach(var toDelete in toDeletes)
            {
                Delete(toDelete);
            }

            foreach(var item in operationTransverses)
            {
                var operationTransverseAsif = new OperationTransverseAsif
                {
                    Id = 0,
                    IdAccountStatementImportFile = idAsif,
                    IdOperationTransverse = item.Id
                };

                Create(operationTransverseAsif);
            }

            return true;

        }

    }


}
