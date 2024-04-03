using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IMonthService
    {
        List<Select> GetSelectAll();
        List<Month> GetAll();
        List<Month> GetAnnual();

    }

}
