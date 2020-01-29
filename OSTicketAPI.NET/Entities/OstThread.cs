using System;
using System.Collections.Generic;

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

        public virtual ICollection<OstThreadEntry> OstThreadEntries { get; set; }

        public virtual ICollection<OstThreadEvent> OstThreadEvents { get; set; }

        public virtual OstTicket OstTicket { get; set; }
    }
}
