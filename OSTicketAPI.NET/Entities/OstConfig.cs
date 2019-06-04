using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstConfig
    {
        public int Id { get; set; }
        public string Namespace { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Updated { get; set; }
    }
}
