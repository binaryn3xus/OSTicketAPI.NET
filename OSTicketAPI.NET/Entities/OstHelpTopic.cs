using System;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstHelpTopic
    {
        public int TopicId { get; set; }
        public int TopicPid { get; set; }
        public byte Ispublic { get; set; }
        public byte Noautoresp { get; set; }
        public int? Flags { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int DeptId { get; set; }
        public int StaffId { get; set; }
        public int TeamId { get; set; }
        public int SlaId { get; set; }
        public int PageId { get; set; }
        public int SequenceId { get; set; }
        public int Sort { get; set; }
        public string Topic { get; set; }
        public string NumberFormat { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
