using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IAssetService
    {
        List<SelectCode> GetSelectList(EnumAssetFamily enumAssetFamily);
        SelectCode GetSelect(EnumAsset enumAsset);
    }
}
