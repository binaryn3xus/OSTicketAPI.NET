using System;
using System.Runtime.Serialization;

namespace OSTicketAPI.NET.Exceptions
{
    [Serializable]
    public class UserCreationException : Exception
    {
        private const string DefaultMessage = "Exception while creating user";

        public readonly string Username;
        public readonly string Email;

        public UserCreationException() : base(DefaultMessage) {}

        public UserCreationException(string message) : base(message) { }

        public UserCreationException(string message, Exception innerException)
            : base(message, innerException) { }

        public UserCreationException(string username, string email)
            : base(DefaultMessage)
        {
            Username = username;
            Email = email;
        }

        public UserCreationException(string username, string email, Exception innerException)
            : base(DefaultMessage, innerException)
        {
            Username = username;
            Email = email;
        }

        protected UserCreationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}
