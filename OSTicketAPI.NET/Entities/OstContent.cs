using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstContent
    {
        public int Id { get; set; }
        public bool Isactive { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
