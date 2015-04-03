using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
