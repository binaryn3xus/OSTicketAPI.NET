using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.For<UserRepository>();

        public UserRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<OstUser> GetUserByEmail(string email)
        {
            var user = await _osticketContext.OstUserEmail
                .FirstOrDefaultAsync(o => o.Address.Equals(email, StringComparison.InvariantCultureIgnoreCase))
                .ConfigureAwait(false);

            if (user != null)
                _logger.Debug("{UserName} found using the email address of {EmailAddress}", user.OstUser.Name, email);
            else
                _logger.Warn("Unable to find a user with the email of {EmailAddress}", email);

            return user?.OstUser;
        }

        public async Task<OstUser> GetUserById(int id)
        {
            var user = await _osticketContext.OstUser
                .Include(o => o.OstUserEmail)
                .Include(o => o.OstUserAccount)
                .FirstOrDefaultAsync(o => o.Id == id)
                .ConfigureAwait(false);

            if (user != null)
            {
                _logger.Debug("{UserName} found using the Id of {UserId}", user.Name, id);
                if (user.OrgId != 0)
                    user.OstOrganization = await _osticketContext.OstOrganization.FirstOrDefaultAsync(o => o.Id == user.OrgId).ConfigureAwait(false);
            }
            else
            {
                _logger.Warn("Unable to find a user with the Id of {UserId}", id);
            }

            return user;
        }

        public async Task<OstUser> GetUserByUsername(string username)
        {
            var user = await _osticketContext.OstUser
            .Include(o => o.OstUserEmail)
            .Include(o => o.OstUserAccount)
            .FirstOrDefaultAsync(o => o.OstUserAccount.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)).ConfigureAwait(false);

            if (user != null)
                _logger.Debug("{UserName} found using the username of {Username}", user.Name, username);
            else
                _logger.Warn("Unable to find a user with the username of {Username}", username);

            return user;
        }

        public async Task<OstUser> CreateRegisteredUser(UserCreationOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Email))
                throw new Exception($"{options.GetType()} must include a valid email address.");

            _logger.Info("Attempting to create OSTicket User with the email address of {EmailAddress}", options.Email);

            var userExists = await _osticketContext.OstUser
                .Include(o => o.OstUserAccount)
                .Include(o => o.OstUserEmail)
                .AnyAsync(o => o.OstUserAccount.Username.Equals(options.Username, StringComparison.InvariantCultureIgnoreCase) || o.OstUserEmail.Address.Equals(options.Email, StringComparison.InvariantCultureIgnoreCase))
                .ConfigureAwait(false);

            if (userExists)
            {
                _logger.Error("A user already exists using the email of {EmailAddress} OR the username of {Username}!", options.Email, options.Username);
                throw new Exception("User already exists!");
            }

            using (var transaction = _osticketContext.Database.BeginTransaction())
            {
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
                    if (!(await _osticketContext.SaveChangesAsync().ConfigureAwait(false) > 0))
                    {
                        _logger.Error("An error occurred trying to the save the new user of {Username}", options.Username);
                        throw new Exception("Error occurred during saving the new user!");
                    }

                    var userEmail = new OstUserEmail { UserId = user.Id, Flags = 0, Address = options.Email };

                    _osticketContext.OstUserEmail.Add(userEmail);

                    if (!(await _osticketContext.SaveChangesAsync().ConfigureAwait(false) > 0))
                    {
                        _logger.Error("An error occurred trying to the save the new user's ({Username}) email details using email address {EmailAddress}", options.Username, options.Email);
                        throw new Exception("Error occurred during saving the new user's email details!");
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

                    if (!(await _osticketContext.SaveChangesAsync().ConfigureAwait(false) > 0))
                    {
                        _logger.Error("An error occurred while trying to save the new user's ({Username}) OstUserAccount information", options.Username);
                        throw new Exception("Error occurred during saving the new user's email details!");
                    }

                    user.DefaultEmailId = userEmail.Id;
                    _osticketContext.OstUser.Update(user);

                    if (!(await _osticketContext.SaveChangesAsync().ConfigureAwait(false) > 0))
                    {
                        _logger.Error("An error occurred while trying to save the new user's ({Username}) default email id");
                        throw new Exception("Error occurred during saving the default email for the new user!");
                    }

                    transaction.Commit();

                    return await GetUserById(user.Id).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return null;
        }
    }
}
