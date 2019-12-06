using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.Repositories
{
    public class TicketRepository : ITicketRepository<OstTicket>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly IMapper _mapper;
        private readonly ILog _logger = LogProvider.GetCurrentClassLogger();

        public TicketRepository(OSTicketContext osticketContext, IMapper mapper)
        {
            _osticketContext = osticketContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all tickets in OSTicket
        /// </summary>
        /// <param name="expression">Expression to narrow down tickets in a search</param>
        /// <returns>Returns an IEnumerable of OstTickets</returns>
        public async Task<IEnumerable<OstTicket>> GetTickets(Expression<Func<OstTicket, bool>> expression = null)
        {
            var data = await GetQueryableTicketsAsync(expression).ConfigureAwait(false);
            return data.ToList();
        }

        /// <summary>
        /// Returns all ticket statuses based on an expression
        /// </summary>
        /// <returns>IEnumerable of OstTicketStatus</returns>
        public async Task<IEnumerable<TicketStatus>> GetTicketStatuses()
        {
            return await Task.Run(() =>
            {
                var dbStatuses = _osticketContext.OstTicketStatus.AsQueryable();

                var statuses = _mapper.Map<IEnumerable<TicketStatus>>(dbStatuses);

                return statuses.ToList();
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get ticket by id
        /// </summary>
        /// <param name="ticketId">Required ticket id</param>
        /// <returns>Returns an OstTicket object or null if it does not exist</returns>
        public async Task<OstTicket> GetTicketByTicketId(int ticketId)
        {
            var data = await GetQueryableTicketsAsync(o => o.TicketId == ticketId).ConfigureAwait(false);
            var ticket = data.FirstOrDefault(o => o.TicketId == ticketId);
            if (ticket != null)
                _logger.Debug("Found {TicketId}", ticket.TicketId);
            return ticket;
        }

        /// <summary>
        /// Get ticket by ticket number
        /// </summary>
        /// <param name="ticketNumber">Required ticket number</param>
        /// <returns>Returns an OstTicket object or null if it does not exist</returns>
        public async Task<OstTicket> GetTicketByTicketNumber(string ticketNumber)
        {
            var data = await GetQueryableTicketsAsync(o => o.Number == ticketNumber).ConfigureAwait(false);
            var ticket = data.FirstOrDefault(o => o.Number == ticketNumber);
            if (ticket != null)
                _logger.Debug("Found {TicketId}", ticket.TicketId);
            return ticket;
        }

        public Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId)
        {
            if (userId == default)
                throw new ArgumentNullException($"\"{userId}\" is not a valid user id");

            return GetTicketsByUserIdInternal(userId);
        }

        private async Task<IEnumerable<OstTicket>> GetTicketsByUserIdInternal(int userId)
        {
            var data = await GetQueryableTicketsAsync(o => o.UserId.Equals(userId)).ConfigureAwait(false);
            var ticketList = data.ToList();
            _logger.Debug("Found {TicketCount} tickets for User ID {userId}", ticketList.Count, userId);
            return ticketList;
        }

        public Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user)
        {
            if (user?.OstUserAccount?.Username == null)
                throw new ArgumentNullException($"Username not found in Type {user?.GetType()}");
            return GetTicketsByOstUserInternal(user);
        }

        /// <summary>
        /// Get all tickets for a certain user by OstUser
        /// </summary>
        /// <param name="user">OstUser</param>
        /// <returns>Returns IEnumerable of OstTicket objects</returns>
        public async Task<IEnumerable<OstTicket>> GetTicketsByOstUserInternal(OstUser user)
        {

            var data = await GetQueryableTicketsAsync(o => o.UserId.Equals(user.Id)).ConfigureAwait(false);
            var ticketList = data.ToList();
            _logger.Debug("Found {TicketCount} tickets for User ID {userId}", ticketList.Count, user.OstUserAccount.Username);
            return ticketList;
        }

        /// <summary>
        /// Update a ticket by Id
        /// </summary>
        /// <param name="ticketNumber">Number of the ticket to update</param>
        /// <param name="ticket">Ticket object to update</param>
        /// <returns>The ticket object will be returned</returns>
        public async Task<OstTicket> UpdateTicketById(int ticketNumber, OstTicket ticket)
        {
            var dbTicket = await _osticketContext.OstTicket.FirstOrDefaultAsync(o => o.TicketId == ticketNumber).ConfigureAwait(false);
            _osticketContext.Entry(ticket).CurrentValues.SetValues(dbTicket);
            await _osticketContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
        }

        /// <summary>
        /// Update a ticket by Number
        /// </summary>
        /// <param name="ticketNumber">Number of the ticket to update</param>
        /// <param name="ticket">Ticket object to update</param>
        /// <returns>The ticket object will be returned</returns>
        public async Task<OstTicket> UpdateTicketByNumber(string ticketNumber, OstTicket ticket)
        {
            var dbTicket = await _osticketContext.OstTicket.FirstOrDefaultAsync(o => o.Number == ticketNumber).ConfigureAwait(false);
            _osticketContext.Entry(dbTicket).CurrentValues.SetValues(ticket);
            await _osticketContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
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
                .Include(o => o.OstFormEntry)
                .ThenInclude(o => o.OstForm)
                .Include(o => o.OstFormEntry)
                .ThenInclude(o => o.OstFormEntryValues)
                .ThenInclude(o => o.OstFormField)
                .AsQueryable();

            if (expression != null)
                ticketQuery = ticketQuery.Where(expression);

            var tickets = ticketQuery.ToList();

            foreach (var ticket in tickets)
            {
                if (ticket.TopicId != 0)
                {
                    ticket.OstHelpTopic = await _osticketContext.OstHelpTopic
                        .SingleOrDefaultAsync(o => o.TopicId == ticket.TopicId).ConfigureAwait(false);
                }

                if (ticket.StaffId != 0)
                {
                    ticket.OstStaff = await _osticketContext.OstStaff
                        .SingleOrDefaultAsync(o => o.StaffId == ticket.StaffId).ConfigureAwait(false);
                }

                if (ticket.TeamId != 0)
                {
                    ticket.OstTeam = await _osticketContext.OstTeam
                        .SingleOrDefaultAsync(o => o.TeamId == ticket.TicketId).ConfigureAwait(false);
                }
            }

            return tickets.AsQueryable();
        }
    }
}
