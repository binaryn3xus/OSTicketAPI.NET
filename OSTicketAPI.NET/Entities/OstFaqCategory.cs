using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFaqCategory
    {
        public int CategoryId { get; set; }
        public int? CategoryPid { get; set; }
        public byte Ispublic { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
