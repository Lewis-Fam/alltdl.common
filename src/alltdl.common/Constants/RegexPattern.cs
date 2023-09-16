namespace alltdl.Constants
{
    /// <summary>
    /// Common Regex Patterns
    /// </summary>
    public static class RegexPattern
    {
        /// <summary>
        /// The regex pattern for ip4 matching.
        /// </summary>
        public const string Ip4 = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";

        /// <summary>
        /// The regex pattern for ip4 notation matching.
        /// </summary>
        public const string Ip4Notation = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}/\b([8-9]|[12][0-9]|3[0-2])\b";

        /// <summary>
        /// The regex pattern for URL matching.
        /// </summary>
        public const string Url = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
    }
}