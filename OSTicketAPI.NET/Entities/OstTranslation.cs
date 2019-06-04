using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstTranslation
    {
        public int Id { get; set; }
        public string ObjectHash { get; set; }
        public string Type { get; set; }
        public int Flags { get; set; }
        public int? Revision { get; set; }
        public int AgentId { get; set; }
        public string Lang { get; set; }
        public string Text { get; set; }
        public string SourceText { get; set; }
        public DateTime? Updated { get; set; }
    }
}
