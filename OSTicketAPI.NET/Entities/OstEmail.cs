using System;

namespace OSTicketAPI.NET.Entities
{
    public class OstEmail
    {
        public int EmailId { get; set; }
        public byte Noautoresp { get; set; }
        public byte PriorityId { get; set; }
        public byte DeptId { get; set; }
        public int TopicId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Userid { get; set; }
        public string Userpass { get; set; }
        public sbyte MailActive { get; set; }
        public string MailHost { get; set; }
        public string MailProtocol { get; set; }
        public string MailEncryption { get; set; }
        public int? MailPort { get; set; }
        public sbyte MailFetchfreq { get; set; }
        public sbyte MailFetchmax { get; set; }
        public string MailArchivefolder { get; set; }
        public sbyte MailDelete { get; set; }
        public sbyte MailErrors { get; set; }
        public DateTime? MailLasterror { get; set; }
        public DateTime? MailLastfetch { get; set; }
        public sbyte? SmtpActive { get; set; }
        public string SmtpHost { get; set; }
        public int? SmtpPort { get; set; }
        public sbyte SmtpSecure { get; set; }
        public sbyte SmtpAuth { get; set; }
        public byte SmtpSpoofing { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
