using System;

namespace CossSharpLib.Utils
{
    public class DateTimeUtil : IDateTimeUtil
    {
        public long GetUnixTimeStamp13Digit()
        {
            return GetUnixTimeStamp13Digit(DateTime.UtcNow);
        }

        public long GetUnixTimeStamp13Digit(DateTime utcNow)
        {
            var totalSeconds = (utcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return (long)(totalSeconds * 1000);
        }

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
