using System;

namespace alltdl.Utils
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// The second.
        /// </summary>
        private const int Second = 1;

        /// <summary>
        /// The minute.
        /// </summary>
        private const int Minute = 60 * Second;

        /// <summary>
        /// The hour.
        /// </summary>
        private const int Hour = 60 * Minute;

        /// <summary>
        /// The day.
        /// </summary>
        private const int Day = 24 * Hour;

        /// <summary>
        /// The month.
        /// </summary>
        private const int Week = 30 * Day;

        /// <summary>
        /// A SQL compatible Min DateTime
        /// </summary>
        /// <returns>
        /// A SQL compatible Min DateTime '01/01/1903 00:00:00'
        /// </returns>
        public static DateTime SqlDbMinTime()
        {
            return DateTime.MinValue.AddYears(1902);
        }

        /// <summary>
        /// The date diff day.
        /// </summary>
        /// <param name="startDate">
        /// The start date.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int DateDiffDay(DateTime startDate, DateTime endDate) => (endDate.Date - startDate.Date).Days;

        /// <summary>
        /// Add business days
        /// </summary>
        /// <param name="current"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }
    }
}