using System;
using System.Runtime.Serialization;

namespace OSTicketAPI.NET.Exceptions
{
    [Serializable]
    public class TicketUpdateException : Exception
    {
        private const string DefaultMessage = "Exception while updating ticket";

        public readonly int TicketId;

        public TicketUpdateException() : base(DefaultMessage) {}

        public TicketUpdateException(string message) : base(message) { }

        public TicketUpdateException(string message, Exception innerException)
            : base(message, innerException) { }

        public TicketUpdateException(int ticketId)
            : base(DefaultMessage)
        {
            TicketId = ticketId;
        }

        protected TicketUpdateException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}
