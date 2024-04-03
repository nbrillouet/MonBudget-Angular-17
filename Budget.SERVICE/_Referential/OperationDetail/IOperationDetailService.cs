using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;

namespace Budget.SERVICE
{
    public interface IOperationDetailService 
    {
        OperationDetailDto GetForDetail(int idOperationDetail);
        OperationDetail GetByKeywordOperation(int idUserGroup, string operationLabel, int idOperationMethod, EnumMovement enumMovement);
        OperationDetail GetByKeywords(int idUserGroup, string operationLabel, int idOperationMethod, EnumMovement enumMovement);
        OperationDetail FindKeywordPlace(int idUserGroup, string operationLabel);
        OperationDetail GetUnknown(int idUserGroup);
        OperationDetail GetOrCreate(OperationDetail operationDetail);
        OperationDetail CheckValues(OperationDetailDto operationDetailDto);
        OperationDetail Save(OperationDetail operationDetail);
    }
}
