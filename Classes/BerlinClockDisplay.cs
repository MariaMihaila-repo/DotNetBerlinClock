using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockDisplay
    {
        private DisplayClockColor Seconds;
        private DisplayClockColor[] FirstRowHours;
        private DisplayClockColor[] SecondRowHours;
        private DisplayClockColor[] FirstRowMinutes;
        private DisplayClockColor[] SecondRowMinutes;

        public BerlinClockDisplay(TimeSpan24Hours timeSpan24Hours)
        {
            FirstRowHours = new DisplayClockColor[4];
            SecondRowHours = new DisplayClockColor[4];
            FirstRowMinutes = new DisplayClockColor[11];
            SecondRowMinutes = new DisplayClockColor[4];
            SetHours(timeSpan24Hours.Hours);
            SetMinutes(timeSpan24Hours.Minutes);
            SetSeconds(timeSpan24Hours.Seconds);
        }

        private void SetHours(int hours)
        {
            int currentIdx;
            for (currentIdx = 0; currentIdx < 4 && (currentIdx + 1) * 5 <= hours; currentIdx++)
                FirstRowHours[currentIdx] = DisplayClockColor.R;

            for (currentIdx = 0; currentIdx < 4 && currentIdx < hours - hours / 5 * 5; currentIdx++)
                SecondRowHours[currentIdx] = DisplayClockColor.R;
        }

        private void SetMinutes(int minutes)
        {
            int currentIdx;
            for (currentIdx = 0; currentIdx < 11 && (currentIdx + 1) * 5 <= minutes; currentIdx++)
                FirstRowMinutes[currentIdx] = (currentIdx + 1) % 3 == 0 ? DisplayClockColor.R : DisplayClockColor.Y;

            for (currentIdx = 0; currentIdx < 4 && currentIdx < minutes - minutes / 5 * 5; currentIdx++)
                SecondRowMinutes[currentIdx] = DisplayClockColor.Y;
        }

        private void SetSeconds(int seconds)
        {
            this.Seconds = seconds % 2 == 0 ? DisplayClockColor.Y : DisplayClockColor.O;
        }

        public override string ToString()
        {
            int i;
            StringBuilder sb = new StringBuilder();
            sb.Append(Seconds);
            sb.Append(Environment.NewLine);
            for (i = 0; i < 4; i++)
                sb.Append(FirstRowHours[i]);
            sb.Append(Environment.NewLine);
            for (i = 0; i < 4; i++)
                sb.Append(SecondRowHours[i]);
            sb.Append(Environment.NewLine);
            for (i = 0; i < 11; i++)
                sb.Append(FirstRowMinutes[i]);
            sb.Append(Environment.NewLine);
            for (i = 0; i < 4; i++)
                sb.Append(SecondRowMinutes[i]);
            return sb.ToString();
        }

    }
}
