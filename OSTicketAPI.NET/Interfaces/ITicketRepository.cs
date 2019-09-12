using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface ITicketRepository<T>
    {
        Task<IEnumerable<T>> GetTickets(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<OstTicketStatus>> GetTicketStatuses(Expression<Func<OstTicketStatus, bool>> expression = null);
        Task<T> GetTicketByTicketId(int ticketId);
        Task<T> GetTicketByTicketNumber(string ticketNumber);
        Task<IEnumerable<T>> GetTicketsByUserId(int userId);
        Task<IEnumerable<T>> GetTicketsByOstUser(OstUser user);
    }
}
