using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bolt.Common.Extensions
{
    public static class BoolExtensions
    {
        [DebuggerStepThrough]
        public static bool? ToBoolean([NotNullWhen(true)]this string? source)
        {
            return bool.TryParse(source, out var result) ? result : null;
        }

        [DebuggerStepThrough]
        public static bool NullSafe(this bool? source)
        {
            return source ?? false;
        }
    }
}