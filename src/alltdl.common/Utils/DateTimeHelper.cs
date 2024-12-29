using System;
using System.Collections.Generic;

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

        public static bool IsFederalHoliday(this DateTime date)
        {
            int nthWeekDay = (int)(Math.Ceiling((double)date.Day / 7.0d));
            DayOfWeek dayName = date.DayOfWeek;
            bool isMonday = dayName == DayOfWeek.Monday;
            bool isWeekend = dayName == DayOfWeek.Saturday || dayName == DayOfWeek.Sunday;

            // New Year's Day (Jan 1, or preceding Friday/following Monday if weekend)
            if ((date.Month == 12 && date.Day == 31 && dayName == DayOfWeek.Friday) ||
                (date.Month == 1 && date.Day == 1 && !isWeekend) ||
                (date.Month == 1 && date.Day == 2 && isMonday))
                return true;

            // Martin Luther King Jr. Day (3rd Monday in January)
            if (date.Month == 1 && isMonday && nthWeekDay == 3)
                return true;

            // President's Day (3rd Monday in February)
            if (date.Month == 2 && isMonday && nthWeekDay == 3)
                return true;

            // Memorial Day (Last Monday in May)
            if (date.Month == 5 && isMonday && date.AddDays(7).Month == 6)
                return true;

            // Independence Day (July 4, or preceding Friday/following Monday if weekend)
            if ((date.Month == 7 && date.Day == 3 && dayName == DayOfWeek.Friday) ||
                (date.Month == 7 && date.Day == 4 && !isWeekend) ||
                (date.Month == 7 && date.Day == 5 && isMonday))
                return true;

            // Labor Day (1st Monday in September)
            if (date.Month == 9 && isMonday && nthWeekDay == 1)
                return true;

            // Columbus Day (2nd Monday in October)
            if (date.Month == 10 && isMonday && nthWeekDay == 2)
                return true;

            // Veterans Day (Nov 11, or preceding Friday/following Monday if weekend)
            if ((date.Month == 11 && date.Day == 10 && dayName == DayOfWeek.Friday) ||
                (date.Month == 11 && date.Day == 11 && !isWeekend) ||
                (date.Month == 11 && date.Day == 12 && isMonday))
                return true;

            // Thanksgiving Day (4th Thursday in November)
            if (date.Month == 11 && dayName == DayOfWeek.Thursday && nthWeekDay == 4)
                return true;

            // Christmas Day (Dec 25, or preceding Friday/following Monday if weekend)
            if ((date.Month == 12 && date.Day == 24 && dayName == DayOfWeek.Friday) ||
                (date.Month == 12 && date.Day == 25 && !isWeekend) ||
                (date.Month == 12 && date.Day == 26 && isMonday))
                return true;

            return false;
        }

        public static long ConvertDateTimeToUnixTimeStamp(this DateTime dateTime)
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }

        public static DateTime ConvertUnixTimeSecondsToDateTime(this long unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).DateTime;
        }
    }
}