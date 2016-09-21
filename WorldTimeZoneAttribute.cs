namespace System
{
    /// <summary>
    /// Specifies attributes for the System.WorldTimeZone.
    /// </summary>
    class WorldTimeZoneAttribute : Attribute
    {
        private string _infoId;

        /// <summary>
        /// The time zone identifier, which corresponds to the System.TimeZoneInfo.Id property.
        /// </summary>
        public string InfoId { get { return _infoId; } }

        public WorldTimeZoneAttribute(string infoId)
        {
            this._infoId = infoId; 
        }
    }
}
