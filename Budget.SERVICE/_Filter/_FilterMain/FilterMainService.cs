using AutoMapper;
using Budget.HELPER;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class FilterMainService : IFilterMainService
    {
        private readonly IMapper _mapper;
        private readonly ReferentialService _referentialService;
        private readonly IAccountStatementService _accountStatementService;

        public FilterMainService(
            IMapper mapper,
            ReferentialService referentialService,
            IAccountStatementService accountStatementService
            )
        {
            _mapper = mapper;
            _referentialService = referentialService;
            _accountStatementService = accountStatementService;
        }

        public FilterAsMainSelection GetFilterAsMainSelection(FilterAsMainSelected filter)
        {
            _accountStatementService.CheckAsInternalTransferOrphan(2);


            FilterAsMainSelection filterAsTable = new FilterAsMainSelection();

            filterAsTable.Month = DateHelper.GetMonthList();
            filterAsTable.Year = _accountStatementService.GetYearAvailable(filter.User.Id, filter.IdAccount.Value);
            return filterAsTable;
        }

    }

}
