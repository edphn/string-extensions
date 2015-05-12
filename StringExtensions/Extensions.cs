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
        /// <summary>
        /// Returns a camelCase version of the string. Trims surrounding spaces,
        /// capitalizes letters following digits, spaces, dashes and underscores,
        /// and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>String in camel case format</returns>
        public static string Camelize(this string instance)
        {
            char[] delimiters = new char[] { ' ', '_', '-' };
            string[] chunks = instance.CollapseWhitespace().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string camelCasedString = string.Join(string.Empty, chunks.Select(x => x.ToUpperFirst()));

            return Regex.Replace(camelCasedString, @"[\d]+(.)?", c => c.ToString().ToUpper()).ToLowerFirst();
        }

        /// <summary>
        /// Returns new trimmed string with replaced consecutive whitespace characters with a 
        /// single space (including tabs and newline characters).
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>Trimmed string with condensed whitespace</returns>
        public static string CollapseWhitespace(this string instance)
        {
            return Regex.Replace(instance.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Counts occurencies of given substring.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <param name="substring">The substring to search for</param>
        /// <param name="caseSensitive">Whether or not to enforce case-sensitivity</param>
        /// <returns>The number of substring occurencies</returns>
        public static int CountSubstring(this string instance, string substring, bool caseSensitive = true)
        {
            return Regex.Matches(instance, substring, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Count;
        }

        public static string Dasherize(this string instance)
        {

        }

        /// <summary>
        /// Ensures that the string begins with given substring. If it does
        /// not, then returns a new string in which a specified string is 
        /// inserted at the very first position in this instance.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <param name="substring">The substring to add if not present</param>
        /// <returns>String prefixed by the substring</returns>
        public static string EnsureLeft(this string instance, string value)
        {
            if (!instance.StartsWith(value)) return instance.Insert(0, value);

            return instance;
        }

        /// <summary>
        /// Ensures that the string ends with given substring. If it does
        /// not, then returns a new string in which a specified string is 
        /// inserted at the very last position in this instance.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <param name="substring">The substring to add if not present</param>
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
        /// Determines whether the string contains only alphabetic characters.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>True if the string contains only alphabetic characters, false otherwise</returns>
        public static bool IsAlpha(this string instance)
        {
            return instance.All(Char.IsLetter);
        }

        /// <summary>
        /// Determines whether the string contains only alphanumeric characters.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>True if the string contains only alphanumeric characters, false otherwise</returns>
        public static bool IsAlphanumeric(this string instance)
        {
            return instance.All(Char.IsLetterOrDigit);
        }

        /// <summary>
        /// Determines whether the string contains only lowercase characters.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>True if the string contains only lowercase characters, false otherwise</returns>
        public static bool IsLower(this string instance)
        {
            return instance.All(Char.IsLower);
        }

        /// <summary>
        /// Determines whether the string contains only uppercase characters.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>True if the string contains only uppercase characters, false otherwise</returns>
        public static bool IsUpper(this string instance)
        {
            return instance.All(Char.IsUpper);
        }

        public static string Pascalize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string SafeTruncate(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a copy of this string with shuffled characters.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>String with shuffled characters</returns>
        public static string Shuffle(this string instance)
        {
	        Random random = new Random();

            return new string(instance.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());          
        }

        public static string Slugify(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a copy of this string surrounded by given substring.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <param name="substring">Substring to prepend and append</param>
        /// <returns>String surrounded by substring</returns>
        public static string Surround(this string instance, string substring)
        {
            return instance.Insert(instance.Length, substring).Insert(0, substring);
        }

        /// <summary>
        /// Returns a copy of this string with swapped case.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>String with swapped case</returns>
        public static string SwapCase(this string instance)
        {
            var swappedString = new StringBuilder();

            foreach (char c in instance)
            {
                swappedString.Append(Char.IsUpper(c) ? Char.ToLower(c) : Char.ToUpper(c));
            }

            return swappedString.ToString();
        }

        public static string Titleize(this string instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to lowercase.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>Equivalent of the current string with first letter in lowercase</returns>
        public static string ToLowerFirst(this string instance)
        {
            return (instance.Length > 0)
                ? string.Concat(instance[0].ToString().ToLower(), instance.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to uppercase.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <returns>Equivalent of the current string with first letter in uppercase</returns>
        public static string ToUpperFirst(this string instance)
        {
            return (instance.Length > 0)
                ? string.Concat(instance[0].ToString().ToUpper(), instance.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns new string, truncated to a given length. If substring is provided, and
        /// truncating occurs, the string is further truncated so that the substring
        /// may be appended without exceeding the desired length.
        /// </summary>
        /// <param name="instance">String instance</param>
        /// <param name="length">Desired length of the truncated string</param>
        /// <param name="substring">The substring to append if it can fit</param>
        /// <returns>New string truncated to given length</returns>
        public static string Truncate(this string instance, int length, string substring = "")
        {
            if (length >= instance.Length) return instance;

            length = length - substring.Length;

            return string.Concat(instance.Substring(0, length), substring);
        }

        public static string Underscorize(this string instance)
        {
            throw new NotImplementedException();
        }
    }
}