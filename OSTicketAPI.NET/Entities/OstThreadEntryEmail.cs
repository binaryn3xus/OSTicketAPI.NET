namespace OSTicketAPI.NET.Entities
{
    public partial class OstThreadEntryEmail
    {
        public int Id { get; set; }
        public int ThreadEntryId { get; set; }
        public string Mid { get; set; }
        public string Headers { get; set; }
    }
}
