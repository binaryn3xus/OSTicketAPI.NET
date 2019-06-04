using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstFilterAction
    {
        public int Id { get; set; }
        public int FilterId { get; set; }
        public int Sort { get; set; }
        public string Type { get; set; }
        public string Configuration { get; set; }
        public DateTime Updated { get; set; }
    }
}
