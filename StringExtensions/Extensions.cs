using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class Extensions
    {
        public static string Camelize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string CollapseWhitespace(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Counts occurencies of given substring.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="caseSensitive">Whether or not to enforce case-sensitivity.</param>
        /// <returns>The number of substring occurencies.</returns>
        public static int CountSubstring(this string instance, string substring, bool caseSensitive = true)
        {
            return Regex.Matches(instance, substring, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Count;
        }

        public static string Dasherize(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ensures that the string begins with given substring. If it does
        /// not, then it's prepended.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <param name="substring">The substring to add if not present.</param>
        /// <returns>String prefixed by the substring.</returns>
        public static string EnsureLeft(this string instance, string substring)
        {
            if (!instance.StartsWith(substring)) return instance.Insert(0, substring);

            return instance;
        }

        /// <summary>
        /// Ensures that the string ends with given substring. If it does 
        /// not, then it's appended.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <param name="substring">The substring to add if not present.</param>
        /// <returns>String suffixed by the substring.</returns>
        public static string EnsureRight(this string instance, string substring)
        {
            if (!instance.EndsWith(substring)) return instance.Insert(instance.Length, substring);

            return instance;
        }

        public static string Humanize(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether string contains only alphabetic characters.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <returns>True if the string contains only alphabetic characters, false otherwise.</returns>
        public static bool IsAlpha(this string instance)
        {
            return instance.All(Char.IsLetter);
        }

        /// <summary>
        /// Determines whether string contains only alphanumeric characters.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <returns>True if the string contains only alphanumeric characters, false otherwise.</returns>
        public static bool IsAlphanumeric(this string instance)
        {
            return instance.All(Char.IsLetterOrDigit);
        }

        public static bool IsHexadecimal(this string instance)
        {
            throw new NotImplementedException();
        }

        public static bool IsJson(this string instance)
        {
            throw new NotImplementedException();
        }

        public static bool IsLowerCase(this string instance)
        {
            throw new NotImplementedException();
        }

        public static bool IsUpperCase(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string LowerCaseFirst(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string RemoveLeft(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string RemoveRight(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string SafeTruncate(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string Shuffle(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string Slugify(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Surrounds string with given substring.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <param name="substring">Substring to prepend and append.</param>
        /// <returns>String surrounded by substring.</returns>
        public static string Surround(this string instance, string substring)
        {
            return instance.Insert(instance.Length, substring).Insert(0, substring);
        }

        public static string SwapCase(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string Titleize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string ToTitleCase(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Truncates the string to a given length. If substring is provided, and
        /// truncating occurs, the string is further truncated so that the substring
        /// may be appended without exceeding the desired length.
        /// </summary>
        /// <param name="instance">String instance.</param>
        /// <param name="length">Desired length of the truncated string.</param>
        /// <param name="substring">The substring to append if it can fit.</param>
        /// <returns>String after truncating.</returns>
        public static string Truncate(this string instance, int length, string substring = "")
        {
            if (length >= instance.Length) return instance;

            length = length - substring.Length;

            return string.Concat(instance.Substring(0, length), substring);
        }

        public static string UpperCaseFirst(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string Underscored(this string instance)
        {
            throw new NotImplementedException();
        }
    }
}