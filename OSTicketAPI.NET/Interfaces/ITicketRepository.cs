using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.Interfaces
{
    public interface ITicketRepository<T>
    {
        Task<IEnumerable<T>> GetTickets(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<TicketStatus>> GetTicketStatuses();
        Task<T> GetTicketByTicketId(int ticketId);
        Task<T> GetTicketByTicketNumber(string ticketNumber);
        Task<IEnumerable<T>> GetTicketsByUserId(int userId);
        Task<IEnumerable<T>> GetTicketsByOstUser(OstUser user);
        Task<T> UpdateTicketById(int ticketNumber, T ticket);
        Task<T> UpdateTicketByNumber(string ticketNumber, T ticket);
    }
}
