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
        private const int Month = 30 * Day;

        /// <summary>
        /// A SQL compatible Min DateTime
        /// </summary>
        /// <returns>
        /// A SQL compatible Min DateTime
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
    }
}