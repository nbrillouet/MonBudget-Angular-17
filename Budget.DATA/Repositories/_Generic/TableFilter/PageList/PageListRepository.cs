using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Budget.DATA.Repositories
{

    public class PagedListRepository<T> : List<T>
    {
        public static PagedList<T> Create(IQueryable<T> source, Pagination pagination)
        {
            var count =  source.Count();
            var items =  source.Skip((pagination.CurrentPage) * pagination.NbItemsPerPage).Take(pagination.NbItemsPerPage).ToList();

            pagination.TotalItems = count;
            pagination.TotalPages = (int)Math.Ceiling(count / (double)pagination.NbItemsPerPage);
            
            var results = new PagedList<T>(items, pagination);
            return results;
        }

    }
}
