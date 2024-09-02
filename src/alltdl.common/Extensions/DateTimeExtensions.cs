using System;

namespace alltdl.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertUnixTimeStampToUtcDateTime(this long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
        }

        public static DateTime ConvertUnixTimeStampToLocalDateTime(this long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime;
        }

        public static DateTime UnixTimeStampToDateTime(this string text)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (string.IsNullOrEmpty(text))
                return dtDateTime;
            return dtDateTime.AddSeconds(Convert.ToInt32(text));
        }
    }
}