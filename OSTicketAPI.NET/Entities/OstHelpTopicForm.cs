namespace OSTicketAPI.NET.Entities
{
    public partial class OstHelpTopicForm
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int FormId { get; set; }
        public int Sort { get; set; }
        public string Extra { get; set; }
    }
}
