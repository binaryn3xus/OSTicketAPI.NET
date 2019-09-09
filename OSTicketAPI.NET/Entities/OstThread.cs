using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public class OstThread
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string Extra { get; set; }
        public DateTime? Lastresponse { get; set; }
        public DateTime? Lastmessage { get; set; }
        public DateTime Created { get; set; }

        [InverseProperty("OstThread")]
        public virtual ICollection<OstThreadEntry> OstThreadEntries { get; set; }

        [InverseProperty("OstThread")]
        public virtual ICollection<OstThreadEvent> OstThreadEvents { get; set; }

        [ForeignKey("ObjectId")]
        public virtual OstTicket OstTicket { get; set; }
    }
}
