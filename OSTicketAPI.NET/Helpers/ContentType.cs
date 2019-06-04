namespace OSTicketAPI.NET.Helpers
{
    public sealed class ContentType
    {
        private ContentType(string value) { Value = value; }

        public string Value { get; set; }

        public static ContentType Html => new ContentType("text/html");
        public static ContentType PlainText => new ContentType("text/plain");
    }
}
