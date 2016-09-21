namespace System
{
    static public partial class WorldTimeZoneExtensions
    {
        /// <summary>
        /// Converts the value of the current System.DateTime object to Coordinated Universal Time (UTC)。
        /// </summary>
        /// <param name="value">The date and time to convert.</param>
        /// <param name="worldTimeZone">The world time zone to convert dateTime to.</param>
        /// <returns></returns>
        public static DateTime ToUniversalTime(this DateTime value, WorldTimeZone worldTimeZone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(value, worldTimeZone.GetTimeZoneInfo());
        }

        /// <summary>
        /// Converts the value of the current System.DateTime object to local time.
        /// </summary>
        /// <param name="value">The date and time to convert.</param>
        /// <param name="worldTimeZone">The world time zone to convert dateTime to.</param>
        /// <returns></returns>
        public static DateTime ToLocalTime(this DateTime value, WorldTimeZone worldTimeZone)
        {
            return TimeZoneInfo.ConvertTime(value, worldTimeZone.GetTimeZoneInfo());
        }

        /// <summary>
        /// Converts the value from one time zone to another.
        /// </summary>
        /// <param name="value">The date and time to convert.</param>
        /// <param name="destinationWorldTimeZone">The world time zone to convert dateTime to.</param>
        /// <returns></returns>
        public static DateTime ConverToTimeZone(this DateTime value, WorldTimeZone destinationWorldTimeZone)
        {
            return TimeZoneInfo.ConvertTime(value, value.Kind.Equals(DateTimeKind.Utc) ? TimeZoneInfo.Utc : TimeZoneInfo.Local, destinationWorldTimeZone.GetTimeZoneInfo());
        }

        /// <summary>
        /// Converts the value from one time zone to another.
        /// </summary>
        /// <param name="value">The date and time to convert.</param>
        /// <param name="sourceWorldTimeZone">The world time zone of dateTime.</param>
        /// <param name="destinationWorldTimeZone">The world time zone to convert dateTime to.</param>
        /// <returns></returns>
        public static DateTime ConverToTimeZone(this DateTime value, WorldTimeZone sourceWorldTimeZone, WorldTimeZone destinationWorldTimeZone)
        {
            return TimeZoneInfo.ConvertTime(value, sourceWorldTimeZone.GetTimeZoneInfo(), destinationWorldTimeZone.GetTimeZoneInfo());
        }
    }
}

