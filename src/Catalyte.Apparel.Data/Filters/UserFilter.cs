using Catalyte.Apparel.Data.Model;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters
{
    /// <summary>
    /// Filter collection for user context queries.
    /// </summary>
    public static class UserFilter
    {
        public static IQueryable<User> WhereUserEmailEquals(this IQueryable<User> users, string email)
        {
            return users.Where(u => u.Email == email).AsQueryable();
        }
    }
}
