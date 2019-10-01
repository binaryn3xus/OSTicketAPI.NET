using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFilter
    {
        public int Id { get; set; }
        public int Execorder { get; set; }
        public bool Isactive { get; set; }
        public int? Flags { get; set; }
        public int Status { get; set; }
        public bool MatchAllRules { get; set; }
        public bool StopOnmatch { get; set; }
        public string Target { get; set; }
        public int EmailId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
