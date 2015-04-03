using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class BoolExtensions
    {
        [DebuggerStepThrough]
        public static bool? ToBoolean(this string source)
        {
            bool result;
            return bool.TryParse(source, out result) ? result : (bool?)null;
        }

        [DebuggerStepThrough]
        public static bool NullSafe(this bool? source)
        {
            return source ?? false;
        }
    }
}