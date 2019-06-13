using System;

namespace OSTicketAPI.NET.DTO
{
    public class UserCreationOptions
    {
        public int OrgId { get; set; } = 1;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Timezone { get; set; } = "America/New_York";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Backend { get; set; }
        public string Extra { get; set; }
        public DateTime Registered { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
