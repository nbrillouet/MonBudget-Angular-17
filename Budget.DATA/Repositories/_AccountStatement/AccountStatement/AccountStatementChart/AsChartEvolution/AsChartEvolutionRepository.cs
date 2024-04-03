using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Budget.DATA.Repositories
{
    public class AsChartEvolutionRepository : BaseRepository<AccountStatement>, IAsChartEvolutionRepository
    {
        public AsChartEvolutionRepository(BudgetContext context) : base(context)
        {

        }

        public List<AsEvolutionCdbDto> GetAsChartEvolutionBrut(int? idAccount, DateTime dateMin, DateTime dateMax)
        {
            return Context.Set<AsEvolutionCdbDto>()
                .FromSqlRaw("[as].spGetAsChartEvolutionBrut @idAccount,@dateMin,@dateMax",
                    new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
                    new SqlParameter("@dateMin", dateMin),
                    new SqlParameter("@dateMax", dateMax))
                .ToList();
        }

        public List<AsEvolutionCdbDto> GetAsChartEvolutionNoIntTransfer(int? idAccount,int idUserGroup, DateTime dateMin, DateTime dateMax)
        {
            return Context.Set<AsEvolutionCdbDto>()
                .FromSqlRaw("[as].spGetAsChartEvolutionNoIntTransfer @idAccount,@idUserGroup,@dateMin,@dateMax",
                    new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
                    new SqlParameter("@idUserGroup", idUserGroup),
                    new SqlParameter("@dateMin", dateMin),
                    new SqlParameter("@dateMax", dateMax))
                .ToList();
        }

        public List<BaseChartData> GetAsChartEvolutionCustomOtf(int? idAccount,int idOperationTypeFamily, DateTime dateMin, DateTime dateMax)
        {
            return Context.Set<BaseChartData>()
                .FromSqlRaw("[as].spGetAsChartEvolutionCustomOtf @idAccount,@idOperationTypeFamily,@dateMin,@dateMax",
                    new SqlParameter("@idAccount", idAccount ?? (object)DBNull.Value),
                    new SqlParameter("@idOperationTypeFamily", idOperationTypeFamily),
                    new SqlParameter("@dateMin", dateMin),
                    new SqlParameter("@dateMax", dateMax))
                .ToList();
        }



    }

}
