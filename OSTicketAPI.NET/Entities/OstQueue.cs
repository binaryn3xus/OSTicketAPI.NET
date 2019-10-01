using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstQueue
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int? ColumnsId { get; set; }
        public int? SortId { get; set; }
        public int Flags { get; set; }
        public int StaffId { get; set; }
        public int Sort { get; set; }
        public string Title { get; set; }
        public string Config { get; set; }
        public string Filter { get; set; }
        public string Root { get; set; }
        public string Path { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
