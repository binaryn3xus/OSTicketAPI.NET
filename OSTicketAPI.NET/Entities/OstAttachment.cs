namespace OSTicketAPI.NET.Entities
{
    public partial class OstAttachment
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string Type { get; set; }
        public int FileId { get; set; }
        public string Name { get; set; }
        public byte Inline { get; set; }
        public string Lang { get; set; }
    }
}
