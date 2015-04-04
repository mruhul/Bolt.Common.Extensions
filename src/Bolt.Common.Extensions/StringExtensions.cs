using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string NullSafe(this string source)
        {
            return source ?? string.Empty;
        }

        [DebuggerStepThrough]
        public static bool IsEmpty(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        [DebuggerStepThrough]
        public static bool HasValue(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        [DebuggerStepThrough]
        public static bool IsSame(this string source, string compareWith)
        {
            return string.Equals(source, compareWith, StringComparison.OrdinalIgnoreCase);
        }

        [DebuggerStepThrough]
        public static string Join(this IEnumerable<string> source, string seperator)
        {
            return string.Join(seperator, source);
        }
    }
}
