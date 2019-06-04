using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstFilter
    {
        public int Id { get; set; }
        public int Execorder { get; set; }
        public byte Isactive { get; set; }
        public int? Flags { get; set; }
        public int Status { get; set; }
        public byte MatchAllRules { get; set; }
        public byte StopOnmatch { get; set; }
        public string Target { get; set; }
        public int EmailId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
