using System;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class EnumExtensions
    {
        [DebuggerStepThrough]
        public static TEnum? ToEnum<TEnum>(this string source) where TEnum : struct 
        {
            TEnum result;
            return Enum.TryParse(source, true, out result) ? result : (TEnum?) null;
        }
    }
}