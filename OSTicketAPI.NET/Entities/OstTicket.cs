using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Number) + ",nq}")]
    public class OstTicket
    {
        public int TicketId { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
        public int UserEmailId { get; set; }
        public int StatusId { get; set; }
        public int DeptId { get; set; }
        public int? SlaId { get; set; }
        public int? TopicId { get; set; }
        public int? StaffId { get; set; }
        public int? TeamId { get; set; }
        public int EmailId { get; set; }
        public int LockId { get; set; }
        public int Flags { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string SourceExtra { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? EstDueDate { get; set; }
        public DateTime? Reopened { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual OstSla OstSla { get; set; }
        public virtual OstStaff OstStaff { get; set; }
        public virtual OstUser OstUser { get; set; }
        public virtual OstHelpTopic OstHelpTopic { get; set; }
        public virtual OstTicketStatus OstTicketStatus { get; set; }
        public virtual OstDepartment OstDepartment { get; set; }
        public virtual OstTeam OstTeam { get; set; }
        public virtual OstThread OstThread { get; set; }
        public virtual ICollection<OstFormEntry> OstFormEntry { get; set; }
    }
}
