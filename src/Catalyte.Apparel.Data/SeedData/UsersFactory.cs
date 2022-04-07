using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random purchases.
    /// </summary>
    public class UsersFactory
    {
        
        private readonly List<string> _emails = new()
        {
            "jjones@gmail.com",
            "asmith@aol.com",
            "thebestuser@verizon.net",
            "bobbert@hotmail.com",
            "cphelps@catalyte.io",
            "zplanalp@catalyte.io",
            "ahyde@catalyte.io"
        };

        private readonly List<string> _firstNames = new()
        {
            "John",
            "Alice",
            "Jason",
            "Bob",
            "Connie",
            "Zack",
            "AJ"
        };

        private readonly List<string> _lastNames = new()
        {
            "Jones",
            "Smith",
            "Patel",
            "Bert",
            "Phelps",
            "Planalp",
            "Hyde"

        };
        
        /// <summary>
        /// Generates a number of products based on input.
        /// </summary>
        /// <param name="numberOfUsers">The number of products to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<User> GenerateUsers(int numberOfUsers)
        {

            var userList = new List<User>();

            for (var i = 0; i < numberOfUsers; i++)
            {
                userList.Add(CreateNextUser(i + 1));
            }

            return userList;
        }

        /// <summary>
        /// Uses seed data to build users.
        /// </summary>
        /// <param name="id">ID to assign to the user.</param>
        /// <returns>An incrementally generated user.</returns>
        private User CreateNextUser(int id)
        {
            int index = (id - 1)%7;
            return new User
            {
                Id = id,
                Email = _emails[index],
                Role = "member",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                FirstName = _firstNames[index],
                LastName = _lastNames[index],
            };
        }

    }
}
