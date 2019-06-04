namespace OSTicketAPI.NET.Entities
{
    public partial class OstQueueExport
    {
        public int Id { get; set; }
        public int QueueId { get; set; }
        public string Path { get; set; }
        public string Heading { get; set; }
        public int Sort { get; set; }
    }
}
