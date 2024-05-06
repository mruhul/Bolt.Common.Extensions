﻿using System.Text;

namespace Bolt.Common.Extensions
{
    internal class SlugCreator
    {
        //http://www.danharman.net/2011/07/18/seo-slugification-in-dotnet-aka-unicode-to-ascii-aka-diacritic-stripping/
        public static string Create(string value, int maxlen, bool toLower)
        {
            if (value == null) return "";
 
            var normalised = value;

            var len = normalised.Length;
            var prevDash = false;
            var sb = new StringBuilder(len);

            for (var i = 0; i < len; i++)
            {
                var c = normalised[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    if (prevDash)
                    {
                        sb.Append('-');
                        prevDash = false;
                    }
                    sb.Append(c);
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    if (prevDash)
                    {
                        sb.Append('-');
                        prevDash = false;
                    }
                    // tricky way to convert to lowercase
                    if (toLower)
                        sb.Append((char)(c | 32));
                    else
                        sb.Append(c);
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' || c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevDash && sb.Length > 0)
                    {
                        prevDash = true;
                    }
                }
                else
                {
                    var swap = ConvertEdgeCases(c, toLower);
 
                    if (swap != null)
                    {
                        if (prevDash)
                        {
                            sb.Append('-');
                            prevDash = false;
                        }
                        sb.Append(swap);
                    }
                }
 
                if (sb.Length == maxlen) break;
            }
 
            return sb.ToString();
        }
 
        static string? ConvertEdgeCases(char c, bool toLower)
        {
            string? swap = null;
            switch (c)
            {
                case 'ı':
                    swap = "i";
                    break;
                case 'ł':
                    swap = "l";
                    break;
                case 'Ł':
                    swap = toLower ? "l" : "L";
                    break;
                case 'đ':
                    swap = "d";
                    break;
                case 'ß':
                    swap = "ss";
                    break;
                case 'ø':
                    swap = "o";
                    break;
                case 'Þ':
                    swap = "th";
                    break;
            }
            return swap;
        }
    }
}