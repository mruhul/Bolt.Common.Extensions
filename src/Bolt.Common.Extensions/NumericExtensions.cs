using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class NumericExtensions
    {
        [DebuggerStepThrough]
        public static int? ToInt(this string source)
        {
            int result;
            return int.TryParse(source, out result) ? result : (int?)null;
        }

        [DebuggerStepThrough]
        public static decimal? ToDecimal(this string source)
        {
            decimal result;
            return decimal.TryParse(source, out result) ? result : (decimal?)null;
        }


        [DebuggerStepThrough]
        public static long? ToLong(this string source)
        {
            long result;
            return long.TryParse(source, out result) ? result : (long?)null;
        }


        [DebuggerStepThrough]
        public static double? ToDouble(this string source)
        {
            double result;
            return double.TryParse(source, out result) ? result : (double?)null;
        }

        [DebuggerStepThrough]
        public static float? ToFloat(this string source)
        {
            float result;
            return float.TryParse(source, out result) ? result : (float?)null;
        }
    }
}