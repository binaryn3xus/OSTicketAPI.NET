using System;
using System.Text;
using Newtonsoft.Json.Linq;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Helpers
{
    public static class OSTicketJsonDecoder
    {
        public static string ToFriendlyString(this OstThreadEvent threadEvent)
        {
            if (string.IsNullOrWhiteSpace(threadEvent?.Data))
                return null;

            var stringBuilder = new StringBuilder();
            var somebody = threadEvent.Username;
            var timestamp = threadEvent.Timestamp;

            var data = JObject.Parse(threadEvent.Data);
            var dataFirsts = data.Children();

            if (!data.HasValues)
                return "Unknown";

            foreach (var child in dataFirsts)
            {
                switch (child.Path)
                {
                    case "status":
                        var status = data["status"];
                        stringBuilder.Append(threadEvent.Username).Append(" changed the status to ").Append(status)
                            .AppendLine();
                        break;
                    case "source":
                        var sourceFrom = data["source"][0];
                        var sourceTo = data["source"][1];
                        stringBuilder.Append("Ticket source changed from ").Append(sourceFrom).Append(" to ")
                            .AppendLine(sourceTo.ToString());
                        break;
                    case "claim":
                        stringBuilder.Append(somebody).Append(" claimed this ").Append(timestamp);
                        break;
                    case "add":
                        var addName = data.SelectToken("$.add.*.name");
                        stringBuilder.Append("Added \"").Append(addName).AppendLine("\" as a ticket coordinator");
                        break;
                    case "del":
                        var delName = data.SelectToken("$.del.*.name");
                        stringBuilder.Append(somebody).Append(" removed ").Append(delName)
                            .Append(" from the collaborators ").Append(timestamp).AppendLine();
                        break;
                    case "topic_id":
                        stringBuilder.Append(somebody).AppendLine(" changed the topic of the ticket");
                        break;
                    case "staff":
                        var staff = data["staff"];
                        stringBuilder.Append(somebody).Append(" assigned this to ").Append(staff[1]).AppendLine();
                        break;
                    case "duedate":
                        stringBuilder.Append("Due Date changed");

                        if (DateTime.TryParse(data["duedate"][0]?.ToString(), out var dueDateFrom))
                            stringBuilder.Append(" from ").Append(dueDateFrom.ToShortDateString());

                        if (DateTime.TryParse(data["duedate"][1]?.ToString(), out var dueDateTo))
                            stringBuilder.Append(" to ").Append(dueDateTo.ToShortDateString());

                        stringBuilder.AppendLine(" ");
                        break;
                    case "dept":
                        stringBuilder.Append(somebody).Append(" transferred this to a new department ").Append(timestamp);
                        break;
                    case "fields":
                        stringBuilder.Append(somebody).Append(" updated some of the fields on the ticket ").Append(timestamp);
                        break;
                    default:
                        stringBuilder.AppendLine("Unknown");
                        break;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
