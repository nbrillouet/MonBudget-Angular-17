using Budget.MODEL.Database;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public AssetRepository(BudgetContext context) : base(context)
        {
        }

        public List<Asset> GetList(EnumAssetFamily enumAssetFamily)
        {
            var results = Context.Asset
                .Where(x => x.IdFamily == (int)enumAssetFamily)
                .OrderBy(x=>x.Label)
                .ToList();

            return results;
        }
    }


}
