using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.DTOs.Products
{
    /// <summary>
    /// Describes a data transfer object for a product.
    /// </summary>
    public class ProductDTO
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Sku { get; set; }

        public string Quantity { get; set; }

        public string Description { get; set; }

        public string Material { get; set; }

        public string ImageSrc { get; set; }

        public string Price { get; set; }

        public string Demographic { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PrimaryColorCode { get; set; }

        public string SecondaryColorCode { get; set; }

        public string StyleNumber { get; set; }

        public string GlobalProductCode { get; set; }

        public bool Active { get; set; }

        public DateTime LatestView { get; set; }

        public double ProductViews { get; set; }

    }
    public class ProductFilterDTO
    {
        public List<string> Brand { get; set; }

        public List<string> Material { get; set; }

        public string MaxPrice { get; set; }

        public string MinPrice { get; set; }

        public List<string> Demographic { get; set; }

        public List<string> Category { get; set; }

        public List<string> Color { get; set; }

        public bool Active { get; set; }

        public string Orderby { get; set; }

        public string Desc { get; set; }

    }
}
