using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;

namespace OSTicketAPI.NET.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OSTicketContext _osticketContext;

        public UserRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<OstUser> GetUserByEmail(string email)
        {
            var user = await _osticketContext.OstUserEmail
                .FirstOrDefaultAsync(o => o.Address.Equals(email, StringComparison.InvariantCultureIgnoreCase));

            return user.OstUser;
        }

        public async Task<OstUser> GetUserById(int id)
        {
            var user = await _osticketContext.OstUser
                .Include(o => o.OstUserEmail)
                .Include(o => o.OstUserAccount)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (user.OrgId != 0)
                user.OstOrganization = await _osticketContext.OstOrganization.FirstOrDefaultAsync(o => o.Id == user.OrgId);

            return user;
        }

        public async Task<OstUser> GetUserByUsername(string username)
        {
            var user = await _osticketContext.OstUser
            .Include(o => o.OstUserEmail)
            .Include(o => o.OstUserAccount)
            .FirstOrDefaultAsync(o => o.OstUserAccount.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

            return user;
        }

        public async Task<OstUser> CreateRegisteredUser(UserCreationOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Email))
                throw new Exception($"{options.GetType()} must include a valid email address.");
            
            var userExists = await _osticketContext.OstUser
                .Include(o => o.OstUserAccount)
                .Include(o => o.OstUserEmail)
                .AnyAsync(o => o.OstUserAccount.Username.Equals(options.Username,
                              StringComparison.InvariantCultureIgnoreCase) ||
                          o.OstUserEmail.Address.Equals(options.Email,
                              StringComparison.InvariantCultureIgnoreCase));

            if (userExists)
                throw new Exception("User already exists!");

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
                    if (!(await _osticketContext.SaveChangesAsync() > 0))
                        throw new Exception("Error occurred during saving the new user!");

                    var userEmail = new OstUserEmail {UserId = user.Id, Flags = 0, Address = options.Email};

                    _osticketContext.OstUserEmail.Add(userEmail);

                    if (!(await _osticketContext.SaveChangesAsync() > 0))
                        throw new Exception("Error occurred during saving the new user's email details!");

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

                    if (!(await _osticketContext.SaveChangesAsync() > 0))
                        throw new Exception("Error occurred during saving the new user's email details!");

                    transaction.Commit();

                    return await GetUserById(user.Id);
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
