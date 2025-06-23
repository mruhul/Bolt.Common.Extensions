using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bolt.Common.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Return whether an IEnumerable is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool IsEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source)
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
    public static bool HasItem<T>([NotNullWhen(true)] this IEnumerable<T>? source)
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
    public static IEnumerable<T> Append<T>(this IEnumerable<T>? source, params T[] items)
    {
        return source == null ? items : source.Concat(items);
    }

    /// <summary>
    /// Add items beginning of IEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T>? source, params T[] items)
    {
        return source == null ? items : items.Concat(source);
    }

    /// <summary>
    /// Perform an action for each item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    [DebuggerStepThrough]
    public static void ForEach<T>(this IEnumerable<T>? source, Action<T> action)
    {
        if (source == null) return;
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
    public static bool ContainsIgnoreCase(this IEnumerable<string>? source, string? value)
    {
        if (source == null) return false;

        if (value == null) return false;

        foreach (var item in source)
        {
            if (string.Equals(item, value, StringComparison.OrdinalIgnoreCase))
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
    /// <param name="values"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool ContainsIgnoreCaseAny(this IEnumerable<string>? source, params string[] values)
    {
        if (source == null) return false;

        foreach (var item in source)
        {
            foreach (var valueToFind in values)
            {
                if (string.Equals(item, valueToFind, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Check whether any of the supplied value exists in collection in case insensitive way
    /// </summary>
    /// <param name="source"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool ContainsIgnoreCaseAny(this IEnumerable<string>? source, IEnumerable<string>? values)
    {
        if (source == null) return false;

        if (values == null) return false;
        
        foreach (var item in source)
        {
            foreach (var valueToFind in values)
            {
                if (string.Equals(item, valueToFind, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    


    /// <summary>
    /// Join array of strings using separator but exclude any empty or null values
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    [return: NotNullIfNotNull(nameof(source))]
    public static string? JoinNonEmptyValues(this IEnumerable<string>? source, string? separator)
    {
        if (source == null) return null;

        return string.Join(separator, GetNonEmptyValues(source));
    }
    
    /// <summary>
    /// Join array of strings using separator but exclude any empty or null values
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    [return: NotNullIfNotNull(nameof(source))]
    public static string? JoinNonEmptyValues(this IEnumerable<string>? source, char separator)
    {
        if (source == null) return null;

        return string.Join(separator, GetNonEmptyValues(source));
    }

    private static IEnumerable<string> GetNonEmptyValues(IEnumerable<string> source)
    {
        foreach (var item in source)
        {
            if(string.IsNullOrWhiteSpace(item)) continue;

            yield return item;
        }
    }
}