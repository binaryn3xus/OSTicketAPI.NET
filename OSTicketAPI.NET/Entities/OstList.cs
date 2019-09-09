using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public string SortMode { get; set; }
        public int Masks { get; set; }
        public string Type { get; set; }
        public string Configuration { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
