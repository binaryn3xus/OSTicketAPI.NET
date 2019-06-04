using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstFilterRule
    {
        public int Id { get; set; }
        public int FilterId { get; set; }
        public string What { get; set; }
        public string How { get; set; }
        public string Val { get; set; }
        public byte Isactive { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
