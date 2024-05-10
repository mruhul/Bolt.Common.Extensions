using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bolt.Common.Extensions
{
    public static class GuidExtensions
    {
        [DebuggerStepThrough]
        public static Guid? ToGuid(this string? source)
        {
            return Guid.TryParse(source, out var result) ? result : null;
        }

        [DebuggerStepThrough]
        public static bool IsEmpty([NotNullWhen(false)]this Guid? source)
        {
            return source == null || source.Value == Guid.Empty;
        }

        [DebuggerStepThrough]
        public static bool HasValue([NotNullWhen(true)]this Guid? source)
        {
            return source != null && source.Value != Guid.Empty;
        }

        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid source)
        {
            return source == Guid.Empty;
        }

        [DebuggerStepThrough]
        public static bool HasValue(this Guid source)
        {
            return source != Guid.Empty;
        }
    }
}