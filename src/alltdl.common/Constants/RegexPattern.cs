namespace alltdl.Constants
{
    public static class RegexPattern
    {
        public const string Ip4 = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";

        public const string Ip4Notation = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}/\b([8-9]|[12][0-9]|3[0-2])\b";
    }
}