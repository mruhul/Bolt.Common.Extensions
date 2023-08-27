using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Bolt.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Return string if not null otherwise return empty string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [return: NotNull]
        public static string NullSafe(this string? source)
        {
            return source ?? string.Empty;
        }

        /// <summary>
        /// Return string if not null otherwise reutrn the provided default value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [return: NotNull]
        public static string NullSafe(this string? source, string defaultValue)
        {
            return source ?? defaultValue;
        }


        /// <summary>
        /// Return source if not empty otherwise return provided alternative value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string EmptyAlternative(this string? source, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(source) ? defaultValue : source;
        }


        /// <summary>
        /// Check whether a string is null or empty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsEmpty([NotNullWhen(false)] this string? source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Check whether a string is not null and not empty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool HasValue([NotNullWhen(true)] this string? source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }


        /// <summary>
        /// Compare two string in case insensitive way and null safe
        /// </summary>
        /// <param name="source"></param>
        /// <param name="compareWith"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsSame(this string? source, string? compareWith)
        {
            return string.Equals(source, compareWith, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// Check a string starts with supplied string with ordinal ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool StartsWithIgnoreCase(this string? source, string value)
        {
            if (source == null || value == null) return false;

            return source.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// Check a string ends with supplied string with ordinal ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool EndsWithIgnoreCase(this string? source, string? value)
        {
            if (source == null || value == null) return false;

            return source.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// Check a string starts with supplied string with ordinal ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool ContainsIgnoreCase(this string? source, string? value)
        {
            if (source == null || value == null) return false;

            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1;
        }

        /// <summary>
        /// Compare supplied values with the source string in case insensitive way and return true
        /// when any one of the supplied values are equal to the source string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsSameAny(this string? source, params string[]? values)
        {
            if (source == null) return false;
            if (values == null) return false;

            foreach(var item in values)
            {
                if(string.Equals(item, source, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compare supplied values with the source string in case insensitive way and return true
        /// when any one of the supplied values are equal to the source string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsSameAny(this string? source, IEnumerable<string>? values)
        {
            if (source == null) return false;
            if (values == null) return false;

            foreach (var item in values)
            {
                if (string.Equals(item, source, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Join collection strings with supplied seperator
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string Join(this IEnumerable<string>? source, string seperator = ",")
        {
            if (source == null) return string.Empty;
            return string.Join(seperator, source);
        }

        [DebuggerStepThrough]
        public static string Description(this Enum source)
        {
            var value = source.ToString();
            var memberInfo = source.GetType().GetTypeInfo().GetMember(value).FirstOrDefault();

            if (memberInfo == null) return value;
            
            var attribute = memberInfo
                .GetCustomAttributes(typeof (DescriptionAttribute), false)
                .FirstOrDefault();

            return attribute != null 
                    ? ((DescriptionAttribute) attribute).Description 
                    : value;
        }

        [DebuggerStepThrough]
        public static string ToSlug(this string? source, int max = 80, bool keepCaseAsIs = false)
        {
            if(source == null) return string.Empty;

            return SlugCreator.Create(source, max, toLower: !keepCaseAsIs);
        }

        [DebuggerStepThrough]
        public static string FormatWith(this string? source, params object[] args)
        {
            if (source == null) return string.Empty;
            return string.Format(source, args);
        }
    }
}
