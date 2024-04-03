using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IOperationMethodService 
    {
        List<Select> GetSelectList(EnumSelectType enumSelectType);
        Select GetSelect(int idOperationMethod);
        OperationMethod GetOperationMethodByFileLabel(string operationLabel, EnumBankFamily enumBankFamily);
        OperationMethod GetById(int idOperationMethod);
        List<OperationMethod> GetAll();
        List<OperationMethod> GetAllForEdit();

        int Create(OperationMethod operationMethod);
        void Update(OperationMethod operationMethod);
        void Delete(OperationMethod operationMethod);
    }
}
