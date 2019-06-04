namespace OSTicketAPI.NET.Entities
{
    public partial class OstQueueColumn
    {
        public int Id { get; set; }
        public int Flags { get; set; }
        public string Name { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string Filter { get; set; }
        public string Truncate { get; set; }
        public string Annotations { get; set; }
        public string Conditions { get; set; }
        public string Extra { get; set; }
    }
}
