using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Repositories;

namespace OSTicketAPI.NET
{
    public class OSTicketInstance
    {
        public ITicketRepository Tickets { get; set; }
        public IUserRepository Users { get; set; }
        public IOSTicketOfficalApi OSTicketOfficalApi { get; }

        public OSTicketInstance(string databaseServer, string databaseUsername, string databasePassword, string databaseName, IOSTicketOfficalApi osTicketOfficalApi, int portNumber = 3306)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OSTicketContext>();
            optionsBuilder.UseMySQL($"server={databaseServer};uid={databaseUsername};pwd={databasePassword};database={databaseName};port={portNumber};Convert Zero Datetime=True;");
            var osticketContext = new OSTicketContext(new DbContextOptions<OSTicketContext>());

            OSTicketOfficalApi = osTicketOfficalApi;
            Tickets = new TicketRepository(osticketContext);
            Users = new UserRepository(osticketContext);
        }

        public OSTicketInstance(string connectionString, IOSTicketOfficalApi osTicketOfficalApi)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OSTicketContext>();
            optionsBuilder.UseMySQL(connectionString);
            var osticketContext = new OSTicketContext(optionsBuilder.Options);

            OSTicketOfficalApi = osTicketOfficalApi;
            Tickets = new TicketRepository(osticketContext);
            Users = new UserRepository(osticketContext);
        }
    }
}
