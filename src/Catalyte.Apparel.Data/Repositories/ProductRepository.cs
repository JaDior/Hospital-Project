using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Data.Filters.PaginationFilters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IApparelCtx _ctx;

        public ProductRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ctx.Products.FindAsync(productId); 
        }
        public async Task<List<Product>> GetFilteredProductsAsync(ProductFilterDTO filter, PaginationFilter paginationFilter)
        {
 
            return await _ctx.Products.AsQueryable().WhereFilteredProductEquals(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsMaxNumber(ProductFilterDTO filter)
        {

            return await _ctx.Products.AsQueryable().WhereFilteredProductEquals(filter).ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            _ctx.Products.Add(newProduct);
            await _ctx.SaveChangesAsync();

            return newProduct;
        }
        public async Task<Product> DeleteProductAsync(Product productToDelete)
        {
            _ctx.Products.Remove(productToDelete);
            await _ctx.SaveChangesAsync();

            return productToDelete;
        }
        public async Task<Product> UpdateProductToInactiveAsync(Product productToUpdate)
        {
            _ctx.Products.Update(productToUpdate);
            await _ctx.SaveChangesAsync();

            return productToUpdate;
        }

        public async Task<Product> UpdateProductViewsAsync(Product productToUpdate)
        {
            _ctx.Products.Update(productToUpdate);
            await _ctx.SaveChangesAsync();

            return productToUpdate;
        }

        public async Task<Product> UpdateLatestViewsAsync(Product productToUpdate)
        {
            _ctx.Products.Update(productToUpdate);
            await _ctx.SaveChangesAsync();

            return productToUpdate;
        }

        public async Task<IEnumerable<Product>> GetActiveProducts()
        {
            return await _ctx.Products.ToListAsync();
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            _ctx.Products.Update(product);
            await _ctx.SaveChangesAsync();

            return product;
        }
    }

}
