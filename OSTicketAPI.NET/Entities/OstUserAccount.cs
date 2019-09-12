using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{Username,nq}")]
    public class OstUserAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string Timezone { get; set; }
        public string Lang { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public string Backend { get; set; }
        public string Extra { get; set; }
        public DateTime? Registered { get; set; }

        [ForeignKey("UserId")]
        public virtual OstUser OstUser { get; set; }

        [ForeignKey("UserId")]
        public virtual OstUserEmail OstUserEmail { get; set; }
    }
}
