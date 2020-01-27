using System.Diagnostics;

namespace OSTicketAPI.NET.Entities
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class OstFormEntryValue
    {
        public int EntryId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
        public int? ValueId { get; set; }
        public virtual OstFormEntry OstFormEntry { get; set; }
        public virtual OstFormField OstFormField { get; set; }
    }
}
