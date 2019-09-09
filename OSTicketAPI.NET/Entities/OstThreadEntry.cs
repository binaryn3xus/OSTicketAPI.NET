using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public class OstThreadEntry
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public int ThreadId { get; set; }
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public int Flags { get; set; }
        public string Poster { get; set; }
        public int? Editor { get; set; }
        public string EditorType { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public string IpAddress { get; set; }
        public string Recipients { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        
        [ForeignKey("ThreadId")]
        public virtual OstThread OstThread { get; set; }
    }
}
