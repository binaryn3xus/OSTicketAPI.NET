using System.Net.Http;
using System.Threading.Tasks;
using OSTicketAPI.NET.DTO;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IOSTicketOfficialApi
    {
        Task<HttpResponseMessage> CreateTicket(TicketCreationOptions options);
    }
}
