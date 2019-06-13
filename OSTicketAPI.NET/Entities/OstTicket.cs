using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public partial class OstTicket
    {
        public int TicketId { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
        public int UserEmailId { get; set; }
        public int StatusId { get; set; }
        public int DeptId { get; set; }
        public int SlaId { get; set; }
        public int TopicId { get; set; }
        public int StaffId { get; set; }
        public int TeamId { get; set; }
        public int EmailId { get; set; }
        public int LockId { get; set; }
        public int Flags { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string SourceExtra { get; set; }
        public byte Isoverdue { get; set; }
        public byte Isanswered { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? EstDuedate { get; set; }
        public DateTime? Reopened { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? Lastupdate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [ForeignKey("UserId")]
        public OstUser OstUser { get; set; }

        [ForeignKey("StatusId")]
        public OstTicketStatus OstTicketStatus { get; set; }
        
        [ForeignKey("DeptId")]
        public OstDepartment OstDepartment { get; set; }

        [ForeignKey("SlaId")]
        public OstSla OstSla { get; set; }

        [ForeignKey("TopicId")]
        public OstHelpTopic OstHelpTopic { get; set; }
        
        [ForeignKey("StaffId")]
        public OstStaff OstStaff { get; set; }

        [ForeignKey("TeamId")]
        public OstTeam OstTeam { get; set; }

        [InverseProperty("OstTicket")]
        public OstThread OstThread { get; set; }
    }
}
