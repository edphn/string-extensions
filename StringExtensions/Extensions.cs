using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class Extensions
    {
        public static char At(this string instance, int index)
        {
            return instance[index];
        }

        public static string Camelize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string CollapseWhitespace(this string instance)
        {
            throw new NotImplementedException();
        }

        public static int CountSubstring(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string Dasherize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static string EnsureLeft(this string instance, string prefix)
        {
            if (!instance.StartsWith(prefix)) return instance.Insert(0, prefix);

            return instance;
        }

        public static string EnsureRight(this string instance, string suffix)
        {
            if (!instance.EndsWith(suffix)) return instance.Insert(instance.Length, suffix);

            return instance;
        }

        public static string Humanize(this string instance)
        {
            throw new NotImplementedException();
        }

        public static bool IsAlpha(this string instance)
        {
            throw new NotImplementedException();
        }

        public static bool IsAlphanumeric(this string instance)
        {
            throw new NotImplementedException();
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
            // What with spaces at the beginning and numbers for instance.
            return Char.ToLowerInvariant(instance[0]).ToString() + instance.Substring(1);
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

        public static string Surround(this string instance)
        {
            throw new NotImplementedException();
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

        public static string Truncate(this string instance)
        {
            throw new NotImplementedException();
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