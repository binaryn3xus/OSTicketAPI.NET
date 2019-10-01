using System;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Name) + ",nq}")]
    public class OstSla
    {
        public int Id { get; set; }
        public int Flags { get; set; }
        public int GracePeriod { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
