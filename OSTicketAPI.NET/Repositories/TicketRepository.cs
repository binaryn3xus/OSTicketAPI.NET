using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.GetCurrentClassLogger();

        public TicketRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<IEnumerable<OstTicket>> GetTickets()
        {
            var data = await GetQueryableTicketsAsync(null).ConfigureAwait(false);
            return data.ToList();
        }

        public async Task<List<OstTicketStatus>> GetTicketStatuses()
        {
            return await _osticketContext.OstTicketStatus.OrderBy(o => o.Sort).ToListAsync().ConfigureAwait(false);
        }

        public async Task<OstTicket> GetTicketByTicketId(int ticketId)
        {
            var data = await GetQueryableTicketsAsync(o => o.TicketId == ticketId).ConfigureAwait(false);
            var ticket = data.FirstOrDefault(o => o.TicketId == ticketId);
            if (ticket != null)
                _logger.Info("Found {TicketId}", ticket.TicketId);
            return ticket;
        }

        public async Task<OstTicket> GetTicketByTicketNumber(string ticketNumber)
        {
            var data = await GetQueryableTicketsAsync(o => o.Number == ticketNumber).ConfigureAwait(false);
            var ticket = data.FirstOrDefault(o => o.Number == ticketNumber);
            if (ticket != null)
                _logger.Info("Found {TicketId}", ticket.TicketId);
            return ticket;
        }

        public async Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId)
        {
            if (userId == default)
                throw new ArgumentNullException($"\"{userId}\" is not a valid user id");

            var data = await GetQueryableTicketsAsync(o => o.UserId.Equals(userId)).ConfigureAwait(false);
            var ticketList = data.ToList();
            _logger.Info("Found {TicketCount} tickets for User ID {userId}", ticketList.Count, userId);
            return ticketList;
        }

        public async Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user)
        {
            if (user?.OstUserAccount?.Username == null)
                throw new ArgumentNullException($"Username not found in Type {user?.GetType()}");

            var data = await GetQueryableTicketsAsync(o => o.UserId.Equals(user.Id)).ConfigureAwait(false);
            var ticketList = data.ToList();
            _logger.Info("Found {TicketCount} tickets for User ID {userId}", ticketList.Count, user.OstUserAccount.Username);
            return ticketList;
        }

        private async Task<IEnumerable<OstTicket>> GetQueryableTicketsAsync(Expression<Func<OstTicket, bool>> expression)
        {
            var ticketQuery = _osticketContext.OstTicket
                .Include(o => o.OstUser)
                .Include(o => o.OstTicketStatus)
                .Include(o => o.OstDepartment)
                .Include(o => o.OstSla)
                .Include(o => o.OstThread)
                .ThenInclude(o => o.OstThreadEntries)
                .Include(o => o.OstThread)
                .ThenInclude(o => o.OstThreadEvents)
                .AsQueryable();

            if (expression != null)
                ticketQuery = ticketQuery.Where(expression);

            var tickets = ticketQuery.ToList();

            foreach (var ticket in tickets)
            {
                if (ticket.TopicId != 0)
                    ticket.OstHelpTopic = await _osticketContext.OstHelpTopic.SingleOrDefaultAsync(o => o.TopicId == ticket.TopicId).ConfigureAwait(false);

                if (ticket.StaffId != 0)
                    ticket.OstStaff = await _osticketContext.OstStaff.SingleOrDefaultAsync(o => o.StaffId == ticket.StaffId).ConfigureAwait(false);

                if (ticket.TeamId != 0)
                    ticket.OstTeam = await _osticketContext.OstTeam.SingleOrDefaultAsync(o => o.TeamId == ticket.TicketId).ConfigureAwait(false);
            }

            return tickets.AsQueryable();
        }
    }
}
