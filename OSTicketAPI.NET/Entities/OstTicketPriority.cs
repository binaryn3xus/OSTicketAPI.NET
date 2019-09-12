namespace OSTicketAPI.NET.Entities
{
    public class OstTicketPriority
    {
        public sbyte PriorityId { get; set; }
        public string Priority { get; set; }
        public string PriorityDesc { get; set; }
        public string PriorityColor { get; set; }
        public bool PriorityUrgency { get; set; }
        public sbyte Ispublic { get; set; }
    }
}
