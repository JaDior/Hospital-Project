using Catalyte.Apparel.DTOs.Products;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Catalyte.Apparel.DTOs.Purchases;
using System.Collections.Generic;
using Catalyte.Apparel.Data.Model;
using Newtonsoft.Json;
using System.Text;
using Catalyte.Apparel.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Catalyte.Apparel.Test.Integration
{
    public class ProductIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task Put_Product_Returns_Product()
        {
            // Arrange (new product to create)
            var product = new ProductDTO()
            {
                Id = 1,
                Name = "UpdatedProduct",
                Brand = "Toms",
                Sku = "YFU-TTL-RED",
                Quantity = "23",
                Description = "Walking, Women, Comfortable ",
                Material = "Canvas",
                ImageSrc = "https://image.shutterstock.com/image-photo/white-clothes-made-cotton-fabric-600w-1937841433.jpg",
                Price = "54",
                Demographic = "Women",
                Category = "Walking",
                Type = "Shoe",
                PrimaryColorCode = "#51b46d",
                SecondaryColorCode = "#51b46d",
                StyleNumber = "sc-927216",
                GlobalProductCode = "po-DYJRPLB",
                Active = true
            };
            // Act
            var json = JsonConvert.SerializeObject(product); //converts to JSON string
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/products/1", content);
            var responceContent = await response.Content.ReadAsStringAsync();
            var updatedProduct = JsonConvert.DeserializeObject<ProductDTO>(responceContent);
           // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(updatedProduct);
            Assert.IsType<ProductDTO>(updatedProduct);
            Assert.Equal(updatedProduct.Id, product.Id);
            Assert.Equal(updatedProduct.Name, product.Name);
            Assert.Equal(updatedProduct.Brand, product.Brand);
            Assert.Equal(updatedProduct.Sku, product.Sku);
            Assert.Equal(updatedProduct.Quantity, product.Quantity);
            Assert.Equal(updatedProduct.Description, product.Description);
            Assert.Equal(updatedProduct.Material, product.Material);
            Assert.Equal(updatedProduct.ImageSrc, product.ImageSrc);
            Assert.Equal(updatedProduct.Price, product.Price);
            Assert.Equal(updatedProduct.Demographic, product.Demographic);
            Assert.Equal(updatedProduct.Category, product.Category);
            Assert.Equal(updatedProduct.Type, product.Type);
            Assert.Equal(updatedProduct.PrimaryColorCode, product.PrimaryColorCode);
            Assert.Equal(updatedProduct.SecondaryColorCode, product.SecondaryColorCode);
            Assert.Equal(updatedProduct.StyleNumber, product.StyleNumber);
            Assert.Equal(updatedProduct.GlobalProductCode, product.GlobalProductCode);
            Assert.Equal(updatedProduct.Active, product.Active);
        }  


        [Fact]
        public async Task GetProducts_Returns200()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetFilteredProductsBrandReebok_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Brand=Reebok");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Reebok", content[0].Brand);
        }
        [Fact]
        public async Task GetFilteredProductsMaterial_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Material=Cotton");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Cotton", content[0].Material);
        }
        [Fact]
        public async Task GetFilteredProductsBrandMaterial_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Brand=Puma&Material=Calico");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Calico", content[0].Material);
            Assert.Equal("Puma", content[0].Brand);
        }
        [Fact]
        public async Task GetFilteredProductsBrandCategory_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Brand=Puma&Category=Baseball");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Baseball", content[0].Category);
        }
        [Fact]
        public async Task GetFilteredProductsCategory_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Category=Basketball");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Basketball", content[0].Category);
        }
        [Fact]

        public async Task GetFilteredProductsBrandPrice_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?Brand=Nike&MaxPrice=57.00");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Nike", content[0].Brand);
            Assert.True(decimal.Parse(content[0].Price) <= (decimal)57.00);
        }
        [Fact]
        public async Task GetFilteredProductsPrice_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?MaxPrice=27.00");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.True(decimal.Parse(content[0].Price) <= (decimal)27.00);
        }

        [Fact]
        public async Task GetFilteredProductsMinPriceColor_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?MinPrice=10.00&Color=%23ffffff");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            if (content[0].PrimaryColorCode == "#ffffff")
                Assert.Equal("#ffffff", content[0].PrimaryColorCode);
            else
                Assert.Equal("#ffffff", content[0].SecondaryColorCode);
            Assert.True(decimal.Parse(content[0].Price) >= (decimal)10.00);
        }
        [Fact]
        public async Task GetFilteredProductMaxPriceDemographic_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?MaxPrice=50.00&Demographic=Men");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Equal("Men", content[0].Demographic);
            Assert.True(decimal.Parse(content[0].Price) <= (decimal)50.00);
        }

        [Fact]
        public async Task GetFilteredProductsNegativePrice_Returns400()
        {
            var response = await _client.GetAsync("/products/filter/?MinPrice=-10.00");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetFilteredProductsNonNumericPrice_Returns400()
        {
            var response = await _client.GetAsync("/products/filter/?MinPrice=def&MaxPrice=abc");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetFilteredProductsDollarSignInPrice_Returns200()
        {
            var response = await _client.GetAsync("/products/filter/?MinPrice=%2440.00");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            List<ProductDTO> content = null;
            content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.True(decimal.Parse(content[0].Price) >= (decimal)40.00);
        }
        [Fact]
        public async Task GetFilteredProductsNegativeMaxPrice_Returns400()
        {
            var response = await _client.GetAsync("/products/filter/?MaxPrice=-10.00");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetFilteredProductsMaxPriceLessThanMinPrice_Returns400()
        {
            var response = await _client.GetAsync("/products/filter/?MinPrice=100.00&MaxPrice=10");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }

        [Fact]
        public async Task GetProductCategories_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/categories");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }


        [Fact]
        public async Task GetProductTypes_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/types");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task GetProductBrands_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/brands");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task GetProductDemographics_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/demographics");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task GetProductPrimaryColors_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/primarycolor");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task GetProductMaterials_Returns200()
        {
            var response1 = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

            var response2 = await _client.GetAsync("/products/material");
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }
    }
}
