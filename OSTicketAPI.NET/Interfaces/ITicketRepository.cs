using System.Collections.Generic;
using System.Threading.Tasks;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<OstTicketStatus>> GetTicketStatuses();
        Task<OstTicket> GetTicketByTicketId(int ticketId);
        Task<TicketThread> GetTicketThreadByTicketId(int ticketId);
        Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId);
        Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user);
    }
}
