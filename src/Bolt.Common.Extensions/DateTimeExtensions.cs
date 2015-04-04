using System;
using System.Globalization;

namespace Bolt.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? ToDateTime(this string source, string format = null, DateTimeStyles styles = DateTimeStyles.None)
        {
            DateTime result;

            if (string.IsNullOrWhiteSpace(format))
            {
                return DateTime.TryParse(source, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)
                    ? result
                    : (DateTime?) null;
            }

            return DateTime.TryParseExact(source, format, CultureInfo.InvariantCulture, styles, out result) ? result : (DateTime?)null;
        }
    }
}