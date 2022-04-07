using AutoMapper;
using Catalyte.Apparel.Data.Filters.PaginationFilters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository, ILogger<ProductProvider> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the product with the provided id from the database.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product;

            try
            {
                product = await _productRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (product == null || product == default)
            {
                _logger.LogInformation($"Product with id: {productId} could not be found.");
                throw new NotFoundException($"Product with id: {productId} could not be found.");
            }

            return product;
        }


        /// <summary>
        /// Asynchronously retrieves all products from the database.
        /// </summary>
        /// <returns>All products in the database.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            

            return products;
        }
        /// <summary>
        /// Asynchronously retrieves filtered products from the database.
        /// </summary>
        /// <returns>Filtered products from the database.</returns>
        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterDTO filter, PaginationFilter paginationFilter, string searchTerm)

        {
            IEnumerable<Product> products;
            var exceptions = new List<String>();

            if (filter.MaxPrice != null || filter.MinPrice != null)
            {
                decimal maxPrice=0;
                decimal minPrice=0;
                NumberStyles style;
                CultureInfo culture;

                // Parse currency value using en-GB culture.
                style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("en-US");

                // check if price strings are valid decimal numbers otherwise they will cause System.FormatException
                if (filter.MaxPrice != null) {
                    if (!Decimal.TryParse(filter.MaxPrice, style, culture, out maxPrice))  //if unable to convert to decimal
                        exceptions.Add("Maximum price must be a number ");
                }
                if (filter.MinPrice != null) {
                    if (!Decimal.TryParse(filter.MinPrice, style, culture, out minPrice)) //if unable to convert to decimal
                        exceptions.Add("Minimum price must be a number ");
                }

                //if there were no errors with the price formats
                if (exceptions.Count == 0)
                { 
                    if (filter.MaxPrice != null && filter.MinPrice != null)
                    {
                        if (maxPrice < minPrice)
                        {
                            exceptions.Add("Maximum price must be greater than or equal to minimum price ");
                        }
                    }
                    if (filter.MaxPrice != null)
                    {
                        if (maxPrice < 0)
                        {
                            exceptions.Add("Maximum price must be non-negative ");
                        }
                    }
                    if (filter.MinPrice != null)
                    {
                        if (minPrice < 0)
                        {
                            exceptions.Add("Minimum price must be non-negative ");
                        }
                    }
                }
            }
            // if there were errors with the price formatting
            if (exceptions.Count > 0)
            {
                throw new BadRequestException(string.Join(". ", exceptions));
            }
            else
            {
                try
                {
                    products = await _productRepository.GetFilteredProductsAsync(filter, paginationFilter);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }
                if (searchTerm != null)
                {
                    string[] searchTerms = searchTerm.Split(" ");
                    var searchResults = new List<Product> { };

                    foreach (var product in products)
                    {
                        string[] productName = product.Name.ToLower().Split(" ");
                        string[] productDemographic = product.Demographic.ToLower().Split(" ");
                        string[] productDescription = product.Description.ToLower().Split(" ");
                        string[] productCategory = product.Category.ToLower().Split(" ");
                        string[] productType = product.Type.ToLower().Split(" ");
                        var productProperties = productName.Concat(productDemographic).ToArray();
                        productProperties = productProperties.Concat(productDemographic).ToArray();
                        productProperties = productProperties.Concat(productCategory).ToArray();
                        productProperties = productProperties.Concat(productType).ToArray();

                        if (searchTerms.All(productProperties.Contains))
                        {
                            searchResults.Add(product);
                        }
                    }
                    return searchResults;

                }
                return products;

            }
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsMaxNumber(ProductFilterDTO filter, string searchTerm)
        {
            IEnumerable<Product> products;
            var exceptions = new List<String>();

            if (filter.MaxPrice != null || filter.MinPrice != null)
            {
                decimal maxPrice = 0;
                decimal minPrice = 0;
                NumberStyles style;
                CultureInfo culture;

                // Parse currency value using en-GB culture.
                style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("en-US");

                // check if price strings are valid decimal numbers otherwise they will cause System.FormatException
                if (filter.MaxPrice != null)
                {
                    if (!Decimal.TryParse(filter.MaxPrice, style, culture, out maxPrice))  //if unable to convert to decimal
                        exceptions.Add("Maximum price must be a number ");
                }
                if (filter.MinPrice != null)
                {
                    if (!Decimal.TryParse(filter.MinPrice, style, culture, out minPrice)) //if unable to convert to decimal
                        exceptions.Add("Minimum price must be a number ");
                }

                //if there were no errors with the price formats
                if (exceptions.Count == 0)
                {
                    if (filter.MaxPrice != null && filter.MinPrice != null)
                    {
                        if (maxPrice < minPrice)
                        {
                            exceptions.Add("Maximum price must be greater than or equal to minimum price ");
                        }
                    }
                    if (filter.MaxPrice != null)
                    {
                        if (maxPrice < 0)
                        {
                            exceptions.Add("Maximum price must be non-negative ");
                        }
                    }
                    if (filter.MinPrice != null)
                    {
                        if (minPrice < 0)
                        {
                            exceptions.Add("Minimum price must be non-negative ");
                        }
                    }
                }
            }
            // if there were errors with the price formatting
            if (exceptions.Count > 0)
            {
                throw new BadRequestException(string.Join(". ", exceptions));
            }
            else
            {
                try
                {
                    products = await _productRepository.GetFilteredProductsMaxNumber(filter);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }
            }
            if (searchTerm != null)
            {
                string[] searchTerms = searchTerm.Split(" ");
                var searchResults = new List<Product> { };

                foreach (var product in products)
                {
                    string[] productName = product.Name.ToLower().Split(" ");
                    string[] productDemographic = product.Demographic.ToLower().Split(" ");
                    string[] productDescription = product.Description.ToLower().Split(" ");
                    string[] productCategory = product.Category.ToLower().Split(" ");
                    string[] productType = product.Type.ToLower().Split(" ");
                    var productProperties = productName.Concat(productDemographic).ToArray();
                    productProperties = productProperties.Concat(productDemographic).ToArray();
                    productProperties = productProperties.Concat(productCategory).ToArray();
                    productProperties = productProperties.Concat(productType).ToArray();

                    if (searchTerms.All(productProperties.Contains))
                    {
                        searchResults.Add(product);
                    }
                }
                return searchResults;
            }
                return products;
        }

        /// <summary>
        /// Creates a product in the database
        /// </summary>
        /// <param name="productToCreate"></param>
        /// <returns>a product</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        public async Task<Product> CreateProductAsync(Product productToCreate)
        {
            productToCreate.DateCreated = DateTime.UtcNow;
            productToCreate.DateModified = DateTime.UtcNow;
            productToCreate.ReleaseDate = DateTime.UtcNow;
            productToCreate.Active = true;

            Product savedProduct;

            try
            {
                savedProduct = await _productRepository.CreateProductAsync(productToCreate);
                _logger.LogInformation("Product saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedProduct;
        }
        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            Product productToDelete;
            try
            {
                productToDelete = await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            try
            {
                productToDelete = await _productRepository.DeleteProductAsync(productToDelete);
                _logger.LogInformation("Product Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a provlem connecting to the database.");
            }

            return productToDelete;
        }

        public async Task<Product> UpdateProductToInactiveAsync(int id)
        {
            Product existingProduct;

            try
            {
                existingProduct = await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            // Changing the existing product active status to false
            existingProduct.Active = false;
            try
            {
                await _productRepository.UpdateProductToInactiveAsync(existingProduct);
            }
            catch
            {
                throw new NotImplementedException("Product could not be Updated");
            }
            return existingProduct;
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            // UPDATES Product
            Product existingProduct;

            try
            {
                existingProduct = await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingProduct == default || existingProduct.Id != updatedProduct.Id)
            {
                _logger.LogInformation($"Product with id: {id} does not exist.");
                throw new NotFoundException($"Product with id:{id} not found.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Brand = updatedProduct.Brand;
            existingProduct.Quantity = updatedProduct.Quantity;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Material = updatedProduct.Material;
            existingProduct.ImageSrc = updatedProduct.ImageSrc;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Demographic = updatedProduct.Demographic;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Type = updatedProduct.Type;
            existingProduct.PrimaryColorCode = updatedProduct.PrimaryColorCode;
            existingProduct.SecondaryColorCode = updatedProduct.SecondaryColorCode;
            existingProduct.StyleNumber = updatedProduct.StyleNumber;
            existingProduct.Active = updatedProduct.Active;
            existingProduct.ReleaseDate = updatedProduct.ReleaseDate;
            existingProduct.DateModified = updatedProduct.DateModified;
            existingProduct.ProductViews = updatedProduct.ProductViews;
            existingProduct.LatestView = updatedProduct.LatestView;
            try
            {
                await _productRepository.UpdateProductAsync(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return updatedProduct;
        }

        public async Task<Product> UpdateProductViewsAsync(int id)
        {
            Product existingProduct;

            try
            {
                existingProduct = await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            existingProduct.ProductViews = existingProduct.ProductViews + 1;
            try
            {
                await _productRepository.UpdateProductViewsAsync(existingProduct);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return existingProduct;
        }

        public async Task<Product> UpdateLatestViewsAsync(int id)
        {
            Product existingProduct;

            try
            {
                existingProduct = await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            existingProduct.LatestView = DateTime.Now;
            try
            {
                await _productRepository.UpdateLatestViewsAsync(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return existingProduct;
        }

        public async Task<IEnumerable<Product>> GetActiveProducts()
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetActiveProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            return products;
        }
    }
}
