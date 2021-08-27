using System;
using System.Text;

namespace Bolt.Common.Extensions
{
    public static class Base64Extensions
    {
        /// <summary>
        /// Convert a UTF8 string to Base64 string
        /// </summary>
        /// <param name="utf8"></param>
        /// <returns></returns>
        public static string Base64Encode(this string utf8)
            => string.IsNullOrWhiteSpace(utf8)
                ? utf8
                : Convert.ToBase64String(Encoding.UTF8.GetBytes(utf8));

        /// <summary>
        /// Convert a Base64 string to UTF8 string
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static string Base64Decode(this string base64)
            => string.IsNullOrWhiteSpace(base64) 
                ? base64 
                : Encoding.UTF8.GetString(Convert.FromBase64String(base64));
    }
}
