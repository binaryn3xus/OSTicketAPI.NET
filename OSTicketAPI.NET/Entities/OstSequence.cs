using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstSequence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Flags { get; set; }
        public ulong Next { get; set; }
        public int? Increment { get; set; }
        public string Padding { get; set; }
        public DateTime Updated { get; set; }
    }
}
