using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bolt.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Return whether an IEnumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Return whether an IEnumerable has any item or not null safe way
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool HasItem<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// Add items end of IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
        {
            return items == null ? source : source.Concat(items);
        }

        /// <summary>
        /// Add items beginning of Ienumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, params T[] items)
        {
            return items == null ? source : items.Concat(source);
        }

        /// <summary>
        /// Perform an action for each item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// Check whether a string exists in a collection of string in case insensitive way
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool ContainsIgnoreCase(this IEnumerable<string> source, string value)
        {
            if (source == null) return false;
            
            if (value == null) return false;
            
            foreach(var item in source)
            {
                if(string.Equals(item, value, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether any of the supplied value exists in collection in case insensitive way
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool ContainsAnyIgnoreCase(this IEnumerable<string> source, params string[] value)
        {
            if (source == null) return false;

            if (value == null) return false;

            foreach(var valueToFind in value)
            {
                foreach (var item in source)
                {
                    if (string.Equals(item, valueToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}