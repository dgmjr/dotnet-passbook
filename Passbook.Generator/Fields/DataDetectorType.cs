using System;

namespace Passbook.Generator.Fields
{
    [Flags]
    public enum DataDetectorTypes
    {
        /// <summary>
        /// Automatically detect any of the supported data types
        /// </summary>
        PKDataDetectorNone = 0,

        /// <summary>
        /// Automatically detect phone numbers
        /// </summary>
        PKDataDetectorTypePhoneNumber = 1 << 1,

        /// <summary>
        /// Automatically detect links
        /// </summary>
        PKDataDetectorTypeLink = 1 << 2,

        /// <summary>
        /// Automatically detect addresses
        /// </summary>
        PKDataDetectorTypeAddress = 1 << 3,

        /// <summary>
        /// Automatically detect calendar events
        /// </summary>
        PKDataDetectorTypeCalendarEvent = 1 << 4,

        /// <summary>
        /// Automatically detect any of the supported data types
        /// </summary>
        PKDataDetectorAll =
            PKDataDetectorTypePhoneNumber
            | PKDataDetectorTypeLink
            | PKDataDetectorTypeAddress
            | PKDataDetectorTypeCalendarEvent
    }
}
