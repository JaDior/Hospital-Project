using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random products.
    /// </summary>
    public class ProductFactory
    {
        Random _rand = new();

        private readonly List<string> _colors = new()
        {
            "#000000", // black
            "#ffffff", // white
            "#39add1", // light blue
            "#3079ab", // dark blue
            "#c25975", // mauve
            "#e15258", // red
            "#f9845b", // orange
            "#838cc7", // lavender
            "#7d669e", // purple
            "#53bbb4", // aqua
            "#51b46d", // green
            "#e0ab18", // mustard
            "#637a91", // dark gray
            "#f092b0", // pink
            "#b7c0c7"  // light gray
        };

        private readonly List<string> _demographics = new()
        {
            "Men",
            "Women",
            "Kids"
        };
        private readonly List<string> _categories = new()
        {
            "Golf",
            "Soccer",
            "Basketball",
            "Hockey",
            "Football",
            "Running",
            "Baseball",
            "Skateboarding",
            "Boxing",
            "Weightlifting"
        };

        private readonly List<string> _adjectives = new()
        {
            "Lightweight",
            "Slim",
            "Shock Absorbing",
            "Exotic",
            "Elastic",
            "Fashionable",
            "Trendy",
            "Next Gen",
            "Colorful",
            "Comfortable",
            "Water Resistant",
            "Wicking",
            "Heavy Duty"
        };

        private readonly List<string> _types = new()
        {
            "Pant",
            "Short",
            "Shoe",
            "Glove",
            "Jacket",
            "Tank Top",
            "Sock",
            "Sunglasses",
            "Hat",
            "Helmet",
            "Belt",
            "Visor",
            "Shin Guard",
            "Elbow Pad",
            "Headband",
            "Wristband",
            "Hoodie",
            "Flip Flop",
            "Pool Noodle"
        };

        private readonly List<string> _skuMods = new()
        {
            "Blue",
            "Red",
            "KJ",
            "SM",
            "RD",
            "LRG",
            "SM"
        };

        private readonly List<string> _brands = new()
        {
            "Nike",
            "Reebok",
            "Asics",
            "Brooks",
            "Skechers",
            "Puma",
            "Under Armor",
            "Adidas"
        };

        private readonly List<string> _materials = new()
        {
            "Cotton",
            "Polyester",
            "Microfiber",
            "Nylon",
            "Synthetic",
            "Gore -Tex",
            "Spandex",
            "Calico",
            "Bamboo -Fiber"
        };
        /// <summary>
        /// Generates a randomized product SKU.
        /// </summary>
        /// <returns>A SKU string.</returns>
        private string GetRandomSku()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(_skuMods[_rand.Next(0, 6)]);

            return builder.ToString().ToUpper();
        }
        /// <summary>
        /// Generates a random DateTime obj between range set by params
        /// </summary>
        /// <returns>random DateTime obj</returns>
        DateTime GetDateTime(int minYear, int maxYear)
        {
            int randomMonth = _rand.Next(2, 3);
            int randomYear = _rand.Next(minYear, maxYear);
            int randomDay = _rand.Next(1, 28);
            int randomHour = _rand.Next(0, 24);
            int randomMin = _rand.Next(0, 60);
            int randomSec = _rand.Next(0, 60);
            return new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMin, randomSec);
        }
        /// <summary>
        /// Returns a random demographic from the list of demographics.
        /// </summary>
        /// <returns>A demographic string.</returns>
        private string GetDemographic()
        {
            return _demographics[_rand.Next(0, _demographics.Count)];
        }

        /// <summary>
        /// Generates a random product offering id.
        /// </summary>
        /// <returns>A product offering string.</returns>
        private string GetRandomProductId()
        {
            return "po-" + RandomString(7);
        }
        /// <summary>
        /// Generates a random style code.
        /// </summary>
        /// <returns>A style code string.</returns>
        private string GetStyleCode()
        {
            return "sc-" + GetRandomInt(100000, 999999);
        }
        /// <summary>
        /// Generates a random color code.
        /// </summary>
        /// <returns>A random string from the _colors list</returns>
        private string GetRandomColorCode()
        {
            return _colors[_rand.Next(0, _colors.Count)];
        }
        /// <summary>
        /// Selects a random color from the '_materials' list
        /// </summary>
        /// <returns>A random string from the _materials list</returns>
        private string GetRandomMaterial()
        {
            return _materials[_rand.Next(0, _materials.Count)];
        }
        /// <summary>
        /// Select a random color from the _brands list
        /// </summary>
        /// <returns>A random string from the _brands list</returns>
        private string GetRandomBrand()
        {
            return _brands[_rand.Next(0, _brands.Count)];
        }
        /// <summary>
        /// Generates a random Boolean
        /// </summary>
        /// <returns>a random boolean</returns>
        private bool GetRandomBool()
        {
            return _rand.Next(2) == 1;
        }
        /// <summary>
        /// Generates a random int from the given min and max valies
        /// </summary>
        /// <param name="min">Lowst random number generated</param>
        /// <param name="max">Highest random number generated</param>
        /// <returns></returns>
        public int GetRandomInt(int min, int max)
        {
            return _rand.Next(min, max);
        }
        /// <summary>
        /// Generates a number of random products based on input.
        /// </summary>
        /// <param name="numberOfProducts">The number of random products to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<Product> GenerateRandomProducts(int numberOfProducts)
        {

            var productList = new List<Product>();

            for (var i = 0; i < numberOfProducts; i++)
            {
                productList.Add(CreateRandomProduct(i + 1));
            }

            return productList;
        }

        /// <summary>
        /// Uses random generators to build a products.
        /// </summary>
        /// <param name="id">ID to assign to the product.</param>
        /// <returns>A randomly generated product.</returns>
        private Product CreateRandomProduct(int id)
        {
            string cata = _categories[_rand.Next(0, _categories.Count)];
            string demogr = GetDemographic();
            string adj = _adjectives[_rand.Next(0, _adjectives.Count)];
            string typ = _types[_rand.Next(0, _types.Count)];
            decimal price = (decimal)GetRandomInt(1, 10000) / 100;
            string img = "https://www.signfix.com.au/wp-content/uploads/2017/09/placeholder-600x400.png";

            switch (cata)
            {
                case "Golf":
                    img = "https://image.shutterstock.com/z/stock-photo-golf-equipment-130536464.jpg";
                    break;
                case "Running":
                    img = "https://images.unsplash.com/photo-1491553895911-0055eca6402d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1760&q=80";
                    break;
                case "Hockey":
                    img = "https://image.shutterstock.com/z/stock-photo-ice-hockey-equipment-featuring-safety-helmet-pair-of-skates-gloves-stick-and-a-hockey-puck-552385843.jpg";
                    break;
                case "Weightlifting":
                    img = "https://image.shutterstock.com/z/stock-photo-two-orange-dumbbells-isolated-on-white-1521399890.jpg";
                    break;
                case "Football":
                    img = "https://images.unsplash.com/photo-1591037656559-373e224e9c5c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80";
                    break;
                case "Baseball":
                    img = "https://image.shutterstock.com/z/stock-photo-leather-glove-with-baseball-and-bat-isolated-over-white-background-87880732.jpg";
                    break;
                case "Soccer":
                    img = "https://images.unsplash.com/photo-1589467785902-054ed88148d8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80";
                    break;
                case "Skateboarding":
                    img = "https://image.shutterstock.com/z/stock-photo-flat-lay-of-longboard-equipment-and-accessories-isolated-on-white-background-top-view-of-skate-1460026919.jpg";
                    break;
                case "Basketball":
                    img = "https://image.shutterstock.com/z/stock-photo-basketball-shoes-and-gym-bag-isolated-on-white-126355946.jpg";
                    break;
                case "Boxing":
                    img = "https://image.shutterstock.com/z/stock-photo-black-wrestling-shoes-black-boxing-gloves-and-unwound-red-protective-bandages-for-martial-arts-1814319515.jpg";
                    break;
            }

            return new Product
            {
                Id = id,
                Name = $"{adj} {cata} {typ} ",
                Category = cata,
                Type = typ,
                PrimaryColorCode = GetRandomColorCode(),
                SecondaryColorCode = GetRandomColorCode(),
                Sku = GetRandomSku(),
                Description = $"{cata}, {demogr}, {adj} ",
                Demographic = demogr,
                GlobalProductCode = GetRandomProductId(),
                StyleNumber = GetStyleCode(),
                ReleaseDate = GetDateTime(2020, 2022),
                DateCreated = GetDateTime(2015, 2019),
                DateModified = DateTime.UtcNow,
                Active = GetRandomBool(),
                ImageSrc = img,
                Material = GetRandomMaterial(),
                Brand = GetRandomBrand(),
                Quantity = GetRandomInt(1, 100),
                Price = price,
                ProductViews = 0,
                LatestView = DateTime.MinValue,


            };
        }

        /// <summary>
        /// Generates a random string of characters.
        /// </summary>
        /// <param name="size">Number of characters in the string.</param>
        /// <param name="lowerCase">Boolean if the character string should be lowercase only; defaults to false.</param>
        /// <returns>A random string of characters.</returns>
        private string RandomString(int size, bool lowerCase = false)
        {

            // ** Learning moment **
            // Code From
            // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

            // ** Learning moment **
            // Always use a string builder when concatenating more than a couple of strings.
            // Why? https://www.geeksforgeeks.org/c-sharp-string-vs-stringbuilder/
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                // ** Learning moment **
                // Because 'char' is a reserved word you can put '@' at the beginning to allow
                // its use as a variable name.  You could do the same thing with 'class'
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
