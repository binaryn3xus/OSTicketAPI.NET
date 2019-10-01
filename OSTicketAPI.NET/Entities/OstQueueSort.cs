using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstQueueSort
    {
        public int Id { get; set; }
        public string Root { get; set; }
        public string Name { get; set; }
        public string Columns { get; set; }
        public DateTime? Updated { get; set; }
    }
}
