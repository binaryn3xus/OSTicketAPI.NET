using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class TicketStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Mode { get; set; }
        public int Flags { get; set; }
        public int Sort { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
