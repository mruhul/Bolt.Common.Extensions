using System.Collections.Generic;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class DictionaryExtensions
    {
        [DebuggerStepThrough]
        public static TValue TryGetValueOrDefault<TKey, TValue>(this IDictionary<TKey,TValue> source, TKey key)
        {
            TValue result;
            return source.TryGetValue(key, out result) ? result : default(TValue);
        }

        [DebuggerStepThrough]
        public static TValue TryGetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue result;
            return source.TryGetValue(key, out result) ? result : defaultValue;
        }

        [DebuggerStepThrough]
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> source, 
            IDictionary<TKey,TValue> mergeWith,
            bool ignoreWhenAlreadyExists = false)
        {
            if (source == null) return mergeWith;
            if (mergeWith == null) return source;

            var result = new Dictionary<TKey, TValue>();

            foreach(var keyVal in source)
            {
                result[keyVal.Key] = keyVal.Value;
            }

            foreach(var keyVal in mergeWith)
            {
                if(ignoreWhenAlreadyExists)
                {
                    if (result.ContainsKey(keyVal.Key)) continue;
                }

                result[keyVal.Key] = keyVal.Value;
            }

            return result;
        }
    }
}