using System.Collections.Generic;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class DictionaryExtensions
    {
        [DebuggerStepThrough]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey,TValue> source, TKey key)
        {
            TValue result;
            return source.TryGetValue(key, out result) ? result : default(TValue);
        }

        [DebuggerStepThrough]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue result;
            return source.TryGetValue(key, out result) ? result : defaultValue;
        }
    }
}