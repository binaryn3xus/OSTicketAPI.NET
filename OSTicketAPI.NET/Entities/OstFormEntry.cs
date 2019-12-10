using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("Id:{" + nameof(Id) + ",nq} - ObjectId:{" + nameof(ObjectId) + ",nq} ({" + nameof(ObjectType) + ",nq})")]
    public class OstFormEntry
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int? ObjectId { get; set; }
        public string ObjectType { get; set; }
        public int Sort { get; set; }
        public string Extra { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<OstFormEntryValues> OstFormEntryValues { get; set; }

        public virtual OstForm OstForm { get; set; }

    }
}
