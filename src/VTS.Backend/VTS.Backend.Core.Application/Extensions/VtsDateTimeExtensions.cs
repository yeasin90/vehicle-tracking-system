using System;

namespace VTS.Backend.Core.Application.Extensions
{
    // Conversion rule reference : https://iditect.com/guide/csharp/csharp_howto_convert_datetime.html
    public static class VtsDateTimeExtensions
    {
        public static double ToUnixTimeStampInSeconds(this DateTime dateTime)
        {
            long unixTimestampInSeconds = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
            return unixTimestampInSeconds;
        }

        public static double ToUnixTimeStampInMiliSeconds(this DateTime dateTime)
        {
            long unixTimestampInMilliseconds = new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
            return unixTimestampInMilliseconds;
        }

        public static DateTime ToUtcDateTime(this double timeStampInSeconds)
        {
            DateTime utcDatetime = DateTimeOffset.FromUnixTimeSeconds(timeStampInSeconds.ConvertTimeStampTolong()).UtcDateTime;
            return utcDatetime;
        }

        public static DateTime ToDateTime(this double timeStampInSeconds)
        {
            DateTime localDatetime = DateTimeOffset.FromUnixTimeSeconds(timeStampInSeconds.ConvertTimeStampTolong()).LocalDateTime;
            return localDatetime;
        }

        private static long ConvertTimeStampTolong(this double timeStampInSeconds)
        {
            return Convert.ToInt64(timeStampInSeconds);
        }
    }
}
