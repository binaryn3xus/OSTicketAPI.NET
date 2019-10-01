using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public class OstThreadEvent
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int? EventId { get; set; }
        public int StaffId { get; set; }
        public int TeamId { get; set; }
        public int DeptId { get; set; }
        public int TopicId { get; set; }
        public string Data { get; set; }
        public string Username { get; set; }
        public int? Uid { get; set; }
        public string UidType { get; set; }
        public bool Annulled { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("ThreadId")]
        public virtual OstThread OstThread { get; set; }
    }
}
