using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstEmailTemplateGroup
    {
        public int TplId { get; set; }
        public bool Isactive { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
