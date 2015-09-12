using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Returns a copy of this string in camelCase version. Trims surrounding 
        /// spaces, capitalizes letters following digits, spaces, dashes and 
        /// underscores, and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String in camelCase format</returns>
        public static string Camelize(this string source)
        {
            string[] chunks = SplitIntoChunks(source);
            string camelizedString = string.Join(string.Empty, chunks.Select(x => x.ToUpperFirst())).ToLowerFirst();

            return Regex.Replace(camelizedString, @"[\d]+(.)?", c => c.ToString().ToUpper()).ToLowerFirst();
        }

        /// <summary>
        /// Returns new trimmed string with replaced consecutive whitespace 
        /// characters with a single space (including tabs and newline characters).
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Trimmed string with condensed whitespace</returns>
        public static string CollapseWhitespace(this string source)
        {
            return Regex.Replace(source.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Counts occurencies of given substring.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">The substring to search for</param>
        /// <param name="caseSensitive">Whether or not to enforce case-sensitivity</param>
        /// <returns>The number of substring occurencies</returns>
        public static int CountSubstring(this string source, string substring, bool caseSensitive = true)
        {
            return Regex.Matches(source, substring, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        /// Returns a copy of this string in dash-case version. Trims surrounding 
        /// spaces, dashes and underscores. Dashes are inserted before capital 
        /// letters and in place of spaces and underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String in dash-case format</returns>
        public static string Dasherize(this string source)
        {
            return Delimit(source, "-");
        }

        /// <summary>
        /// Returns a copy of this string delimited by given delimiter. Trims 
        /// surrounding spaces, dashes and underscores. Delimiters are inserted
        /// before capital letters and in place of spaces, dashes and underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="delimiter">String used as delimiter</param>
        /// <returns>String delimited by given delimiter</returns>
        public static string Delimit(this string source, string delimiter)
        {
            string[] chunks = SplitIntoChunks(source);

            return JoinUsingDelimiter(delimiter, chunks);
        }

        /// <summary>
        /// Ensures that the string begins with given substring. If it does not, 
        /// then returns a new string in which a specified string is inserted at 
        /// the very first position.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">The substring to add if not present</param>
        /// <returns>String prefixed by the substring</returns>
        public static string EnsureLeft(this string source, string substring)
        {
            return !source.StartsWith(substring) ? source.Insert(0, substring) : source;
        }

        /// <summary>
        /// Ensures that the string ends with given substring. If it does not, 
        /// then returns a new string in which a specified string is inserted at 
        /// the very last position.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">The substring to add if not present</param>
        /// <returns>String suffixed by the substring.</returns>
        public static string EnsureRight(this string source, string substring)
        {
            return !source.EndsWith(substring) ? source.Insert(source.Length, substring) : source;
        }

        /// <summary>
        /// Returns the first n characters of this string.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="numberOfCharacters">Number of characters to return</param>
        /// <returns>First n characters of this string</returns>
        public static string FirstCharacters(this string source, int numberOfCharacters)
        {
            return source.Substring(0, Math.Min(source.Length, numberOfCharacters < 0 ? 0 : numberOfCharacters));
        }

        /// <summary>
        /// Determines whether the string contains any lowercase character.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains at least one lowercase characters, false otherwise</returns>
        public static bool HasLower(this string source)
        {
            return source.Any(char.IsLower);
        }

        /// <summary>
        /// Determines whether the string contains any upper case character.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains at least one uppercase characters, false otherwise</returns>
        public static bool HasUpper(this string source)
        {
            return source.Any(char.IsUpper);
        }

        /// <summary>
        /// Determines whether the string contains only alphabetic characters.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains only alphabetic characters, false otherwise</returns>
        public static bool IsAlpha(this string source)
        {
            return source.All(char.IsLetter);
        }

        /// <summary>
        /// Determines whether the string contains only alphanumeric characters.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains only alphanumeric characters, false otherwise</returns>
        public static bool IsAlphanumeric(this string source)
        {
            return source.All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Determines whether the string contains only lowercase characters.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains only lowercase characters, false otherwise</returns>
        public static bool IsLower(this string source)
        {
            return source.All(char.IsLower);
        }

        /// <summary>
        /// Determines whether the string contains only uppercase characters.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>True if the string contains only uppercase characters, false otherwise</returns>
        public static bool IsUpper(this string source)
        {
            return source.All(char.IsUpper);
        }

        /// <summary>
        /// Returns the last n characters of this string.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="charactersQuantity">Number of characters to return</param>
        /// <returns>Last n characters of this string</returns>
        public static string LastCharacters(this string source, int charactersQuantity)
        {
            charactersQuantity = charactersQuantity > source.Length ? source.Length : charactersQuantity;

            return source.Substring(Math.Min(source.Length - charactersQuantity, source.Length));
        }

        /// <summary>
        /// Returns a copy of this string in PascalCase version. Trims surrounding 
        /// spaces, capitalizes letters following digits, spaces, dashes and 
        /// underscores, and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String in PascalCase format</returns>
        public static string Pascalize(this string source)
        {
            return source.Camelize().ToUpperFirst();
        }

        /// <summary>
        /// Returns a copy of this string with removed substring from the left side
        /// (if it exists).
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">Substring to remove from left side</param>
        /// <returns>String without substring from left side</returns>
        public static string RemoveLeft(this string source, string substring)
        {
            return source.StartsWith(substring) ? source.Substring(substring.Length) : source;
        }

        /// <summary>
        /// Returns a copy of this string with removed substring from the right side
        /// (if it exists).
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">Substring to remove from right side</param>
        /// <returns>String without substring from right side</returns>
        public static string RemoveRight(this string source, string substring)
        {
            return source.EndsWith(substring) ? source.Substring(0, source.Length - substring.Length) : source;
        }

        /// <summary>
        /// Returns a repeated string.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="numberOfRepetitions">Number of repetitions</param>
        /// <returns>String repeated by given times</returns>
        public static string Repeat(this string source, int numberOfRepetitions)
        {
            var repeatedString = new StringBuilder();

            for (var i = 0; i < numberOfRepetitions; i += 1)
            {
                repeatedString.Append(source);
            }

            return repeatedString.ToString();
        }

        /// <summary>
        /// Returns a copy of this string with shuffled characters.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String with shuffled characters</returns>
        public static string Shuffle(this string source)
        {
	        var random = new Random();

            return new string(source.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());          
        }

        /// <summary>
        /// Returns a copy of this string surrounded by given substring.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="substring">Substring to prepend and append</param>
        /// <returns>String surrounded by substring</returns>
        public static string Surround(this string source, string substring)
        {
            return source.Insert(source.Length, substring).Insert(0, substring);
        }

        /// <summary>
        /// Returns a copy of this string with swapped case.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String with swapped case</returns>
        public static string SwapCase(this string source)
        {
            var swappedString = new StringBuilder();

            foreach (var c in source)
            {
                swappedString.Append(char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c));
            }

            return swappedString.ToString();
        }

        /// <summary>
        /// Returns a copy of this string in Title Case version. Capitalizes
        /// first letter of each word unless word is specified in ignored array,
        /// inserts spaces in place of dashes and underscores, trims surrounding 
        /// and removes spaces, dashes, as well as underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="ignoredWords">Array of word to ignore</param>
        /// <returns>String in Title Case format</returns>
        /// 

        public static string Titleize(this string source, string[] ignoredWords = null)
        {
            ignoredWords = ignoredWords ?? new string[] { };

            var chunks = SplitIntoChunks(source.ToLower());

            return string.Join(" ", chunks.Select(s => ignoredWords.Contains(s) ? s : s.ToUpperFirst()));
        }

        /// <summary>
        /// Returns a boolean representation of the given logical string value. True
        /// value is evaluated for "yes", "on", "true" (including uppercase versions)
        /// and all numbers greater than 0. Rest options is evaluated into false.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Boolean representation of string</returns>
        public static bool ToBoolean(this string source)
        {
            int parsedString;
            string[] truthyValues = { "true", "yes", "on" };

            if (string.IsNullOrWhiteSpace(source)) return false;

            if (truthyValues.Any(value => value == source || value.ToUpper() == source)) return true;

            int.TryParse(source, out parsedString);

            return parsedString > 0;
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to lowercase.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Equivalent of the current string with first letter in lowercase</returns>
        public static string ToLowerFirst(this string source)
        {
            return (source.Length > 0)
                ? string.Concat(source[0].ToString().ToLower(), source.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns a copy of this string with first character converted to uppercase.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Equivalent of the current string with first letter in uppercase</returns>
        public static string ToUpperFirst(this string source)
        {
            return (source.Length > 0)
                ? string.Concat(source[0].ToString().ToUpper(), source.Substring(1))
                : string.Empty;
        }

        /// <summary>
        /// Returns new string, truncated to a given length. If substring is provided, and
        /// truncating occurs, the string is further truncated so that the substring
        /// may be appended without exceeding the desired length.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="length">Desired length of the truncated string</param>
        /// <param name="substring">The substring to append if it can fit</param>
        /// <returns>New string truncated to given length</returns>
        public static string Truncate(this string source, int length, string substring = "")
        {
            if (length >= source.Length) return source;

            length = length - substring.Length;

            return string.Concat(source.Substring(0, length), substring);
        }

        /// <summary>
        /// Returns a copy of this string in underscore_case version. Trims 
        /// surrounding spaces, dashes and underscores. Underscores are inserted 
        /// before capital letters and in place of spaces and underscores.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>String in underscore_case format</returns>
        /// 
        public static string Underscorize(this string source)
        {
            return Delimit(source, "_");
        }

        /// <summary>
        /// Splits string into chunks. String is sliced before capital letters
        /// and in place of dashes, underscores and spaces.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Array of strings</returns>
        private static string[] SplitIntoChunks(string source)
        {
            var baseDelimiters = new[] { " ", "_", "-" };
            var sourceWithoutCamelCase = Regex.Replace(source, @"([A-Z])", " $1");

            return sourceWithoutCamelCase.Split(baseDelimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns string joined using given delimiter.
        /// </summary>
        /// <param name="delimiter">Delimiter to place between chunks</param>
        /// <param name="chunks">String chunks to join</param>
        /// <returns>String joined using delimiter</returns>
        private static string JoinUsingDelimiter(string delimiter, string[] chunks)
        {
            var gluedChunks = string.Join(delimiter, chunks).Trim().ToLower();
            var escapedDelimiter = Regex.Escape(delimiter);
            var doubleDelimiterPattern = string.Format("{0}+", escapedDelimiter);

            return Regex.Replace(gluedChunks, @doubleDelimiterPattern, delimiter);
        }
    }
}