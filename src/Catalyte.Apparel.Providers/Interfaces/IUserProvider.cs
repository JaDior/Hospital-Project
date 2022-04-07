using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for user related service methods.
    /// </summary>
    public interface IUserProvider
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<User> UpdateUserAsync(string credentials, int id, User user);

        Task<User> CreateUserAsync(User user);

        Task UpdateUserInfoAsync(string email, Dictionary<string, dynamic> updateObj);
    }
}
