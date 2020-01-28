using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(TopicName) + "}")]
    public class HelpTopic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public bool IsPublic { get; set; }
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
        public string NumberFormat { get; set; }
        public string Notes { get; set; }
        public IEnumerable<FormField> FormFields { get; set; }
    }
}
