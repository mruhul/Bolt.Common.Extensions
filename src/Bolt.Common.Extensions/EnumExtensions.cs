﻿using System;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class EnumExtensions
    {
        [DebuggerStepThrough]
        public static TEnum? ToEnum<TEnum>(this string? source) where TEnum : struct 
        {
            return Enum.TryParse(source, true, out TEnum result) ? result : null;
        }

        [DebuggerStepThrough]
        public static TEnum? ToEnum<TEnum>(this int source) where TEnum : struct
        {
            var type = typeof (TEnum);

            if (Enum.IsDefined(type, source))
            {
                return (TEnum)Enum.ToObject(type, source);
            }

            return null;
        }
    }
}