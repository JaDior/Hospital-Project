using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters.PaginationFilters
{

    /// <summary>
    /// Method to set PageNumber and PageSize for Pagination
    /// </summary>
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 20;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 20 ? 20 : pageSize;
        }
    }
}