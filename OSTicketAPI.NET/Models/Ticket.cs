using System;
using System.Diagnostics;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(Number) + ",nq}")]
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Number { get; set; }
        public User User { get; set; }
        public TicketStatus Status { get; set; }
        public Department Department { get; set; }
        public HelpTopic HelpTopic { get; set; }
        public Staff Staff { get; set; }
        public int SlaId { get; set; }
        public int TeamId { get; set; }
        public int LockId { get; set; }
        public int Flags { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string SourceExtra { get; set; }
        public bool Isoverdue { get; set; }
        public bool Isanswered { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? EstDuedate { get; set; }
        public DateTime? Reopened { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? Lastupdate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
