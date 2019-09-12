using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Label) + "}")]
    public class OstFormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int? Flags { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Configuration { get; set; }
        public int Sort { get; set; }
        public string Hint { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [ForeignKey("FormId")]
        public virtual OstForm OstForm { get; set; }
    }
}
