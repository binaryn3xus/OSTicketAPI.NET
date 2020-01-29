using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Address) + ",nq}")]
    public class OstUserEmail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Flags { get; set; }
        public string Address { get; set; }

        public virtual OstUser OstUser { get; set; }
    }
}
