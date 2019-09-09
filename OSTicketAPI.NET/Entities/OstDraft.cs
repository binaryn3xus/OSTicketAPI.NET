using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstDraft
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Namespace { get; set; }
        public string Body { get; set; }
        public string Extra { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
