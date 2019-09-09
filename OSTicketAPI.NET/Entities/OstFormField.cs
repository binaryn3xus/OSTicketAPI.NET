using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int? Flags { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Configuration { get; set; }
        public int Sort { get; set; }
        public string Hint { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
