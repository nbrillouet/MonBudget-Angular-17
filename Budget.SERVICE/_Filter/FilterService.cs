using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class FilterService : IFilterService
    {
        public IFilterDetailService FilterDetailService { get; }
        public IFilterTableService FilterTableService { get; }
        public IFilterMainService FilterMainService { get; }
        public FilterService(
            IFilterDetailService filterDetailService,
            IFilterTableService filterTableService,
            IFilterMainService filterMainService
            )
        {
            FilterDetailService = filterDetailService;
            FilterTableService = filterTableService;
            FilterMainService = filterMainService;
        }
    }
}
