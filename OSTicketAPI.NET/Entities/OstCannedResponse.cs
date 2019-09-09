using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstCannedResponse
    {
        public int CannedId { get; set; }
        public int DeptId { get; set; }
        public byte Isenabled { get; set; }
        public string Title { get; set; }
        public string Response { get; set; }
        public string Lang { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
