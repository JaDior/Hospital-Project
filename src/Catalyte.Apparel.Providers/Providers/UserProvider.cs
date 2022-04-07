using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using Catalyte.Apparel.Providers.Auth;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IUserProvider interface, providing service methods for users.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        private readonly ILogger<UserProvider> _logger;
        private readonly IUserRepository _userRepository;
        private readonly GoogleAuthService googleAuthService = new();

        public UserProvider(
            IUserRepository userRepository,
            ILogger<UserProvider> logger
        )
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user;

            try
            {
                user = await _userRepository.GetUserByEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (user == default)
            {
                _logger.LogError($"Could not find user with email: {email}");
                throw new NotFoundException($"Could not find user with email: {email}");
            }

            return user;
        }

        /// <summary>
        /// Persists updated user information given they have provided the correct credentials.
        /// </summary>
        /// <param name="bearerToken">String value in the "Authorization" property of the header.</param>
        /// <param name="id">Id of the user to update.</param>
        /// <param name="updatedUser">Updated user information to persist.</param>
        /// <returns>The updated user.</returns>
        public async Task<User> UpdateUserAsync(string bearerToken, int id, User updatedUser)
        {
            // AUTHENTICATES USER - SAME EMAIL, SAME PERSON
            // Authenticating the user ensures that the user is using Google to sign in
            string token = googleAuthService.GetTokenFromHeader(bearerToken);
            bool isAuthenticated = await googleAuthService.AuthenticateUserAsync(token, updatedUser);

            if (!isAuthenticated)
            {
                _logger.LogError("Email in the request body does not match email from the JWT Token");
                throw new BadRequestException("Email in the request body does not match email from JWT Token");
            }

            // UPDATES USER
            User existingUser;

            try
            {
                existingUser = await _userRepository.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingUser == default || existingUser.Email != updatedUser.Email)
            {
                _logger.LogInformation($"User with id: {id} does not exist.");
                throw new NotFoundException($"User with id:{id} not found.");
            }

            // TEMPORARY LOGIC TO PREVENT USER FROM UPDATING THEIR ROLE
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.StreetAddress = updatedUser.StreetAddress;
            existingUser.StreetAddress2 = updatedUser.StreetAddress2;
            existingUser.City = updatedUser.City;
            existingUser.State = updatedUser.State;
            existingUser.ZipCode = updatedUser.ZipCode;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.DateModified = DateTime.UtcNow;
            try
            {
                await _userRepository.UpdateUserAsync(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return updatedUser;
        }

        /// <summary>
        /// </summary> a function that update the datebase from the UI By using patch
        /// <param name="email">user email</param>
        /// <param name="updateObj">Updated user information to persist</param>
        /// <returns>send the new update to the database</returns>
        public async Task UpdateUserInfoAsync(string email, Dictionary<string, dynamic> updateObj)
        {
            var user = await GetUserByEmailAsync(email);
            if (updateObj.ContainsKey("updateLastActiveTime") && updateObj["updateLastActiveTime"].GetBoolean())
            { await _userRepository.UpdateLastActiveTimeAsync(user); }
        }

                /// <summary>
                /// Persists a user to the database given the provided email is not already in the database or null.
                /// </summary>
                /// <param name="user">The user to persist.</param>
                /// <returns>The user.</returns>
                public async Task<User> CreateUserAsync(User newUser)
        {
            if (newUser.Email == null)
            {
                _logger.LogError("User must have an email field.");
                throw new BadRequestException("User must have an email field");
            }

            // CHECK TO MAKE SURE THE USE EMAIL IS NOT TAKEN
            User existingUser;

            try
            {
                existingUser = await _userRepository.GetUserByEmailAsync(newUser.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingUser != default)
            {
                _logger.LogError("Email is taken.");
                throw new ConflictException("Email is taken");
            }

            // SET DEFAULT ROLE TO CUSTOMER AND TIMESTAMP
            newUser.Role = Constants.CUSTOMER;
            newUser.DateCreated = DateTime.UtcNow;
            newUser.DateModified = DateTime.UtcNow;
            newUser.LastActiveTime = DateTime.UtcNow;

            User savedUser;

            try
            {
                savedUser = await _userRepository.CreateUserAsync(newUser);
                _logger.LogInformation("User saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedUser;

        }
    }
}
