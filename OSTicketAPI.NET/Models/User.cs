using System;

namespace OSTicketAPI.NET.Models
{
    public class User
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int AccountStatus { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Timezone { get; set; }
        public DateTime? Registered { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
