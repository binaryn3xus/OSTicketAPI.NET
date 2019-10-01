using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstApiKey
    {
        public int Id { get; set; }
        public sbyte Isactive { get; set; }
        public string Ipaddr { get; set; }
        public string Apikey { get; set; }
        public bool CanCreateTickets { get; set; }
        public bool CanExecCron { get; set; }
        public string Notes { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
