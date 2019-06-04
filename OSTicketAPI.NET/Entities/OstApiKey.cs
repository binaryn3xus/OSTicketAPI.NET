using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstApiKey
    {
        public int Id { get; set; }
        public sbyte Isactive { get; set; }
        public string Ipaddr { get; set; }
        public string Apikey { get; set; }
        public byte CanCreateTickets { get; set; }
        public byte CanExecCron { get; set; }
        public string Notes { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
