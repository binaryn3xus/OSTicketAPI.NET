using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstSession
    {
        public string SessionId { get; set; }
        public byte[] SessionData { get; set; }
        public DateTime? SessionExpire { get; set; }
        public DateTime? SessionUpdated { get; set; }
        public string UserId { get; set; }
        public string UserIp { get; set; }
        public string UserAgent { get; set; }
    }
}
