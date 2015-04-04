using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bolt.Common.Extensions
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        [DebuggerStepThrough]
        public static bool HasItem<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
        {
            return items == null ? source : source.Concat(items);
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, params T[] items)
        {
            return items == null ? source : items.Concat(source);
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}