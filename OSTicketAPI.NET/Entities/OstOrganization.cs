using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstOrganization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public int Status { get; set; }
        public string Domain { get; set; }
        public string Extra { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
