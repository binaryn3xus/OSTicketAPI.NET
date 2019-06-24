using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Helpers
{
    public static class OstThreadEntryExtensions
    {
        public static string ToFriendlyString(this OstThreadEvent threadEvent)
        {
            var data = JObject.Parse(threadEvent.Data);

            if (!data.HasValues)
                return "Unknown";

            switch (data.First.Path)
            {
                case "status":
                    var status = data["status"][1];
                    return $"Status changed to \"{status}\"";
                case "source":
                    var source = data["source"][1];
                    return $"Ticket source changed to \"{source}\"";
                case "claim":
                    return $"Ticket has been claimed by {threadEvent.Username}";
                case "add":
                    var add = data["add"].First.First.Children().ToList();
                    var add1 = add[0].Children().ToList().First();
                    return $"Added \"{add1}\" as a ticket coordinator";
                case "del":
                    var del = data["del"].First.First.Children().ToList();
                    var del1 = del[0].Children().ToList().First();
                    return $"Removed \"{del1}\" as a ticket coordinator";
                case "topic_id":
                    return $" {threadEvent.Username} changed the topic of the ticket";
                default:
                    return "Unknown";
            }
        }
    }
}
