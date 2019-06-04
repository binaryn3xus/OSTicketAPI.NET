using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstThreadReferral
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int ObjectId { get; set; }
        public string ObjectType { get; set; }
        public DateTime Created { get; set; }
    }
}
