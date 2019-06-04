using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstSla
    {
        public int Id { get; set; }
        public int Flags { get; set; }
        public int GracePeriod { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
