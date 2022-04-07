﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Data.Filters.PaginationFilters;
using Catalyte.Apparel.Data.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Catalyte.Apparel.Data.Model;
using System.Reflection;
using Catalyte.Apparel.Providers.Helpers;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for product related actions.
    /// </summary>
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;


        public ProductsController(
            ILogger<ProductsController> logger,
            IProductProvider productProvider,
            IMapper mapper
            )
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            _logger.LogInformation("Request received for GetProductsAsync");
            var products = await _productProvider.GetProductsAsync();
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("/products/{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpGet("/products/categories")]
        public async Task<ActionResult> GetProductCategoriesAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productCategories = from product in products select product.Category;

            return Ok(productCategories.Distinct());

        }

        [HttpGet("/products/types")]
        public async Task<ActionResult> GetProductTypesAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productTypes = from product in products select product.Type;

            return Ok(productTypes.Distinct());

        }
        [HttpGet("/products/status/active")]
        public async Task<ActionResult> GetActiveProducts()
        {

            var products = await _productProvider.GetProductsAsync();
            var activeProducts = from product in products where product.Active is true select product;

            return Ok(activeProducts);
        }
        [HttpGet("/products/filter")]
        public async Task<ActionResult> GetFilteredProducts([FromQuery] ProductFilterDTO filter, [FromQuery] PaginationFilter paginationFilter, string searchTerm)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var products = await _productProvider.GetFilteredProductsAsync(filter, paginationFilter, searchTerm);
            var totalRecords = products.Count();
            var pagedProducts = products.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize);
            var pagedResponse = PaginationHelper.CreatePagedReponse<Product>(pagedProducts.ToList(), validFilter, totalRecords);

            return Ok(pagedResponse.Data);
        }

        [HttpGet("/products/maxNumber")]
        public async Task<ActionResult> GetFilteredProductsMaxNumber([FromQuery] ProductFilterDTO filter, string searchTerm)
        {
            var products = await _productProvider.GetFilteredProductsMaxNumber(filter, searchTerm);
            var totalRecords = products.Count();

            return Ok(totalRecords);
        }

        [HttpPost("/products")]
        public async Task<ActionResult<ProductDTO>> CreateProductAsync([FromBody] Product productToCreate)
        {
            _logger.LogInformation("Request received for CreateProductsAsync");

            var newProduct = await _productProvider.CreateProductAsync(productToCreate);
            var productDTO = _mapper.Map<ProductDTO>(newProduct);

            return Created("/products", productDTO);
        }
        [HttpGet("/products/brands")]
        public async Task<ActionResult> GetProductBrandsAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productBrands = from product in products select product.Brand;

            return Ok(productBrands.Distinct());

        }

        [HttpGet("/products/demographics")]
        public async Task<ActionResult> GetProductDemographicsAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productDemographics = from product in products select product.Demographic;

            return Ok(productDemographics.Distinct());

        }

        [HttpGet("/products/primarycolor")]
        public async Task<ActionResult> GetProductPrimaryColorsAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productPrimaryColor = from product in products select product.PrimaryColorCode;

            return Ok(productPrimaryColor.Distinct());

        }

        [HttpGet("/products/material")]
        public async Task<ActionResult> GetProductMaterialsAsync()
        {
            var products = await _productProvider.GetProductsAsync();
            var productMaterials = from product in products select product.Material;

            return Ok(productMaterials.Distinct());

        }

        [HttpDelete("/products/delete/{id:int}")]
        public async Task<ActionResult> DeleteProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for DeleteProductsByIdAsync for id: {id}");

            var product = await _productProvider.DeleteProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);

        }
        [HttpPut("/products/makeInactive/{id:int}")]
        public async Task<ActionResult> UpdateProductToInactiveAsync(int id)
        {
            _logger.LogInformation($"request recieved for UpdateProductsByIdAsync for id: {id}");
            var updatedProduct = await _productProvider.UpdateProductToInactiveAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }

        [HttpPut("/products/update/productViews/{id:int}")]
        public async Task<ActionResult> UpdateProductViewsAsync(int id)
        {
            _logger.LogInformation($"request recieved for UpdateProductViewsAsync for id: {id}");
            var updatedProduct = await _productProvider.UpdateProductViewsAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }

        [HttpPut("/products/update/latestView/{id:int}")]
        public async Task<ActionResult> UpdateLatestViewsAsync(int id)
        {
            _logger.LogInformation($"request recieved for UpdateLatestViewsAsync for id: {id}");
            var updatedProduct = await _productProvider.UpdateLatestViewsAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }


        [HttpPut("/products/{id:int}")]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(
            int id,
            [FromBody] ProductDTO productToUpdate)
        {
            _logger.LogInformation("Request received for update product");

            var product = _mapper.Map<Product>(productToUpdate);
            var updatedProduct = await _productProvider.UpdateProductAsync(id, product);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);

        }


        [HttpGet("/products/popular")]
        public async Task<ActionResult> PopularProducts()
        {
            _logger.LogInformation($"request recieved for Popular Products");
            var products = await _productProvider.GetActiveProducts();
            var orderedProducts = from product in products orderby product.ProductViews descending select product;

            return Ok(orderedProducts.Take(4));
        }
    }
}
