namespace System
{
    static public partial class WorldTimeZoneExtensions
    {
        /// <summary>
        /// Retrieves a System.TimeZoneInfo object from the registry based on its world time zone.
        /// </summary>
        /// <param name="value">The world time zone.</param>
        /// <returns></returns>
        public static TimeZoneInfo GetTimeZoneInfo(this WorldTimeZone value)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(GetInfoId(value));
        }

        /// <summary>
        /// Retrieves the time zone identifier, which corresponds to the System.TimeZoneInfo.Id property.
        /// </summary>
        /// <param name="value">The world time zone.</param>
        /// <returns></returns>
        static public string GetInfoId(this WorldTimeZone value)
        {
            return GetWorldTimeZoneAttribute(value).InfoId;
        }

        static private WorldTimeZoneAttribute GetWorldTimeZoneAttribute(WorldTimeZone value)
        {
            var type = value.GetType();

            var members = type.GetMember(value.ToString());
            if (members.Length == 0) throw new ArgumentException(String.Format("Member '{0}' not found in type '{1}'", value, type.Name));
            
            var member = members[0];
            var attributes = member.GetCustomAttributes(typeof(WorldTimeZoneAttribute), false);
            if (attributes.Length == 0) throw new ArgumentException(String.Format("'{0}.{1}' doesn't have WorldTimeZoneAttribute", type.Name, value));

            return (WorldTimeZoneAttribute)attributes[0];
        }
    }
}
