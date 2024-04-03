using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;


namespace Budget.DATA.Repositories
{
    public class AsChartCategorisationRepository : BaseRepository<AccountStatement>, IAsChartCategorisationRepository
    {
        public AsChartCategorisationRepository(BudgetContext context) : base(context)
        {

        }

        public List<SelectNameValueDto<double>> GetAsChartCategorisationSelect(int? idAccount, DateTime dateMin, DateTime dateMax, EnumTableRef enumTableRef)
        {
            return Context.Set<SelectNameValueDto<double>>()
                .FromSqlRaw("[as].spGetAsChartCategorisationSelect @idAccount,@dateMin,@dateMax,@tableRef",
                    new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
                    new SqlParameter("@dateMin", dateMin),
                    new SqlParameter("@dateMax", dateMax),
                    new SqlParameter("@tableRef", enumTableRef.ToString())
                    )
                .ToList();
        }

        //public List<AsEvolutionCdbDto> GetAsChartEvolutionNoIntTransfer(int? idAccount,int idUserGroup, DateTime dateMin, DateTime dateMax)
        //{
        //    return Context.Set<AsEvolutionCdbDto>()
        //        .FromSql("[as].spGetAsChartEvolutionNoIntTransfer @idAccount,@idUserGroup,@dateMin,@dateMax",
        //            new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
        //            new SqlParameter("@idUserGroup", idUserGroup),
        //            new SqlParameter("@dateMin", dateMin),
        //            new SqlParameter("@dateMax", dateMax))
        //        .ToList();
        //}

        //public List<BaseChartData> GetAsChartEvolutionCustomOtf(int? idAccount,int idOperationTypeFamily, DateTime dateMin, DateTime dateMax)
        //{
        //    return Context.Set<BaseChartData>()
        //        .FromSql("[as].spGetAsChartEvolutionCustomOtf @idAccount,@idOperationTypeFamily,@dateMin,@dateMax",
        //            new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
        //            new SqlParameter("@idOperationTypeFamily", idOperationTypeFamily),
        //            new SqlParameter("@dateMin", dateMin),
        //            new SqlParameter("@dateMax", dateMax))
        //        .ToList();
        //}



    }

}
