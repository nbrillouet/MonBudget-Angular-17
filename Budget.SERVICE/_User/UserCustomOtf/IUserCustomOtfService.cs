using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IUserCustomOtfService
    {
        List<Select> GetOperationTypeFamilySelect(int idUser,int? idAccount);
        bool Update(AsChartEvolutionCustomOtfFilterSelected filter);
    }
}
