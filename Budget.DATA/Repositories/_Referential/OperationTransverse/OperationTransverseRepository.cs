using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class OperationTransverseRepository : BaseRepository<OperationTransverse>, IOperationTransverseRepository
    {
        public OperationTransverseRepository(BudgetContext context) : base(context)
        {
        }

        public List<OperationTransverse> GetSelectList(int idUser)
        {
            return Context.OperationTransverse
                .Where(x => x.IdUser == idUser)
                .ToList();
        }

        public OperationTransverse Add(OperationTransverse operationTransverse)
        {
            //control si libellé deja existant
            var isDuplicate = Context.OperationTransverse
                .Where(x => x.Label.ToUpper() == operationTransverse.Label.ToUpper()
                    && x.IdUser == operationTransverse.IdUser)
                .Any();
            if (isDuplicate)
            {
                throw new Exception("Ce libellé existe déjà pour une opération transerve");
            }

            return Create(operationTransverse);
        }
    }

}
