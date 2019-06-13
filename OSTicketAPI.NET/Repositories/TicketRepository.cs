using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;

namespace OSTicketAPI.NET.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly OSTicketContext _osticketContext;

        public TicketRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<List<OstTicketStatus>> GetTicketStatuses()
        {
            return await _osticketContext.OstTicketStatus.OrderBy(o => o.Sort).ToListAsync().ConfigureAwait(false);
        }

        public async Task<OstTicket> GetTicketByTicketId(int ticketId)
        {
            var ticket = await GetTickets()
                .FirstOrDefaultAsync(o => o.TicketId == ticketId)
                .ConfigureAwait(false);

            if (ticket == null)
                return null;

            if (ticket.TopicId != 0)
                ticket.OstHelpTopic = await _osticketContext.OstHelpTopic.FirstOrDefaultAsync(o => o.TopicId == ticket.TopicId).ConfigureAwait(false);

            if (ticket.StaffId != 0)
                ticket.OstStaff = await _osticketContext.OstStaff.FirstOrDefaultAsync(o => o.StaffId == ticket.StaffId).ConfigureAwait(false);

            if (ticket.TeamId != 0)
                ticket.OstTeam = await _osticketContext.OstTeam.FirstOrDefaultAsync(o => o.TeamId == ticket.TicketId).ConfigureAwait(false);

            return ticket;
        }

        public async Task<OstTicket> GetTicketByTicketNumber(string ticketNumber)
        {
            var ticket = await GetTickets()
                .FirstOrDefaultAsync(o => o.Number == ticketNumber)
                .ConfigureAwait(false);

            if (ticket == null)
                return null;

            if (ticket.TopicId != 0)
                ticket.OstHelpTopic = await _osticketContext.OstHelpTopic.FirstOrDefaultAsync(o => o.TopicId == ticket.TopicId).ConfigureAwait(false);

            if (ticket.StaffId != 0)
                ticket.OstStaff = await _osticketContext.OstStaff.FirstOrDefaultAsync(o => o.StaffId == ticket.StaffId).ConfigureAwait(false);

            if (ticket.TeamId != 0)
                ticket.OstTeam = await _osticketContext.OstTeam.FirstOrDefaultAsync(o => o.TeamId == ticket.TicketId).ConfigureAwait(false);

            return ticket;
        }

        public async Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId)
        {
            if (userId == default)
                throw new ArgumentNullException($"\"{userId}\" is not a valid user id");

            var data = GetTickets();

            var returnData = await data.Where(o => o.UserId.Equals(userId)).ToListAsync().ConfigureAwait(false);
            return returnData;
        }

        public async Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user)
        {
            if (user?.OstUserAccount?.Username == null)
                throw new ArgumentNullException($"Username not found in Type {user?.GetType()}");

            var data = GetTickets();

            var returnData = await data.Where(o => o.UserId.Equals(user.Id)).ToListAsync().ConfigureAwait(false);
            return returnData;
        }

        private IQueryable<OstTicket> GetTickets()
        {
            return _osticketContext.OstTicket
                .Include(o => o.OstUser)
                .Include(o => o.OstTicketStatus)
                .Include(o => o.OstDepartment)
                .Include(o => o.OstSla)
                .Include(o => o.OstThread)
                .ThenInclude(o => o.OstThreadEntries)
                .Include(o => o.OstThread)
                .ThenInclude(o => o.OstThreadEvents);
        }
    }
}
