using System;
using System.Globalization;

namespace BerlinClock
{
    static public class HelperTimeSpan24HoursConverter
    {
         public static bool IsValidTime24HoursFormat(this string aTime)
        {
            if (aTime == "24:00:00") return true;
            return TimeSpan.TryParseExact(aTime, @"h\:mm\:ss", CultureInfo.InvariantCulture, out var dummyOutput);
        }

        public static TimeSpan24Hours GetTimeFields24HoursFormat(this string aTime)
        {
            int hours, minutes, seconds;

            if (aTime == "24:00:00")
            {
                return new TimeSpan24Hours(24, 0, 0);
            }
            else
            {
                TimeSpan ts = TimeSpan.ParseExact(aTime, @"h\:mm\:ss", CultureInfo.InvariantCulture);
                hours = ts.Hours;
                minutes = ts.Minutes;
                seconds = ts.Seconds;
                return new TimeSpan24Hours(hours, minutes, seconds);
            }
        }
    }
}
