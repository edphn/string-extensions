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
        /// Returns a copy of this string in camelCase version. Trims surrounding 
        /// spaces, capitalizes letters following digits, spaces, dashes and 
        /// underscores, and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String in camelCase format</returns>
        public static string Camelize(this string str)
        {
            string[] chunks = SplitIntoChunks(str);
            string camelizedString = string.Join(string.Empty, chunks.Select(x => x.ToUpperFirst())).ToLowerFirst();

            return Regex.Replace(camelizedString, @"[\d]+(.)?", c => c.ToString().ToUpper()).ToLowerFirst();
        }

        /// <summary>
        /// Returns new trimmed string with replaced consecutive whitespace 
        /// characters with a single space (including tabs and newline characters).
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Trimmed string with condensed whitespace</returns>
        public static string CollapseWhitespace(this string str)
        {
            return Regex.Replace(str.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Counts occurencies of given substring.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">The substring to search for</param>
        /// <param name="caseSensitive">Whether or not to enforce case-sensitivity</param>
        /// <returns>The number of substring occurencies</returns>
        public static int CountSubstring(this string str, string substring, bool caseSensitive = true)
        {
            return Regex.Matches(str, substring, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        /// Returns a copy of this string in dash-case version. Trims surrounding 
        /// spaces, dashes and underscores. Dashes are inserted before capital 
        /// letters and in place of spaces and underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String in dash-case format</returns>
        public static string Dasherize(this string str)
        {
            return Delimit(str, "-");
        }

        /// <summary>
        /// Returns a copy of this string delimited by given delimiter. Trims 
        /// surrounding spaces, dashes and underscores. Delimiters are inserted
        /// before capital letters and in place of spaces, dashes and underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="delimiter">String used as delimiter</param>
        /// <returns>String delimited by given delimiter</returns>
        public static string Delimit(this string str, string delimiter)
        {
            string[] chunks = SplitIntoChunks(str);

            return JoinUsingDelimiter(delimiter, chunks);
        }

        /// <summary>
        /// Ensures that the string begins with given substring. If it does not, 
        /// then returns a new string in which a specified string is inserted at 
        /// the very first position in this instance.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">The substring to add if not present</param>
        /// <returns>String prefixed by the substring</returns>
        public static string EnsureLeft(this string str, string value)
        {
            if (!str.StartsWith(value)) return str.Insert(0, value);

            return str;
        }

        /// <summary>
        /// Ensures that the string ends with given substring. If it does not, 
        /// then returns a new string in which a specified string is inserted at 
        /// the very last position in this instance.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">The substring to add if not present</param>
        /// <returns>String suffixed by the substring.</returns>
        public static string EnsureRight(this string str, string substring)
        {
            if (!str.EndsWith(substring)) return str.Insert(str.Length, substring);

            return str;
        }

        /// <summary>
        /// Returns the first n characters of this string.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="numberOfCharacters">Number of characters to return</param>
        /// <returns>First n characters of this string</returns>
        public static string FirstCharacters(this string str, int numberOfCharacters)
        {
            return str.Substring(0, Math.Min(str.Length, numberOfCharacters < 0 ? 0 : numberOfCharacters));
        }

        /// <summary>
        /// Determines whether the string contains any lowercase character.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains at least one lowercase characters, false otherwise</returns>
        public static bool HasLower(this string str)
        {
            return str.Any(c => char.IsLower(c));
        }

        /// <summary>
        /// Determines whether the string contains any upper case character.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains at least one uppercase characters, false otherwise</returns>
        public static bool HasUpper(this string str)
        {
            return str.Any(c => char.IsUpper(c));
        }

        /// <summary>
        /// Determines whether the string contains only alphabetic characters.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains only alphabetic characters, false otherwise</returns>
        public static bool IsAlpha(this string str)
        {
            return str.All(Char.IsLetter);
        }

        /// <summary>
        /// Determines whether the string contains only alphanumeric characters.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains only alphanumeric characters, false otherwise</returns>
        public static bool IsAlphanumeric(this string str)
        {
            return str.All(Char.IsLetterOrDigit);
        }

        /// <summary>
        /// Determines whether the string contains only lowercase characters.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains only lowercase characters, false otherwise</returns>
        public static bool IsLower(this string str)
        {
            return str.All(Char.IsLower);
        }

        /// <summary>
        /// Determines whether the string contains only uppercase characters.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>True if the string contains only uppercase characters, false otherwise</returns>
        public static bool IsUpper(this string str)
        {
            return str.All(Char.IsUpper);
        }

        /// <summary>
        /// Returns the last n characters of this string.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="charactersQuantity">Number of characters to return</param>
        /// <returns>Last n characters of this string</returns>
        public static string LastCharacters(this string str, int charactersQuantity)
        {
            charactersQuantity = charactersQuantity > str.Length ? str.Length : charactersQuantity;

            return str.Substring(Math.Min(str.Length - charactersQuantity, str.Length));
        }

        /// <summary>
        /// Returns a copy of this string in PascalCase version. Trims surrounding 
        /// spaces, capitalizes letters following digits, spaces, dashes and 
        /// underscores, and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String in PascalCase format</returns>
        public static string Pascalize(this string str)
        {
            return str.Camelize().ToUpperFirst();
        }

        /// <summary>
        /// Returns a copy of this string with removed substring from the left side
        /// (if it exists).
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">Substring to remove from left side</param>
        /// <returns>String without substring from left side</returns>
        public static string RemoveLeft(this string str, string substring)
        {
            if (str.StartsWith(substring)) return str.Substring(substring.Length);

            return str;
        }

        /// <summary>
        /// Returns a copy of this string with removed substring from the right side
        /// (if it exists).
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">Substring to remove from right side</param>
        /// <returns>String without substring from right side</returns>
        public static string RemoveRight(this string str, string substring)
        {
            if (str.EndsWith(substring)) return str.Substring(0, str.Length - substring.Length);

            return str;
        }

        /// <summary>
        /// Returns a repeated string.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="multiplier">Number of repetitions</param>
        /// <returns>String repeated by given times</returns>
        public static string Repeat(this string str, int numberOfRepetitions)
        {
            StringBuilder repeatedString = new StringBuilder();

            for (var i = 0; i < numberOfRepetitions; i += 1)
            {
                repeatedString.Append(str);
            }

            return repeatedString.ToString();
        }

        /// <summary>
        /// Returns a copy of this string with shuffled characters.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String with shuffled characters</returns>
        public static string Shuffle(this string str)
        {
	        Random random = new Random();

            return new string(str.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());          
        }

        /// <summary>
        /// Returns a copy of this string surrounded by given substring.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="substring">Substring to prepend and append</param>
        /// <returns>String surrounded by substring</returns>
        public static string Surround(this string instance, string substring)
        {
            return instance.Insert(instance.Length, substring).Insert(0, substring);
        }

        /// <summary>
        /// Returns a copy of this string with swapped case.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String with swapped case</returns>
        public static string SwapCase(this string str)
        {
            var swappedString = new StringBuilder();

            foreach (char c in str)
            {
                swappedString.Append(Char.IsUpper(c) ? Char.ToLower(c) : Char.ToUpper(c));
            }

            return swappedString.ToString();
        }

        /// <summary>
        /// Returns a copy of this string in Title Case version. Capitalizes
        /// first letter of each word unless word is specified in ignored array,
        /// inserts spaces in place of dashes and underscores, trims surrounding 
        /// and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="ignoredWords">Array of word to ignore</param>
        /// <returns>String in Title Case format</returns>
        /// 

        public static string Titleize(this string str, string[] ignoredWords = null)
        {
            ignoredWords = ignoredWords ?? new string[] { };

            string[] chunks = SplitIntoChunks(str.ToLower());
            string[] lowercasedChunks = chunks.Select(s => s.ToLower()).ToArray<string>();

            return string.Join(" ", chunks.Select(s => ignoredWords.Contains(s) ? s : s.ToUpperFirst()));
        }

        /// <summary>
        /// Returns a boolean representation of the given logical string value. True
        /// value is evaluated for "yes", "on", "true" (including uppercase versions)
        /// and all numbers greater than 0. Rest options is evaluated into false.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Boolean representation of string</returns>
        public static bool ToBoolean(this string str)
        {
            int parsedString = 0;
            string[] truthyValues = { "true", "yes", "on" };

            if (string.IsNullOrWhiteSpace(str)) return false;

            if (truthyValues.Any(value => value == str || value.ToUpper() == str)) return true;

            Int32.TryParse(str, out parsedString);
            if (parsedString > 0) return true;

            return false;
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to lowercase.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Equivalent of the current string with first letter in lowercase</returns>
        public static string ToLowerFirst(this string str)
        {
            return (str.Length > 0)
                ? string.Concat(str[0].ToString().ToLower(), str.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to uppercase.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Equivalent of the current string with first letter in uppercase</returns>
        public static string ToUpperFirst(this string str)
        {
            return (str.Length > 0)
                ? string.Concat(str[0].ToString().ToUpper(), str.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns new string, truncated to a given length. If substring is provided, and
        /// truncating occurs, the string is further truncated so that the substring
        /// may be appended without exceeding the desired length.
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="length">Desired length of the truncated string</param>
        /// <param name="substring">The substring to append if it can fit</param>
        /// <returns>New string truncated to given length</returns>
        public static string Truncate(this string str, int length, string substring = "")
        {
            if (length >= str.Length) return str;

            length = length - substring.Length;

            return string.Concat(str.Substring(0, length), substring);
        }

        /// <summary>
        /// Returns a copy of this string in underscore_case version. Trims 
        /// surrounding spaces, dashes and underscores. Underscores are inserted 
        /// before capital letters and in place of spaces and underscores.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String in underscore_case format</returns>
        /// 
        public static string Underscorize(this string instance)
        {
            return Delimit(instance, "_");
        }

        /// <summary>
        /// Splits string into chunks. String is sliced before capital letters
        /// and in place of dashes, underscores and spaces.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Array of strings</returns>
        private static string[] SplitIntoChunks(string str)
        {
            string[] baseDelimiters = new string[] { " ", "_", "-" };
            string instanceWithoutCamelCase = Regex.Replace(str, @"([A-Z])", " $1");

            return instanceWithoutCamelCase.Split(baseDelimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns string joined using given delimiter.
        /// </summary>
        /// <param name="delimiter">Delimiter to place between chunks</param>
        /// <param name="chunks">String chunks to join</param>
        /// <returns>String joined using delimiter</returns>
        private static string JoinUsingDelimiter(string delimiter, string[] chunks)
        {
            string gluedChunks = string.Join(delimiter.ToString(), chunks).Trim().ToLower();
            string escapedDelimiter = Regex.Escape(delimiter);
            string doubleDelimiterPattern = string.Format("{0}+", escapedDelimiter);

            return Regex.Replace(gluedChunks, @doubleDelimiterPattern, delimiter.ToString());
        }
    }
}