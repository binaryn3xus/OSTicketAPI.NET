using System.Collections.Generic;
using System.Linq;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.DTO
{
    public class TicketThread
    {
        public OstThread Thread { get; }
        public List<OstThreadEntry> Entries { get; }
        public List<OstThreadEvent> Events { get; }

        public TicketThread(OSTicketContext context, int ticketId)
        {
            Thread = context.OstThread.FirstOrDefault(o => o.ObjectType == "T" && o.ObjectId == ticketId);
            Entries = context.OstThreadEntry.Where(o => o.ThreadId == Thread.Id).OrderBy(o => o.Created).ToList();
            Events = context.OstThreadEvent.Where(o => o.ThreadId == Thread.Id).OrderBy(o => o.Timestamp).ToList();
        }
    }
}
