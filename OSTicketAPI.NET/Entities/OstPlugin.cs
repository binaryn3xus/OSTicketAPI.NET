using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstPlugin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InstallPath { get; set; }
        public sbyte Isphar { get; set; }
        public sbyte Isactive { get; set; }
        public string Version { get; set; }
        public DateTime Installed { get; set; }
    }
}
