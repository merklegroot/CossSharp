using System;

namespace CossSharpLib.Utils
{
    public interface IDateTimeUtil
    {
        long GetUnixTimeStamp13Digit();

        long GetUnixTimeStamp13Digit(DateTime utcNow);

        DateTime UtcNow { get; }
    }
}
