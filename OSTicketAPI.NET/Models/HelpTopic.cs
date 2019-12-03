using System.Collections.Generic;

namespace OSTicketAPI.NET.Models
{
    public class HelpTopic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<FormField> FormFields { get; set; }
    }
}
