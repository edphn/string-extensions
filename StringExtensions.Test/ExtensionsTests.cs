using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensions;

namespace StringExtensions.Test
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void CamelizeWorksProperly()
        {
            Assert.AreEqual("camelCase", "CamelCase".Camelize());
            Assert.AreEqual("camelCase", "Camel-Case".Camelize());
            Assert.AreEqual("camelCase", "camel case".Camelize());
            Assert.AreEqual("camelCase", "camel -case".Camelize());
            Assert.AreEqual("camelCase", "camel - case".Camelize());
            Assert.AreEqual("camelCase", "camel_case".Camelize());
            Assert.AreEqual("camelCTest", "camel c test".Camelize());
            Assert.AreEqual("stringWith1Number", "string_with1number".Camelize());
            Assert.AreEqual("stringWith22Numbers", "string-with-2-2 numbers".Camelize());
            Assert.AreEqual("1Camel2Case", "1camel2case".Camelize());
            Assert.AreEqual("camelΣase", "camel σase".Camelize());
            Assert.AreEqual("στανιλCase", "Στανιλ case".Camelize());
            Assert.AreEqual("σamelCase", "σamel  Case".Camelize());
        }

        [TestMethod]
        public void CollapseWhitespaceWorksProperly()
        {
            Assert.AreEqual("foo bar", "  foo   bar  ".CollapseWhitespace());
            Assert.AreEqual("test string", "test string".CollapseWhitespace());
            Assert.AreEqual("Ο συγγραφέας", "   Ο     συγγραφέας  ".CollapseWhitespace());
            Assert.AreEqual("123", " 123 ".CollapseWhitespace());
            Assert.AreEqual("1 2 3", "　　1　　2　　3　　".CollapseWhitespace());
            Assert.AreEqual("", "   ".CollapseWhitespace());
            Assert.AreEqual("", " ".CollapseWhitespace());
            Assert.AreEqual("", "".CollapseWhitespace());
        }

        [TestMethod]
        public void CountSubstringWorksProperly()
        {
            Assert.AreEqual(0, "".CountSubstring("foo"));
            Assert.AreEqual(0, "foo".CountSubstring("bar"));
            Assert.AreEqual(1, "foo bar".CountSubstring("foo"));
            Assert.AreEqual(2, "foo bar".CountSubstring("o"));
            Assert.AreEqual(0, "".CountSubstring("fòô"));
            Assert.AreEqual(0, "fòô".CountSubstring("bàř"));
            Assert.AreEqual(1, "fòô bàř".CountSubstring("fòô"));
            Assert.AreEqual(2, "fôòô bàř".CountSubstring("ô"));
            Assert.AreEqual(0, "fÔÒÔ bàř".CountSubstring("ô"));
            Assert.AreEqual(0, "foo".CountSubstring("BAR", false));
            Assert.AreEqual(1, "foo bar".CountSubstring("FOo", false));
            Assert.AreEqual(2, "foo bar".CountSubstring("O", false));
            Assert.AreEqual(1, "fòô bàř".CountSubstring("fÒÔ", false));
            Assert.AreEqual(2, "fôòô bàř".CountSubstring("Ô", false));
        }

        [TestMethod]
        public void DasherizeWorksProperly()
        {
        }

        [TestMethod]
        public void EnsureLeftWorksProperly()
        {
            Assert.AreEqual("foobar", "foobar".EnsureLeft("f"));
            Assert.AreEqual("foobar", "foobar".EnsureLeft("foo"));
            Assert.AreEqual("foo/foobar", "foobar".EnsureLeft("foo/"));
            Assert.AreEqual("http://foobar", "foobar".EnsureLeft("http://"));
            Assert.AreEqual("http://foobar", "http://foobar".EnsureLeft("http://"));
            Assert.AreEqual("fòôbàř", "fòôbàř".EnsureLeft("f"));
            Assert.AreEqual("fòôbàř", "fòôbàř".EnsureLeft("fòô"));
            Assert.AreEqual("fòô/fòôbàř", "fòôbàř".EnsureLeft("fòô/"));
            Assert.AreEqual("http://fòôbàř", "fòôbàř".EnsureLeft("http://"));
            Assert.AreEqual("http://fòôbàř", "http://fòôbàř".EnsureLeft("http://"));
        }

        [TestMethod]
        public void EnsureRightWorksProperly()
        {
            Assert.AreEqual("foobar", "foobar".EnsureRight("r"));
            Assert.AreEqual("foobar", "foobar".EnsureRight("bar"));
            Assert.AreEqual("foobar/bar", "foobar".EnsureRight("/bar"));
            Assert.AreEqual("foobar.com/", "foobar".EnsureRight(".com/"));
            Assert.AreEqual("foobar.com/", "foobar.com/".EnsureRight(".com/"));
            Assert.AreEqual("fòôbàř", "fòôbàř".EnsureRight("ř"));
            Assert.AreEqual("fòôbàř", "fòôbàř".EnsureRight("bàř"));
            Assert.AreEqual("fòôbàř/bàř", "fòôbàř".EnsureRight("/bàř"));
            Assert.AreEqual("fòôbàř.com/", "fòôbàř".EnsureRight(".com/"));
            Assert.AreEqual("fòôbàř.com/", "fòôbàř.com/".EnsureRight(".com/"));
        }

        [TestMethod]
        public void HumanizeWorksProperly()
        {

        }

        [TestMethod]
        public void IsAlphaWorksProperly()
        {
            Assert.AreEqual(true, "".IsAlpha());
            Assert.AreEqual(true, "foobar".IsAlpha());
            Assert.AreEqual(false, "foo bar".IsAlpha());
            Assert.AreEqual(false, "foobar2".IsAlpha());
            Assert.AreEqual(true, "fòôbàř".IsAlpha());
            Assert.AreEqual(false, "fòô bàř".IsAlpha());
            Assert.AreEqual(false, "fòôbàř2".IsAlpha());
            Assert.AreEqual(true, "ҠѨњфгШ".IsAlpha());
            Assert.AreEqual(false, "ҠѨњ¨ˆфгШ".IsAlpha());
            Assert.AreEqual(true, "丹尼爾".IsAlpha());
        }

        [TestMethod]
        public void IsAlphanumericWorksProperly()
        {
            Assert.AreEqual(true, "".IsAlphanumeric());
            Assert.AreEqual(true, "foobar1".IsAlphanumeric());
            Assert.AreEqual(false, "foo bar".IsAlphanumeric());
            Assert.AreEqual(false, "foobar2\"".IsAlphanumeric());
            Assert.AreEqual(false, "\nfoobar\n".IsAlphanumeric());
            Assert.AreEqual(true, "fòôbàř1".IsAlphanumeric());
            Assert.AreEqual(false, "fòô bàř".IsAlphanumeric());
            Assert.AreEqual(false, "fòôbàř2\"".IsAlphanumeric());
            Assert.AreEqual(true, "ҠѨњфгШ".IsAlphanumeric());
            Assert.AreEqual(false, "ҠѨњ¨ˆфгШ".IsAlphanumeric());
            Assert.AreEqual(true, "丹尼爾111".IsAlphanumeric());
            Assert.AreEqual(true, "دانيال1".IsAlphanumeric());
            Assert.AreEqual(false, "دانيال1 ".IsAlphanumeric());
        }

        [TestMethod]
        public void IsLowerWorksProperly()
        {
            Assert.AreEqual(true, "".IsLower());
            Assert.AreEqual(true, "foobar".IsLower());
            Assert.AreEqual(false, "foo bar".IsLower());
            Assert.AreEqual(false, "Foobar".IsLower());
            Assert.AreEqual(true, "fòôbàř".IsLower());
            Assert.AreEqual(false, "fòôbàř2".IsLower());
            Assert.AreEqual(false, "fòô bàř".IsLower());
            Assert.AreEqual(false, "fòôbÀŘ".IsLower());
        }

        [TestMethod]
        public void IsUpperWorksProperly()
        {
            Assert.AreEqual(true, "".IsUpper());
            Assert.AreEqual(true, "FOOBAR".IsUpper());
            Assert.AreEqual(false, "FOO BAR".IsUpper());
            Assert.AreEqual(false, "fOOBAR".IsUpper());
            Assert.AreEqual(true, "FÒÔBÀŘ".IsUpper());
            Assert.AreEqual(false, "FÒÔBÀŘ2".IsUpper());
            Assert.AreEqual(false, "FÒÔ BÀŘ".IsUpper());
            Assert.AreEqual(false, "FÒÔBàř".IsUpper());
        }

        [TestMethod]
        public void PascalizeWorksProperly()
        {

        }

        [TestMethod]
        public void SafeTruncateWorksProperly()
        {

        }

        [TestMethod]
        public void ShuffleWorksProperly()
        {
            string one = "foobar";
            string two = " ";

            Assert.AreEqual(one.Shuffle().Length, 6);
            Assert.AreEqual(two.Shuffle().Length, 1);
        }

        [TestMethod]
        public void SlugifyWorksProperly()
        {

        }

        [TestMethod]
        public void SurroundWorksProperly()
        {
            Assert.AreEqual("__foobar__", "foobar".Surround("__"));
            Assert.AreEqual("test", "test".Surround(""));
            Assert.AreEqual("**", "".Surround("*"));
            Assert.AreEqual("¬fòô bàř¬", "fòô bàř".Surround("¬"));
            Assert.AreEqual("ßå∆˚ test ßå∆˚", " test ".Surround("ßå∆˚"));
        }

        [TestMethod]
        public void SwapCaseWorksProperly()
        {
            Assert.AreEqual("TESTcASE", "testCase".SwapCase());
            Assert.AreEqual("tEST-cASE", "Test-Case".SwapCase());
            Assert.AreEqual(" - σASH  cASE", " - Σash  Case".SwapCase());
            Assert.AreEqual("νΤΑΝΙΛ", "Ντανιλ".SwapCase());
        }

        [TestMethod]
        public void TitleizeWorksProperly()
        {

        }

        [TestMethod]
        public void ToLowerFirstWorksProperly()
        {
            Assert.AreEqual("test", "Test".ToLowerFirst());
            Assert.AreEqual("test", "test".ToLowerFirst());
            Assert.AreEqual("1a", "1a".ToLowerFirst());
            Assert.AreEqual("σ test", "Σ test".ToLowerFirst());
            Assert.AreEqual(" Σ test", " Σ test".ToLowerFirst());
            Assert.AreEqual("", "".ToLowerFirst());
            Assert.AreEqual("a", "A".ToLowerFirst());
        }

        [TestMethod]
        public void ToUpperFirstWorksProperly()
        {
            Assert.AreEqual("Test", "Test".ToUpperFirst());
            Assert.AreEqual("Test", "test".ToUpperFirst());
            Assert.AreEqual("1a", "1a".ToUpperFirst());
            Assert.AreEqual("Σ test", "σ test".ToUpperFirst());
            Assert.AreEqual(" σ test", " σ test".ToUpperFirst());
            Assert.AreEqual("", "".ToUpperFirst());
            Assert.AreEqual("A", "a".ToUpperFirst());
        }

        [TestMethod]
        public void TruncateWorksProperly()
        {
            Assert.AreEqual("Test foo bar", "Test foo bar".Truncate(12));
            Assert.AreEqual("Test foo ba", "Test foo bar".Truncate(11));
            Assert.AreEqual("Test foo", "Test foo bar".Truncate(8));
            Assert.AreEqual("Test fo", "Test foo bar".Truncate(7));
            Assert.AreEqual("Test", "Test foo bar".Truncate(4));
            Assert.AreEqual("Test foo bar", "Test foo bar".Truncate(12, "..."));
            Assert.AreEqual("Test foo...", "Test foo bar".Truncate(11, "..."));
            Assert.AreEqual("Test ...", "Test foo bar".Truncate(8, "..."));
            Assert.AreEqual("Test...", "Test foo bar".Truncate(7, "..."));
            Assert.AreEqual("T...", "Test foo bar".Truncate(4, "..."));
            Assert.AreEqual("Test fo....", "Test foo bar".Truncate(11, "...."));        
        }
        
        [TestMethod]
        public void UnderscorizeWorksProperly()
        {
        
        }
    }
}