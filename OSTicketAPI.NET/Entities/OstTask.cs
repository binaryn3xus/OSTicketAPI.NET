using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstTask
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string Number { get; set; }
        public int DeptId { get; set; }
        public int StaffId { get; set; }
        public int TeamId { get; set; }
        public int LockId { get; set; }
        public int Flags { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
