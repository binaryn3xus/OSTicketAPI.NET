using System.Collections.Generic;
using Newtonsoft.Json;
using OSTicketAPI.NET.Helpers;

namespace OSTicketAPI.NET.DTO
{
    [JsonConverter(typeof(TicketCreationOptionsConverter))]
    public class TicketCreationOptions
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public ContentType MessageContentType { get; set; } = ContentType.PlainText;
        public bool Alert { get; set; } = true;
        [JsonProperty(PropertyName = "autorespond")]
        public bool AutoRespond { get; set; } = false;
        [JsonProperty(PropertyName = "ip")]
        public string IpAddress { get; set; }
        public int Priority { get; set; }
        public string Source { get; set; }
        public int TopicId { get; set; }
        [JsonProperty()]
        public Dictionary<string, string> CustomProperties = new Dictionary<string, string>();

        //TODO Attachments not supported in this API yet

        public TicketCreationOptions(string email, string name, string subject, string message)
        {
            Email = email;
            Name = name;
            Subject = subject;
            Message = message;
        }
    }
}
