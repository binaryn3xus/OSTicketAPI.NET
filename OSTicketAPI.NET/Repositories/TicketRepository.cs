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
    public class TicketRepository : ITicketRepository<Ticket, OstTicket, TicketStatus>
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
        public async Task<IEnumerable<Ticket>> GetTickets(Expression<Func<OstTicket, bool>> expression = null)
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
        public async Task<Ticket> GetTicketByTicketId(int ticketId)
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
        public async Task<Ticket> GetTicketByTicketNumber(string ticketNumber)
        {
            var data = await GetQueryableTicketsAsync(o => o.Number == ticketNumber).ConfigureAwait(false);
            var ticket = data.FirstOrDefault(o => o.Number == ticketNumber);
            if (ticket != null)
                _logger.Debug("Found {TicketId}", ticket.TicketId);
            return ticket;
        }

        public Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            if (userId == default)
                throw new ArgumentNullException($"\"{userId}\" is not a valid user id");

            return GetTicketsByUserIdInternal(userId);
        }

        private async Task<IEnumerable<Ticket>> GetTicketsByUserIdInternal(int userId)
        {
            var data = await GetQueryableTicketsAsync(o => o.UserId.Equals(userId)).ConfigureAwait(false);
            var ticketList = data.ToList();
            _logger.Debug("Found {TicketCount} tickets for User ID {userId}", ticketList.Count, userId);
            return ticketList;
        }

        /// <summary>
        /// Update a ticket by Id
        /// </summary>
        /// <param name="ticketNumber">Number of the ticket to update</param>
        /// <param name="ticket">Ticket object to update</param>
        /// <returns>The ticket object will be returned</returns>
        public async Task<Ticket> UpdateTicketById(int ticketNumber, OstTicket ticket)
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
        public async Task<Ticket> UpdateTicketByNumber(string ticketNumber, OstTicket ticket)
        {
            var dbTicket = await _osticketContext.OstTicket.FirstOrDefaultAsync(o => o.Number == ticketNumber).ConfigureAwait(false);
            _osticketContext.Entry(dbTicket).CurrentValues.SetValues(ticket);
            await _osticketContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
        }

        private async Task<IEnumerable<Ticket>> GetQueryableTicketsAsync(Expression<Func<OstTicket, bool>> expression)
        {
            var ticketQuery = _osticketContext.OstTicket
                .Include(o => o.OstUser)
                .Include(o => o.OstTicketStatus)
                .Include(o => o.OstDepartment)
                .Include(o => o.OstSla)
                .Include(o => o.OstStaff)
                .Include(o => o.OstTeam)
                .Include(o => o.OstHelpTopic)
                .ThenInclude(o => o.HelpTopicForms)
                .ThenInclude(o => o.OstForm)
                .ThenInclude(o => o.OstFormFields)
                .AsQueryable();

            if (expression != null)
                ticketQuery = ticketQuery.Where(expression);

            var tickets = ticketQuery.ToList();
            var ticketsIds = tickets.Select(e => e.TicketId);
            var ticketAll = _osticketContext.OstTicket.Select(e => e.TicketId);

            var result = ticketAll.Where(p => ticketsIds.All(p2 => p2 != p));
            if (result.Any())
            {
                int fff = 2 + 3;
            }

            var mappedTickets = _mapper.Map<List<Ticket>>(tickets);

            return mappedTickets.AsQueryable();
        }
    }
}
