using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        [TestMethod]
        public void CollapseWhitespaceWorksProperly()
        {
            Assert.AreEqual("foo bar", "  foo   bar  ".CollapseWhitespace());
            Assert.AreEqual("test string", "test string".CollapseWhitespace());
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
            Assert.AreEqual(0, "foo".CountSubstring("BAR", false));
            Assert.AreEqual(1, "foo bar".CountSubstring("FOo", false));
            Assert.AreEqual(2, "foo bar".CountSubstring("O", false));
        }

        [TestMethod]
        public void DasherizeWorksProperly()
        {
            Assert.AreEqual("test-case", "testCase".Dasherize());
            Assert.AreEqual("test-case", "Test-Case".Dasherize());
            Assert.AreEqual("test-case", "test case".Dasherize());
            Assert.AreEqual("test-case", "-test -case".Dasherize());
            Assert.AreEqual("test-case", "test - case".Dasherize());
            Assert.AreEqual("test-case", "test_case".Dasherize());
            Assert.AreEqual("test-c-test", "test c test".Dasherize());
            Assert.AreEqual("test-d-case", "TestDCase".Dasherize());
            Assert.AreEqual("test-c-c-test", "TestCCTest".Dasherize());
            Assert.AreEqual("string-with1number", "string_with1number".Dasherize());
            Assert.AreEqual("string-with-2-2-numbers", "String-with_2_2 numbers".Dasherize());
            Assert.AreEqual("1test2case", "1test2case".Dasherize());
        }

        [TestMethod]
        public void DelimitWorksProperly()
        {
            Assert.AreEqual("test*case", "testCase".Delimit("*"));
            Assert.AreEqual("test&case", "Test-Case".Delimit("&"));
            Assert.AreEqual("test#case", "test case".Delimit("#"));
            Assert.AreEqual("test**case", "test -case".Delimit("**"));
            Assert.AreEqual("test~!~case", "-test - case".Delimit("~!~"));
            Assert.AreEqual("test*case", "test_case".Delimit("*"));
            Assert.AreEqual("test%c%test", "  test c test".Delimit("%"));
            Assert.AreEqual("test+u+case", "TestUCase".Delimit("+"));
            Assert.AreEqual("test=c=c=test", "TestCCTest".Delimit("="));
            Assert.AreEqual("string#>with1number", "string_with1number".Delimit("#>"));
            Assert.AreEqual("1test2case", "1test2case".Delimit("*"));

        }

        [TestMethod]
        public void EnsureLeftWorksProperly()
        {
            Assert.AreEqual("foobar", "foobar".EnsureLeft("f"));
            Assert.AreEqual("foobar", "foobar".EnsureLeft("foo"));
            Assert.AreEqual("foo/foobar", "foobar".EnsureLeft("foo/"));
            Assert.AreEqual("http://foobar", "foobar".EnsureLeft("http://"));
            Assert.AreEqual("http://foobar", "http://foobar".EnsureLeft("http://"));
        }

        [TestMethod]
        public void EnsureRightWorksProperly()
        {
            Assert.AreEqual("foobar", "foobar".EnsureRight("r"));
            Assert.AreEqual("foobar", "foobar".EnsureRight("bar"));
            Assert.AreEqual("foobar/bar", "foobar".EnsureRight("/bar"));
            Assert.AreEqual("foobar.com/", "foobar".EnsureRight(".com/"));
            Assert.AreEqual("foobar.com/", "foobar.com/".EnsureRight(".com/"));
        }

        [TestMethod]
        public void FirstCharactersWorksProperly()
        {
            Assert.AreEqual("", "foo bar".FirstCharacters(-5));
            Assert.AreEqual("", "foo bar".FirstCharacters(0));
            Assert.AreEqual("f", "foo bar".FirstCharacters(1));
            Assert.AreEqual("foo", "foo bar".FirstCharacters(3));
            Assert.AreEqual("foo bar", "foo bar".FirstCharacters(7));
            Assert.AreEqual("foo bar", "foo bar".FirstCharacters(8));
        }

        [TestMethod]
        public void HasLowerWorksProperly()
        {
            Assert.IsFalse("".HasLower());
            Assert.IsTrue("foobar".HasLower());
            Assert.IsFalse("FOO BAR".HasLower());
            Assert.IsTrue("fOO BAR".HasLower());
            Assert.IsTrue("foO BAR".HasLower());
            Assert.IsTrue("FOO BAr".HasLower());
            Assert.IsTrue("Foobar".HasLower());
        }

        [TestMethod]
        public void HasUpperWorksProperly()
        {
            Assert.IsFalse("".HasUpper());
            Assert.IsTrue("FOOBAR".HasUpper());
            Assert.IsFalse("foo bar".HasUpper());
            Assert.IsTrue("Foo bar".HasUpper());
            Assert.IsTrue("FOo bar".HasUpper());
            Assert.IsTrue("foo baR".HasUpper());
            Assert.IsTrue("fOOBAR".HasUpper());
        }

        [TestMethod]
        public void IsAlphaWorksProperly()
        {
            Assert.IsTrue("".IsAlpha());
            Assert.IsTrue("foobar".IsAlpha());
            Assert.IsFalse("foo bar".IsAlpha());
            Assert.IsFalse("foobar2".IsAlpha());
            Assert.IsTrue("fòôbàř".IsAlpha());
            Assert.IsFalse("fòô bàř".IsAlpha());
            Assert.IsFalse("fòôbàř2".IsAlpha());
            Assert.IsTrue("ҠѨњфгШ".IsAlpha());
            Assert.IsFalse("ҠѨњ¨ˆфгШ".IsAlpha());
            Assert.IsTrue("丹尼爾".IsAlpha());
        }

        [TestMethod]
        public void IsAlphanumericWorksProperly()
        {
            Assert.IsTrue("".IsAlphanumeric());
            Assert.IsTrue("foobar1".IsAlphanumeric());
            Assert.IsFalse("foo bar".IsAlphanumeric());
            Assert.IsFalse("foobar2\"".IsAlphanumeric());
            Assert.IsFalse("\nfoobar\n".IsAlphanumeric());
        }

        [TestMethod]
        public void IsLowerWorksProperly()
        {
            Assert.IsTrue("".IsLower());
            Assert.IsTrue("foobar".IsLower());
            Assert.IsFalse("foo bar".IsLower());
            Assert.IsFalse("Foobar".IsLower());
        }

        [TestMethod]
        public void IsUpperWorksProperly()
        {
            Assert.IsTrue("".IsUpper());
            Assert.IsTrue("FOOBAR".IsUpper());
            Assert.IsFalse("FOO BAR".IsUpper());
            Assert.IsFalse("fOOBAR".IsUpper());
        }

        [TestMethod]
        public void LastCharactersWorksProperly()
        {
            Assert.AreEqual("", "foo bar".LastCharacters(-5));
            Assert.AreEqual("", "foo bar".LastCharacters(0));
            Assert.AreEqual("r", "foo bar".LastCharacters(1));
            Assert.AreEqual("bar", "foo bar".LastCharacters(3));
            Assert.AreEqual("foo bar", "foo bar".LastCharacters(7));
            Assert.AreEqual("foo bar", "foo bar".LastCharacters(8));
        }

        [TestMethod]
        public void PascalizeWorksProperly()
        {
            Assert.AreEqual("CamelCase", "camelCase".Pascalize());
            Assert.AreEqual("CamelCase", "Camel-Case".Pascalize());
            Assert.AreEqual("CamelCase", "camel case".Pascalize());
            Assert.AreEqual("CamelCase", "camel -case".Pascalize());
            Assert.AreEqual("CamelCase", "camel - case".Pascalize());
            Assert.AreEqual("CamelCase", "camel_case".Pascalize());
            Assert.AreEqual("CamelCTest", "camel c test".Pascalize());
            Assert.AreEqual("StringWith1Number", "string_with1number".Pascalize());
            Assert.AreEqual("StringWith22Numbers", "string-with-2-2 numbers".Pascalize());
        }

        [TestMethod]
        public void RemoveLeftWorksProperly()
        {
            Assert.AreEqual("foo bar", "foo bar".RemoveLeft(""));
            Assert.AreEqual("oo bar", "foo bar".RemoveLeft("f"));
            Assert.AreEqual("bar", "foo bar".RemoveLeft("foo "));
            Assert.AreEqual("foo bar", "foo bar".RemoveLeft("oo"));
            Assert.AreEqual("foo bar", "foo bar".RemoveLeft("oo bar"));
        }

        [TestMethod]
        public void RemoveRightWorksProperly()
        {
            Assert.AreEqual("foo bar", "foo bar".RemoveRight(""));
            Assert.AreEqual("foo ba", "foo bar".RemoveRight("r"));
            Assert.AreEqual("foo", "foo bar".RemoveRight(" bar"));
            Assert.AreEqual("foo bar", "foo bar".RemoveRight("ba"));
            Assert.AreEqual("foo bar", "foo bar".RemoveRight("foo ba"));
        }

        [TestMethod]
        public void RepeatWorksProperly()
        {
            Assert.AreEqual("", "foo".Repeat(0));
            Assert.AreEqual("foo", "foo".Repeat(1));
            Assert.AreEqual("foofoo", "foo".Repeat(2));
            Assert.AreEqual("foofoofoo", "foo".Repeat(3));
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
        public void SurroundWorksProperly()
        {
            Assert.AreEqual("__foobar__", "foobar".Surround("__"));
            Assert.AreEqual("test", "test".Surround(""));
            Assert.AreEqual("**", "".Surround("*"));
        }

        [TestMethod]
        public void SwapCaseWorksProperly()
        {
            Assert.AreEqual("TESTcASE", "testCase".SwapCase());
            Assert.AreEqual("tEST-cASE", "Test-Case".SwapCase());
        }

        [TestMethod]
        public void TitleizeWorksProperly()
        {
            Assert.AreEqual("Title Case", "TITLE CASE".Titleize());
            Assert.AreEqual("Testing The Method", "testing the method".Titleize());
            Assert.AreEqual("Testing the Method", "testing the method".Titleize(new[] { "the" }));
            Assert.AreEqual("I Like to Watch Dvds at Home", "i like to watch DVDs at home".Titleize(new[] { "to", "at" }));
            Assert.AreEqual("Foo Bar", "foo bar".Titleize());
            Assert.AreEqual("Foo Bar", " foo_bar ".Titleize());
        }

        [TestMethod]
        public void ToBooleanWorksProperly()
        {
            Assert.IsTrue("true".ToBoolean());
            Assert.IsTrue("1".ToBoolean());
            Assert.IsTrue("on".ToBoolean());
            Assert.IsTrue("ON".ToBoolean());
            Assert.IsTrue("yes".ToBoolean());
            Assert.IsTrue("999".ToBoolean());
            Assert.IsFalse("false".ToBoolean());
            Assert.IsFalse("0".ToBoolean());
            Assert.IsFalse("off".ToBoolean());
            Assert.IsFalse("OFF".ToBoolean());
            Assert.IsFalse("no".ToBoolean());
            Assert.IsFalse("-999".ToBoolean());
            Assert.IsFalse("".ToBoolean());
            Assert.IsFalse(" ".ToBoolean());
            Assert.IsFalse("  ".ToBoolean());
        }

        [TestMethod]
        public void ToLowerFirstWorksProperly()
        {
            Assert.AreEqual("test", "Test".ToLowerFirst());
            Assert.AreEqual("test", "test".ToLowerFirst());
            Assert.AreEqual("1a", "1a".ToLowerFirst());
            Assert.AreEqual("", "".ToLowerFirst());
            Assert.AreEqual("a", "A".ToLowerFirst());
        }

        [TestMethod]
        public void ToUpperFirstWorksProperly()
        {
            Assert.AreEqual("Test", "Test".ToUpperFirst());
            Assert.AreEqual("Test", "test".ToUpperFirst());
            Assert.AreEqual("1a", "1a".ToUpperFirst());
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
            Assert.AreEqual("test_case", "testCase".Underscorize());
            Assert.AreEqual("test_case", "Test-Case".Underscorize());
            Assert.AreEqual("test_case", "test case".Underscorize());
            Assert.AreEqual("test_case", "test -case".Underscorize());
            Assert.AreEqual("test_case", "-test - case".Underscorize());
            Assert.AreEqual("test_case", "test_case".Underscorize());
            Assert.AreEqual("test_c_test", "  test c test".Underscorize());
            Assert.AreEqual("test_u_case", "TestUCase".Underscorize());
            Assert.AreEqual("test_c_c_test", "TestCCTest".Underscorize());
            Assert.AreEqual("string_with1number", "string_with1number".Underscorize());
            Assert.AreEqual("string_with_2_2_numbers", "String-with_2_2 numbers".Underscorize());
            Assert.AreEqual("1test2case", "1test2case".Underscorize());
        }
    }
}