using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstEmailAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public string Protocol { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Options { get; set; }
        public int? Errors { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Lastconnect { get; set; }
        public DateTime? Lasterror { get; set; }
    }
}
