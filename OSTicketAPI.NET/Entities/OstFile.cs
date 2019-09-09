using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstFile
    {
        public int Id { get; set; }
        public string Ft { get; set; }
        public string Bk { get; set; }
        public string Type { get; set; }
        public ulong Size { get; set; }
        public string Key { get; set; }
        public string Signature { get; set; }
        public string Name { get; set; }
        public string Attrs { get; set; }
        public DateTime Created { get; set; }
    }
}
