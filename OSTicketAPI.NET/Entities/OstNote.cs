using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstNote
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public int StaffId { get; set; }
        public string ExtId { get; set; }
        public string Body { get; set; }
        public int Status { get; set; }
        public int Sort { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
