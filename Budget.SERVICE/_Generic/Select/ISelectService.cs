using System;
using System.Collections.Generic;
using System.Text;
using Budget.MODEL;
using Budget.MODEL.Dto;

namespace Budget.SERVICE
{
    public interface ISelectService
    {
        Select GetSelect(EnumSelectType enumSelectType);
        List<Select> GetSelectList(EnumSelectType enumSelectType);
        List<SelectCode> GetSelectCodeList(EnumSelectType enumSelectType);
    }
}
