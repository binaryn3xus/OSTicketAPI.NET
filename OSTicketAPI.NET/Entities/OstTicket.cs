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
        public int UserId { get; set; } = 0;
        public int UserEmailId { get; set; } = 0;
        public int StatusId { get; set; } = 0;
        public int DeptId { get; set; } = 0;
        public int? SlaId { get; set; } = 0;
        public int? TopicId { get; set; } = 0;
        public int? StaffId { get; set; } = 0;
        public int? TeamId { get; set; } = 0;
        public int EmailId { get; set; } = 0;
        public int LockId { get; set; } = 0;
        public int Flags { get; set; } = 0;
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string SourceExtra { get; set; }
        public bool IsOverDue { get; set; } = false;
        public bool IsAnswered { get; set; } = false;
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
        public virtual OstTicketCdata OstTicketCdata { get; set; }
        public virtual ICollection<OstFormEntry> OstFormEntry { get; set; }
    }
}
