using System;

namespace CossSharp.Utils
{
    public interface IDateTimeUtil
    {
        long GetUnixTimeStamp13Digit();

        long GetUnixTimeStamp13Digit(DateTime utcNow);

        DateTime UtcNow { get; }
    }
}
