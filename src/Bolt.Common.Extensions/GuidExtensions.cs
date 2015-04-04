using System;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class GuidExtensions
    {
        [DebuggerStepThrough]
        public static Guid? ToGuid(this string source)
        {
            Guid result;
            return Guid.TryParse(source, out result) ? result : (Guid?)null;
        }
    }
}