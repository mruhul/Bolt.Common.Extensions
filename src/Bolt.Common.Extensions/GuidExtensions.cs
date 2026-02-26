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

#if NET10_0

        [DebuggerStepThrough]
        public static DateTimeOffset? TryExtractDateTime(this Guid? source)
        {
            if (source is null)
                return null;

            var guid = source.Value;

            if (guid.Version != 7)
                return null;

            Span<byte> bytes = stackalloc byte[16];

            // RFC 4122 byte order (big-endian)
            guid.TryWriteBytes(bytes, bigEndian: true, out _);

            long timestamp =
                ((long)bytes[0] << 40) |
                ((long)bytes[1] << 32) |
                ((long)bytes[2] << 24) |
                ((long)bytes[3] << 16) |
                ((long)bytes[4] << 8)  |
                bytes[5];

            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
        }
#endif
    }
}