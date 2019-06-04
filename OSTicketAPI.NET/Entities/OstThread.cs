using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstThread
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string Extra { get; set; }
        public DateTime? Lastresponse { get; set; }
        public DateTime? Lastmessage { get; set; }
        public DateTime Created { get; set; }
    }
}
