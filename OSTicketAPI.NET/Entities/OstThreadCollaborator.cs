using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstThreadCollaborator
    {
        public int Id { get; set; }
        public int Flags { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
