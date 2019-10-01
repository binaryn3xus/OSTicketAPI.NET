using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstGroup
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int Flags { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
