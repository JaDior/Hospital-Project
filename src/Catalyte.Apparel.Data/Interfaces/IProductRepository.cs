using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Data.Filters.PaginationFilters;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<List<Product>> GetFilteredProductsAsync(ProductFilterDTO filter, PaginationFilter paginationFilter);

        Task<IEnumerable<Product>> GetFilteredProductsMaxNumber(ProductFilterDTO filter);

        Task<Product> CreateProductAsync(Product productToCreate);

        Task<Product> DeleteProductAsync(Product productToDelete);
        Task<Product> UpdateProductToInactiveAsync(Product productToUpdate);
        Task<Product> UpdateProductViewsAsync(Product productToUpdate);
        Task<Product> UpdateLatestViewsAsync(Product productToUpdate);
        Task<IEnumerable<Product>> GetActiveProducts();

        Task<Product> UpdateProductAsync(Product product);
    }
}
