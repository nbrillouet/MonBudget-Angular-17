using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories
{
    public interface IOperationTypeFamilyRepository : IBaseRepository<OperationTypeFamily>
    {
        List<OperationTypeFamily> GetByIdMovement(int idUserGroup, EnumMovement enumMovement);
        List<OperationTypeFamily> GetByIdUserGroup(int idUserGroup);
        List<OperationTypeFamily> GetAllByOrder(int idUserGroup);
        List<OperationTypeFamily> GetByIdList(List<int> idList);
        OperationTypeFamily GetByCodeUserGroup(EnumOtf enumCodeOtf, int idUserGroup);
        PagedList<OperationTypeFamily> GetForTable(FilterOtfTableSelected filter);
        OperationTypeFamily GetForDetail(int idOtf);

        void DeleteWithEscalation(OperationTypeFamily operationTypeFamily);

    }
}
