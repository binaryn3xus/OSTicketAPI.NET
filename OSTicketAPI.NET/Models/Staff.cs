using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(Username) + "}")]
    public class Staff
    {
        public int StaffId { get; set; }
        public int DeptId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Passwd { get; set; }
        public string Backend { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Mobile { get; set; }
        public string Signature { get; set; }
        public string Lang { get; set; }
        public string Timezone { get; set; }
        public string Locale { get; set; }
        public string Notes { get; set; }
        public sbyte Isactive { get; set; }
        public sbyte Isadmin { get; set; }
        public bool Isvisible { get; set; }
        public bool Onvacation { get; set; }
        public bool AssignedOnly { get; set; }
        public bool ShowAssignedTickets { get; set; }
        public bool ChangePasswd { get; set; }
        public int MaxPageSize { get; set; }
        public int AutoRefreshRate { get; set; }
        public string DefaultSignatureType { get; set; }
        public string DefaultPaperSize { get; set; }
        public IEnumerable<Department> DepartmentManagerOf { get; set; }
        public Dictionary<string, object> Extra { get; set; }
        public Dictionary<string, int> Permissions { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Lastlogin { get; set; }
        public DateTime? Passwdreset { get; set; }
        public DateTime Updated { get; set; }
    }
}
