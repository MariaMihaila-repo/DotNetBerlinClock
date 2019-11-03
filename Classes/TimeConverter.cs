using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            return new BerlinClockDisplay(GetTimeOfDay(aTime)).ToString();
        }

        private TimeSpan24Hours GetTimeOfDay(string aTime)
        {
            if (String.IsNullOrEmpty(aTime) || !aTime.IsValidTime24HoursFormat())
                throw new InvalidTimeArgumentException("Invalid time argument!");

            return aTime.GetTimeFields24HoursFormat();
        }

    }
}
