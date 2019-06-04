using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.DTO;
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
            var ticket = await _osticketContext.OstTicket
                .Include(o => o.OstUser)
                .Include(o => o.OstTicketStatus)
                .Include(o => o.OstDepartment)
                .Include(o => o.OstSla)
                .Include(o => o.OstHelpTopic)
                .FirstAsync(o => o.TicketId == ticketId)
                .ConfigureAwait(false);

            if (ticket.StaffId != 0)
                ticket.OstStaff = await _osticketContext.OstStaff.FirstOrDefaultAsync(o => o.StaffId == ticket.StaffId).ConfigureAwait(false);

            if (ticket.TeamId != 0)
                ticket.OstTeam = await _osticketContext.OstTeam.FirstOrDefaultAsync(o => o.TeamId == ticket.TicketId).ConfigureAwait(false);

            return ticket;
        }

        public async Task<TicketThread> GetTicketThreadByTicketId(int ticketId)
        {
            return await Task.Run(() => new TicketThread(_osticketContext, ticketId)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<OstTicket>> GetTicketsByUser(int userId)
        {
            var tickets = _osticketContext.OstTicket
                .Include(o => o.OstUser)
                .Include(o => o.OstTicketStatus)
                .Include(o => o.OstDepartment)
                .Include(o => o.OstSla)
                .Include(o => o.OstHelpTopic)
                .Where(o => o.UserId == userId);

            return await tickets.ToListAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user)
        {
            throw new NotImplementedException();
        }
    }
}
