using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Filters.PaginationFilters;
using Catalyte.Apparel.Providers.Interfaces;

namespace Catalyte.Apparel.Providers.Helpers
{
    public class PaginationHelper
    {

        /// <summary>
        /// Method to list data, total pages and total records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedData"></param>
        /// <param name="validFilter"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords)
        {
            var pagedResponse = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            pagedResponse.TotalPages = roundedTotalPages;
            pagedResponse.TotalRecords = totalRecords;
            return pagedResponse;
        }
    }
}
