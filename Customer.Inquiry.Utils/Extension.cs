using System;

namespace Customer.Inquiry.Utils
{
    public static class Extension
    {
        private static DateTime _default = new DateTime(1970, 1, 1, 0, 0, 0);

        public static long ToUnixTimestamp(this DateTime dt)
        {
            return (dt.Ticks - _default.Ticks) / 10000000;
        }

        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return _default.AddSeconds(timestamp);
        }
    }
}