using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFormEntry
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int? ObjectId { get; set; }
        public string ObjectType { get; set; }
        public int Sort { get; set; }
        public string Extra { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
