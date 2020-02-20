namespace OSTicketAPI.NET.Entities
{
    public class OstTicketCdata
    {
        public int TicketId { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }

        public virtual OstTicket OstTicket { get; set; }
    }
}
