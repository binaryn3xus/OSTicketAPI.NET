namespace OSTicketAPI.NET.Entities
{
    public partial class OstFormEntryValues
    {
        public int EntryId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
        public int? ValueId { get; set; }
    }
}
