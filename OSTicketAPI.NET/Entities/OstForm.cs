using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Title) + "}")]
    public class OstForm
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Type { get; set; }
        public int Flags { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [InverseProperty("OstForm")]
        public virtual ICollection<OstFormField> OstFormFields { get; set; }
    }
}
