using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(o=>o.Id == id);

            if (user.OrgId != 0)
                user.OstOrganization = await _osticketContext.OstOrganization.FirstOrDefaultAsync(o => o.Id == user.OrgId);

            return user;
        }

        public async Task<OstUser> GetUserByUsername(string username)
        {
            var user = await _osticketContext.OstUserAccount
                .Include(o => o.OstUserEmail)
                .FirstOrDefaultAsync(o => o.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
            
            return user.OstUser;
        }
    }
}
