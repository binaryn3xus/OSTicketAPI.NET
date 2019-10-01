namespace OSTicketAPI.NET.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert a string to camel casing
        /// </summary>
        /// <param name="str">Extension to a string object</param>
        /// <returns>Returns a string that has been converted to camel casing</returns>
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
