using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Exceptions;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.Repositories
{
    public class UserRepository : IUserRepository<User, OstUser>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserRepository(OSTicketContext osticketContext, IMapper mapper, ILogger<UserRepository> logger = null)
        {
            _osticketContext = osticketContext;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get users from OSTicket
        /// </summary>
        /// <param name="expression">Optional parameter to filter users</param>
        /// <returns>Returns a collection of OstUsers</returns>
        public async Task<IEnumerable<User>> GetUsers(Expression<Func<OstUser, bool>> expression = null)
        {
            var users = await GetQueryableUsersAsync(expression).ConfigureAwait(false);
            return users.ToList();
        }

        /// <summary>
        /// Get a User by email address
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Returns an OstUser object or null if user does not exist</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            var users = await GetQueryableUsersAsync(o => o.OstUserEmail.Address.Equals(email
                , StringComparison.InvariantCultureIgnoreCase)).ConfigureAwait(false);
            var user = users.FirstOrDefault();

            if (user != null)
                _logger?.LogDebug("{UserName} found using the email address of {EmailAddress}", user.Name, email);
            else
                _logger?.LogWarning("Unable to find a user with the email of {EmailAddress}", email);

            return user;
        }

        /// <summary>
        /// Get a User by User Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Returns an OstUser object or null if user does not exist</returns>
        public async Task<User> GetUserById(int id)
        {
            var users = await GetQueryableUsersAsync(o => o.Id == id).ConfigureAwait(false);
            var user = users.FirstOrDefault();

            if (user == null)
            {
                _logger?.LogWarning("Unable to find a user with the Id of {UserId}", id);
                return null;
            }

            _logger?.LogDebug("{UserName} found using the Id of {UserId}", user.Name, id);
            return user;
        }

        /// <summary>
        /// Get a User by username
        /// </summary>
        /// <param name="username">Required username of the User to retrieve</param>
        /// <returns>Returns an OstUser object or null if user does not exist</returns>
        public async Task<User> GetUserByUsername(string username)
        {
            var user = await GetQueryableUsersAsync(o => o.OstUserAccount.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);

            var returnUser = user.FirstOrDefault();
            if (returnUser != null)
                _logger?.LogDebug("{UserName} found using the username of {Username}", returnUser.Name, username);
            else
                _logger?.LogWarning("Unable to find a user with the username of {Username}", username);

            return returnUser;
        }

        /// <summary>
        /// Create an already registered user in OSTicket
        /// </summary>
        /// <param name="options">Options for user creation</param>
        /// <returns>Returns the created OstUser</returns>
        public async Task<User> CreateRegisteredUser(UserCreationOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Email))
                throw new UserCreationException($"{options.GetType()} must include a valid email address.");

            _logger?.LogInformation("Attempting to create OSTicket User with the email address of {EmailAddress}", options.Email);

            var userExists = await _osticketContext.OstUser
                .Include(o => o.OstUserAccount)
                .Include(o => o.OstUserEmail)
                .AnyAsync(o => o.OstUserAccount.Username.Equals(options.Username, StringComparison.InvariantCultureIgnoreCase) || o.OstUserEmail.Address.Equals(options.Email, StringComparison.InvariantCultureIgnoreCase))
                .ConfigureAwait(false);

            if (userExists)
            {
                _logger?.LogError("A user already exists using the email of {EmailAddress} OR the username of {Username}!", options.Email, options.Username);
                throw new UserCreationException(options.Username, options.Email);
            }

            await using var transaction = _osticketContext.Database.BeginTransaction();
            var user = new OstUser
            {
                OrgId = options.OrgId,
                DefaultEmailId = 1,
                Status = 0,
                Name = options.Name,
                Created = options.Created,
                Updated = options.Updated
            };

            _osticketContext.OstUser.Add(user);
            try
            {
                if (await _osticketContext.SaveChangesAsync().ConfigureAwait(false) <= 0)
                {
                    _logger?.LogError("An error occurred trying to the save the new user of {Username}",
                        options.Username);
                    throw new UserCreationException("Unknown error occurred while attempting saving the new user!");
                }

                var userEmail = new OstUserEmail {UserId = user.Id, Flags = 0, Address = options.Email};

                _osticketContext.OstUserEmail.Add(userEmail);

                if (await _osticketContext.SaveChangesAsync().ConfigureAwait(false) <= 0)
                {
                    _logger?.LogError(
                        "An error occurred trying to the save the new user's ({Username}) email details using email address {EmailAddress}",
                        options.Username, options.Email);
                    throw new UserCreationException("Error occurred while saving the new user's email details!");
                }

                var userAccount = new OstUserAccount
                {
                    UserId = user.Id,
                    Status = 1,
                    Timezone = options.Timezone,
                    Lang = null,
                    Username = options.Username,
                    Passwd = options.Password,
                    Backend = options.Backend,
                    Extra = options.Extra,
                    Registered = options.Registered
                };

                _osticketContext.OstUserAccount.Add(userAccount);

                if (await _osticketContext.SaveChangesAsync().ConfigureAwait(false) <= 0)
                {
                    _logger?.LogError(
                        "An error occurred while trying to save the new user's ({Username}) OstUserAccount information",
                        options.Username);
                    throw new UserCreationException("Error occurred while saving the new user's email details!");
                }

                user.DefaultEmailId = userEmail.Id;
                _osticketContext.OstUser.Update(user);

                if (await _osticketContext.SaveChangesAsync().ConfigureAwait(false) <= 0)
                {
                    _logger?.LogError(
                        "An error occurred while trying to save the new user's ({Username}) default email id");
                    throw new UserCreationException(
                        "Error occurred while saving the default email for the new user!");
                }

                transaction.Commit();

                return await GetUserById(user.Id).ConfigureAwait(false);
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private async Task<IQueryable<User>> GetQueryableUsersAsync(Expression<Func<OstUser, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var query = _osticketContext.OstUser
                    .Include(o => o.OstUserEmail)
                    .Include(o => o.OstUserAccount)
                    .Include(o => o.OstOrganization)
                    .AsQueryable();

                if (expression != null)
                    query = query.Where(expression);

                var users = _mapper.Map<IEnumerable<User>>(query);

                return users.AsQueryable();
            }).ConfigureAwait(false);
        }
    }
}
