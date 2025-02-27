﻿using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;


namespace Budget.DATA.Repositories
{
    public interface IAsChartCategorisationRepository : IBaseRepository<AccountStatement>
    {
        List<SelectNameValueDto<double>> GetAsChartCategorisationSelect(int? idAccount, DateTime dateMin, DateTime dateMax, EnumTableRef enumTableRef);
        //List<AsEvolutionCdbDto> GetAsChartEvolutionBrut(int? idAccount, DateTime dateMin, DateTime dateMax);
        //List<AsEvolutionCdbDto> GetAsChartEvolutionNoIntTransfer(int? idAccount,int idUserGroup, DateTime dateMin, DateTime dateMax);
        //List<BaseChartData> GetAsChartEvolutionCustomOtf(int? idAccount,int idOperationTypeFamily, DateTime dateMin, DateTime dateMax);
    }

}
