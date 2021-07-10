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


        /// <summary>
        /// use this method only when the string formatted as RoundtripKind ("o")
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime? ToUtcDateTime(this string source)
        {
            if(DateTime.TryParse(source, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
            {
                if (result.Kind == DateTimeKind.Utc) return result;

                return result.ToUniversalTime();
            }

            return null;
        }

        private const string UtcFormat = "o";
        /// <summary>
        /// Convert datetime to string formatted as RoundTripKind ("o"). If the date is null return null
        /// If the date kind is not UTC the function convert date to UniversalTime before format to string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FormatAsUtc(this DateTime? source)
            => source.HasValue 
                ? source.Value.Kind == DateTimeKind.Utc 
                    ? source.Value.ToString(UtcFormat)
                    : source.Value.ToUniversalTime().ToString(UtcFormat)
                : null;

        /// <summary>
        /// Convert datetime to string formatted as RoundTripKind ("o"). 
        /// If the date kind is not UTC the function convert date to UniversalTime before format to string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FormatAsUtc(this DateTime source)
            => source.Kind == DateTimeKind.Utc
                    ? source.ToString(UtcFormat)
                    : source.ToUniversalTime().ToString(UtcFormat);
    }
}