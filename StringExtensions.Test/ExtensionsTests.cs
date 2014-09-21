using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensions;

namespace StringExtensions.Test
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void EnsureLeftWorksProperly()
        {
            Assert.AreEqual("www.acme.com", "acme.com".EnsureLeft("www."));
            Assert.AreEqual("www.acme.com", "www.acme.com".EnsureLeft("www."));
        }

        [TestMethod]
        public void EnsureRightWorksProperly()
        {
            Assert.AreEqual("acme.com", "acme".EnsureRight(".com"));
            Assert.AreEqual("acme.com", "acme.com".EnsureRight(".com"));
            Assert.AreEqual("acme.com", "acme.com".EnsureRight(".com"));
        }

        [TestMethod]
        public void LowerCaseFirstWorksProperly()
        {
            Assert.AreEqual("test", "test".LowerCaseFirst());
            Assert.AreEqual("test", "Test".LowerCaseFirst());
            Assert.AreEqual("1test", "1test".LowerCaseFirst());
        }
    }
}