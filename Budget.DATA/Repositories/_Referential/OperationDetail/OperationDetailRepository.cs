using Budget.MODEL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class OperationDetailRepository : BaseRepository<OperationDetail>, IOperationDetailRepository
    {
        public OperationDetailRepository(BudgetContext context) : base(context)
        {
        }

        public OperationDetail GetByIdForDetail(int idOperationDetail)
        {
            var result = Context.OperationDetail
                .Include(x => x.Operation)
                .Include(x => x.OperationPlace)
                .Include(x => x.GMapAddress)
                .Where(x=>x.Id== idOperationDetail)
                .FirstOrDefault();

            return result;
        }

        public bool HasSameKeywords(OperationDetail operationDetail)
        {
            var result = Context.OperationDetail
                .Where(x => x.Id!=operationDetail.Id
                    && x.KeywordOperation == operationDetail.KeywordOperation
                    && x.KeywordPlace == operationDetail.KeywordPlace
                    && x.IdUserGroup == operationDetail.IdUserGroup)
                .Any();
            return result;
        }

        public List<OperationDetail> GetAllByIdOperationMethod(int idUserGroup, int idOperationMethod)
        {
            var results = Context.OperationDetail
                .Where(x => x.IdUserGroup == idUserGroup
                    && x.Operation.IdOperationMethod == idOperationMethod);

            return results
                .Include(x => x.Operation)
                .Include(x => x.Operation.OperationType)
                .Include(x => x.Operation.OperationType.OperationTypeFamily)
                .Include(x => x.GMapAddress)
                .ToList(); ;
        }

        public OperationDetail GetByOperationDetail(OperationDetail operationDetail)
        {
            OperationDetail result = null;
            result = Context.OperationDetail
                .Where(
                    x => x.IdUserGroup == operationDetail.IdUserGroup
                    && x.IdOperation == operationDetail.IdOperation
                    && x.IdGMapAddress == operationDetail.IdGMapAddress
                    && x.KeywordOperation == operationDetail.KeywordOperation
                    && x.KeywordPlace == operationDetail.KeywordPlace
                    )
                .FirstOrDefault();

            return result;

        }

        public OperationDetail FindKeywordPlace(int idUserGroup, string operationLabel)
        {
            //var result = Context.OperationDetail
            //        .Where(x => x.IdUserGroup == idUserGroup 
            //        && operationLabel.Contains(x.KeywordPlace))
            //    .Include(x => x.GMapAddress.GMapLocality);
            var result = Context.OperationDetail
                .Where(x => x.IdUserGroup == idUserGroup)
                .Where(x => EF.Functions.Like(x.OperationLabel,$"%{operationLabel}%"))
                .Include(x => x.GMapAddress.GMapLocality)
                .FirstOrDefault();

            return result;
        }

        public OperationDetail GetUnknown(int idUserGroup)
        {
            var operationDetail = Context.OperationDetail
                .Where(x => x.IdUserGroup == idUserGroup
                    && x.KeywordOperation== "--FAKE_KEYWORD--")
                .FirstOrDefault();

            return operationDetail;
        }
    }
}
