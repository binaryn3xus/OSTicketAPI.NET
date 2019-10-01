using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstLock
    {
        public int LockId { get; set; }
        public int StaffId { get; set; }
        public DateTime? Expire { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
    }
}
