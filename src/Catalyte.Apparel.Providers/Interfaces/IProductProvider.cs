using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Utilities;
using Catalyte.Apparel.Data.Filters.PaginationFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IProductProvider
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterDTO filter, PaginationFilter paginationFilter, string searchTerm);

        Task<IEnumerable<Product>> GetFilteredProductsMaxNumber(ProductFilterDTO filter, string searchTerm);

        Task<Product> CreateProductAsync(Product productToCreate);

        Task<Product> DeleteProductByIdAsync(int id);
        Task<Product> UpdateProductToInactiveAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product product);
        Task<Product> UpdateProductViewsAsync(int id);
        Task<Product> UpdateLatestViewsAsync(int id);
        Task<IEnumerable<Product>> GetActiveProducts();
    }
}
