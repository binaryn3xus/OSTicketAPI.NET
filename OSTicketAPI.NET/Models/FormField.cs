using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Models
{
    [DebuggerDisplay("{" + nameof(SystemName) + ",nq}")]
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int? Flags { get; set; }  
        public string Type { get; set; }
        public string Configuration { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public int Sort { get; set; }
        public string Hint { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
