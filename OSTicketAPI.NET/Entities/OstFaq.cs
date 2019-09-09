using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFaq
    {
        public int FaqId { get; set; }
        public int CategoryId { get; set; }
        public byte Ispublished { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Keywords { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
