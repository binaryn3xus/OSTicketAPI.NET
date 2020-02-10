using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface ITicketRepository<T, TDbObject, TStatus>
    {
        Task<IEnumerable<T>> GetTickets(Expression<Func<TDbObject, bool>> expression = null);
        Task<IEnumerable<TStatus>> GetTicketStatuses();
        Task<T> GetTicketByTicketId(int ticketId);
        Task<T> GetTicketByTicketNumber(string ticketNumber);
        Task<IEnumerable<T>> GetTicketsByUserId(int userId);
        Task<T> UpdateTicketByIdAsync(int ticketNumber, T ticket);
        Task<T> UpdateTicketByIdAsync(int ticketNumber, TDbObject ticket);
        Task<T> UpdateTicketByNumberAsync(string ticketNumber, T ticket);
        Task<T> UpdateTicketByNumberAsync(string ticketNumber, TDbObject ticket);
    }
}
