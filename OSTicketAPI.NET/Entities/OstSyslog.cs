using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstSyslog
    {
        public int LogId { get; set; }
        public string LogType { get; set; }
        public string Title { get; set; }
        public string Log { get; set; }
        public string Logger { get; set; }
        public string IpAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
