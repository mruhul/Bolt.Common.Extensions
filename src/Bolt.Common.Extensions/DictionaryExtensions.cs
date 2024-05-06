using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bolt.Common.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Return a new instance of dictionary of supplied source is null otherwise return the source
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> NullSafe<TKey, TValue>(this IDictionary<TKey, TValue>? source) where TKey : notnull 
            => source ?? new Dictionary<TKey, TValue>();

        /// <summary>
        /// Return value based on key if exists otherwise return default TValue. Please note this method
        /// doesn't check whether the supplied source is null or not.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static TValue? TryGetValueOrDefault<TKey, TValue>(this IDictionary<TKey,TValue> source, TKey key)
        {
            return source.TryGetValue(key, out var result) ? result : default;
        }

        /// <summary>
        /// Return value based on key if exists otherwise return the supplied default TValue. Please note this method
        /// doesn't check whether the supplied source is null or not.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static TValue TryGetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            return source.TryGetValue(key, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Merge a dictionary with another dictionary and return a new dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="mergeWith"></param>
        /// <param name="ignoreWhenAlreadyExists"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IDictionary<TKey, TValue>? Merge<TKey, TValue>(this IDictionary<TKey, TValue>? source, 
            IDictionary<TKey,TValue>? mergeWith,
            bool ignoreWhenAlreadyExists = false) where TKey : notnull
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

        /// <summary>
        /// Merge two dictionary into a new dictionary where keys are case insensitive and return the new dictionary. 
        /// Please note, the final dictionary that return will compare key in case insensitive way
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="mergeWith"></param>
        /// <param name="ignoreWhenAlreadyExists"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IDictionary<string, TValue> MergeIgnoreCase<TValue>(this IDictionary<string, TValue> source,
            IDictionary<string, TValue> mergeWith,
            bool ignoreWhenAlreadyExists = false)
        {
            if (source == null) return mergeWith;
            if (mergeWith == null) return source;

            var result = new Dictionary<string, TValue>(StringComparer.OrdinalIgnoreCase);

            foreach (var keyVal in source)
            {
                result[keyVal.Key] = keyVal.Value;
            }

            foreach (var keyVal in mergeWith)
            {
                if (ignoreWhenAlreadyExists)
                {
                    if (result.ContainsKey(keyVal.Key)) continue;
                }

                result[keyVal.Key] = keyVal.Value;
            }

            return result;
        }

        /// <summary>
        /// Append a dictionary to the source dictionary and return the source dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="mergeWith"></param>
        /// <param name="ignoreWhenAlreadyExists"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IDictionary<TKey, TValue> Append<TKey, TValue>(this IDictionary<TKey, TValue> source,
            IDictionary<TKey, TValue> mergeWith,
            bool ignoreWhenAlreadyExists = false)
        {
            if (source == null) return mergeWith;
            if (mergeWith == null) return source;

            foreach (var keyVal in mergeWith)
            {
                if (ignoreWhenAlreadyExists)
                {
                    if (source.ContainsKey(keyVal.Key)) continue;
                }

                source[keyVal.Key] = keyVal.Value;
            }

            return source;
        }
    }
}