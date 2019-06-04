using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstUser
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public int DefaultEmailId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public ICollection<OstTicket> Tickets { get; set; }

        [ForeignKey("OrgId")]
        public virtual OstOrganization OstOrganization { get; set; }
        [InverseProperty("OstUser")]
        public virtual OstUserEmail OstUserEmail { get; set; }
        [InverseProperty("OstUser")]
        public virtual OstUserAccount OstUserAccount { get; set; }
    }
}
