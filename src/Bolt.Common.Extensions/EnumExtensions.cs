using System;

namespace Bolt.Common.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum? ToEnum<TEnum>(this string source) where TEnum : struct 
        {
            TEnum result;
            return Enum.TryParse(source, true, out result) ? result : (TEnum?) null;
        }
    }
}