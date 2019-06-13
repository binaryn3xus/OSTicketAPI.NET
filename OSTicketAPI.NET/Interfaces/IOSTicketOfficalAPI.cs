using System.Net;
using System.Threading.Tasks;
using OSTicketAPI.NET.DTO;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IOSTicketOfficalApi
    {
        Task<HttpStatusCode> CreateTicket(TicketCreationOptions options);
    }
}
