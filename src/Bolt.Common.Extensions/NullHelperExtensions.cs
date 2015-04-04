using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bolt.Common.Extensions
{
    public static class NullHelperExtensions
    {
        [DebuggerStepThrough]
        public static TStruct NullSafe<TStruct>(this TStruct? source) where TStruct : struct
        {
            return source ?? default(TStruct);
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> NullSafe<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        [DebuggerStepThrough]
        public static TOutput NullSafeGet<TInput, TOutput>(this TInput input, Func<TInput, TOutput> func)
        {
            if (input == null) return default(TOutput);

            return func.Invoke(input);
        }

        [DebuggerStepThrough]
        public static TInput NullSafeDo<TInput>(this TInput input, Action<TInput> func)
        {
            if (input != null)
            {
                func.Invoke(input);
            }

            return input;
        }
    }
}