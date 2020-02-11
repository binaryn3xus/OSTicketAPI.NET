using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(Name) + ",nq}")]
    public class Department
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public int TplId { get; set; }
        public int SlaId { get; set; }
        public int EmailId { get; set; }
        public int AutoRespEmailId { get; set; }
        public int ManagerId { get; set; }
        public int Flags { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public bool IsPublic { get; set; }
        public sbyte GroupMembership { get; set; }
        public sbyte TicketAutoResponse { get; set; }
        public sbyte MessageAutoResponse { get; set; }
        public string Path { get; set; }
        public Staff Manager { get; set; }
        public IEnumerable<Staff> StaffMembers { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
