using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstEmailTemplate
    {
        public int Id { get; set; }
        public int TplId { get; set; }
        public string CodeName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
