using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Globalization;
using Catalyte.Apparel.DTOs.Products;

namespace Catalyte.Apparel.Data.Filters
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }

    /// <summary>
    /// Filter collection for product context queries.
    /// </summary>
    public static class ProductFilters
    {
        public static IQueryable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId).AsQueryable();
        }
        /// <summary>
        /// Asynchronously retrieves filtered products from the database.
        /// </summary>
        /// <returns>Filtered products from the database.</returns>
        public static IQueryable<Product> WhereFilteredProductEquals(this IQueryable<Product> products, ProductFilterDTO filter)
        {
            //Create the predicate, once filled with all filters, predicate will be passed into Where() only once
            var predicate = PredicateBuilder.True<Product>();
            var innerPredicate = PredicateBuilder.False<Product>();

            //add brands to the predicate if there are any brands in the query
            if (filter.Brand != null)
            {
                foreach (string brand in filter.Brand)
                {
                    innerPredicate = innerPredicate.Or(p => p.Brand == brand);
                }
                predicate = innerPredicate;
            }
            //add categories to the predicate if there are any categories in the query
            if (filter.Category != null)
            {
                innerPredicate = PredicateBuilder.False<Product>(); //reset
                foreach (string category in filter.Category)
                {
                    innerPredicate = innerPredicate.Or(p => p.Category == category);
                }
                predicate = predicate.And(innerPredicate);
            }
            //add materials to the predicate if there are any categories in the query
            if (filter.Material != null)
            {
                innerPredicate = PredicateBuilder.False<Product>(); //reset
                foreach (string material in filter.Material)
                {
                    innerPredicate = innerPredicate.Or(p => p.Material == material);
                }
                predicate = predicate.And(innerPredicate);
            }
            //add demographic to the predicate if there are any categories in the query
            if (filter.Demographic != null)
            {
                innerPredicate = PredicateBuilder.False<Product>(); //reset
                foreach (string demographic in filter.Demographic)
                {
                    innerPredicate = innerPredicate.Or(p => p.Demographic == demographic);
                }
                predicate = predicate.And(innerPredicate);
            }
            //add color to the predicate if there are any categories in the query
            if (filter.Color != null)
            {
                innerPredicate = PredicateBuilder.False<Product>(); //reset
                foreach (string color in filter.Color)
                {
                    innerPredicate = innerPredicate.Or(p => p.PrimaryColorCode == color);
                    innerPredicate = innerPredicate.Or(p => p.SecondaryColorCode == color);
                }
                predicate = predicate.And(innerPredicate);
            }
            // add price to the predicate if there are any categories in the query
            if ((filter.MinPrice != null) || (filter.MaxPrice != null))
            {
                // set currency parser to en-US culture to remove $.
                decimal minPrice = 0;
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                if (filter.MinPrice != null)
                {
                    Decimal.TryParse(filter.MinPrice, style, culture, out minPrice); //remove any $
                    predicate = predicate.And(p => p.Price >= minPrice);
                }
                if (filter.MaxPrice != null)
                {
                    decimal maxPrice = 0;
                    Decimal.TryParse(filter.MaxPrice, style, culture, out maxPrice); //remove any $
                    if (maxPrice >= minPrice)
                    {
                        predicate = predicate.And(p => p.Price <= maxPrice);
                    }
                }
            }
            predicate = predicate.And(p => p.Active == true); //retrieve only active products
            products = products.Where(predicate).AsQueryable();

            products = products.OrderBy(p => p.Id);
            return products;

        }
    }
}
