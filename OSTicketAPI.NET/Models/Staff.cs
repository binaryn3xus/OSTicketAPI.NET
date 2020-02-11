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
        public string Password { get; set; }
        public string Backend { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Mobile { get; set; }
        public string Signature { get; set; }
        public string Lang { get; set; }
        public string TimeZone { get; set; }
        public string Locale { get; set; }
        public string Notes { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte IsAdmin { get; set; }
        public bool IsVisible { get; set; }
        public bool OnVacation { get; set; }
        public bool AssignedOnly { get; set; }
        public bool ShowAssignedTickets { get; set; }
        public bool ChangePassword { get; set; }
        public int MaxPageSize { get; set; }
        public int AutoRefreshRate { get; set; }
        public string DefaultSignatureType { get; set; }
        public string DefaultPaperSize { get; set; }
        public IEnumerable<Department> DepartmentManagerOf { get; set; }
        public Dictionary<string, object> Extra { get; set; }
        public Dictionary<string, int> Permissions { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Updated { get; set; }
    }
}
