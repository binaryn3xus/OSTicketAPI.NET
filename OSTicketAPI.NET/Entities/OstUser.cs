using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Name) + ",nq}")]
    public class OstUser
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public int DefaultEmailId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public ICollection<OstTicket> OstTickets { get; set; }

        public virtual OstOrganization OstOrganization { get; set; }

        public virtual OstUserEmail OstUserEmail { get; set; }

        public virtual OstUserAccount OstUserAccount { get; set; }
    }
}
