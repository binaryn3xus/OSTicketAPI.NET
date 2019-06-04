using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstQueueConfig
    {
        public int QueueId { get; set; }
        public int StaffId { get; set; }
        public string Setting { get; set; }
        public DateTime Updated { get; set; }
    }
}
