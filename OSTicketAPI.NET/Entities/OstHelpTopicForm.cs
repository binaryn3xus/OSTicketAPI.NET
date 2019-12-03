using System.Collections.Generic;

namespace OSTicketAPI.NET.Entities
{
    public class OstHelpTopicForm
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int FormId { get; set; }
        public int Sort { get; set; }
        public string Extra { get; set; }

        public virtual OstHelpTopic OstHelpTopic { get; set; }
        public virtual ICollection<OstForm> OstForms { get; set; }
    }
}
