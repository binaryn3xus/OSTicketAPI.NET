using System.Collections.Generic;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<OstTicketStatus>> GetTicketStatuses();
        Task<OstTicket> GetTicketByTicketId(int ticketId);
        Task<OstTicket> GetTicketByTicketNumber(string ticketNumber);
        Task<IEnumerable<OstTicket>> GetTicketsByUserId(int userId);
        Task<IEnumerable<OstTicket>> GetTicketsByOstUser(OstUser user);
    }
}
