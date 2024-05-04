using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class GuidExtensions
    {
        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid? source)
        {
            return source == null || source.Value == Guid.Empty;
        }

        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid source)
        {
            return source == Guid.Empty;
        }        

        [DebuggerStepThrough]
        public static bool HasValue(this Guid? source)
        {
            return source != null && source.Value != Guid.Empty;
        }

        [DebuggerStepThrough]
        public static bool HasValue(this Guid source)
        {
            return source != Guid.Empty;
        }        
    }
}