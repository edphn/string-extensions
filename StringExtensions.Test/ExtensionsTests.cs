using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensions;

namespace StringExtensions.Test
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void CountSubstringWorksProperly()
        {
            Assert.AreEqual(2, "foobarfoobar".CountSubstring("foo"));
            Assert.AreEqual(0, "foo".CountSubstring("bar"));
            Assert.AreEqual(1, "foo".CountSubstring("FOO", false));
            Assert.AreNotEqual(1, "foo".CountSubstring("FOO"));
        }

        [TestMethod]
        public void EnsureLeftWorksProperly()
        {
            Assert.AreEqual("foobar", "foobar".EnsureLeft("foo"));
            Assert.AreEqual("www.foobar", "foobar".EnsureLeft("www."));
        }

        [TestMethod]
        public void EnsureRightWorksProperly()
        {
            Assert.AreEqual("acme.com", "acme".EnsureRight(".com"));
            Assert.AreEqual("acme.com", "acme.com".EnsureRight(".com"));
        }

        [TestMethod]
        public void IsAlphaWorksProperly()
        {
            Assert.IsTrue("foobar".IsAlpha());
            Assert.IsFalse("12foobar".IsAlpha());
            Assert.IsFalse("f-oobar".IsAlpha());
        }

        [TestMethod]
        public void IsAlphanumericWorksProperly()
        {
            Assert.IsTrue("foobar123".IsAlphanumeric());
            Assert.IsFalse("foobar-123".IsAlphanumeric());
        }

        [TestMethod]
        public void SurroundWorksProperly()
        {
            Assert.AreEqual("__foobar__", "foobar".Surround("__"));
            Assert.AreEqual("__", "".Surround("_"));
            Assert.AreEqual("test", "test".Surround(""));
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
    }
}