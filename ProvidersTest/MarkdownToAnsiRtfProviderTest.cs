using System;
using Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProvidersTest
{
    /// <summary>
    /// Test Class for the MarkdownToRtfProvider
    /// </summary>
    [TestClass]
    public class MarkdownToAnsiRtfProviderTest
    {
        /// <summary>
        /// Tests that an the provider adds the correct wrapping to an empty
        /// string
        /// </summary>
        [TestMethod]
        public void GetRtfFromStringConvertsEmptyString()
        {
            // Setup inputs and expectations
            const String input = "";
            const String expected = @"{\rtf\ansi }";
            var provider = new MarkdownToAnsiRtfProvider();

            // Run conversion
            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringConvertsText()
        {
            // Bob is a proper noun and should be capitalized
            const String input = "Hello I am Bob.";
            const String expected = @"{\rtf\ansi Hello I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringIgnoresInsignificantWhitespace()
        {
            // Bob is a proper noun and should be capitalized
            const String input = "Hello \nI \t  am   Bob.";
            const String expected = @"{\rtf\ansi Hello I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringCorrectlyInsertsParagraphsForSignificantWhiteSpace()
        {
            // Bob is a proper noun and should be capitalized
            const String input = "Hello.\n\nI \t  am   Bob.";
            const String expected = @"{\rtf\ansi Hello. \par I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
