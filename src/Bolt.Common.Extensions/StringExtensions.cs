using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

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
        public static string NullSafe(this string source, string defaultValue)
        {
            return source ?? defaultValue;
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

        [DebuggerStepThrough]
        public static bool IsSame(this string source, string compareWith)
        {
            return string.Equals(source, compareWith, StringComparison.OrdinalIgnoreCase);
        }

        [DebuggerStepThrough]
        public static string Join(this IEnumerable<string> source, string seperator = ",")
        {
            return string.Join(seperator, source);
        }

        [DebuggerStepThrough]
        public static string Description(this Enum source)
        {
            var value = source.ToString();
            var memberInfo = source.GetType().GetMember(value).FirstOrDefault();

            if (memberInfo == null) return value;
            
            var attribute = memberInfo
                .GetCustomAttributes(typeof (DescriptionAttribute), false)
                .FirstOrDefault();

            return attribute != null 
                    ? ((DescriptionAttribute) attribute).Description 
                    : value;
        }

        [DebuggerStepThrough]
        public static string ToSlug(this string source, int max = 80, bool keepCaseAsIs = false)
        {
            return SlugCreator.Create(source, max, toLower: !keepCaseAsIs);
        }

        [DebuggerStepThrough]
        public static string FormatWith(this string source, params object[] args)
        {
            return string.Format(source, args);
        }
    }
}
