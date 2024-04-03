using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IBankFamilyService
    {
        List<Select> GetSelectList(EnumSelectType enumSelectType);
        List<SelectCode> GetSelectCodeList(EnumSelectType enumSelectType);
        List<SelectCodeUrl> GetSelectCodeUrlList(EnumSelectType enumSelectType);
        SelectCode GetSelectCode(string code);
    }

}
