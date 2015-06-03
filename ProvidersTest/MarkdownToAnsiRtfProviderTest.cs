using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Providers.FormatProviders;

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
            const string input = "";
            const string expected = @"{\rtf\ansi }";
            var provider = new MarkdownToAnsiRtfProvider();

            // Run conversion
            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringConvertsText()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "Hello I am Bob.";
            const string expected = @"{\rtf\ansi Hello I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringIgnoresInsignificantWhitespace()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "Hello \nI \t  am   Bob.";
            const string expected = @"{\rtf\ansi Hello I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringCorrectlyInsertsParagraphsForSignificantWhiteSpace()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "Hello.\n\nI \t  am   Bob.";
            const string expected = @"{\rtf\ansi Hello.\par I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringCorrectlyInsertsParagraphsWhenNewLinesAreSeparatedByWhiteSpace()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "Hello.\n  \t \nI \t  am   Bob.";
            const string expected = @"{\rtf\ansi Hello.\par I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringCorrectlyInsertsItalics()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "Hello. **I am** Bob.";
            const string expected = @"{\rtf\ansi Hello. \i I am\i0  Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringHandlesMissingItalicsClose()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "**Hello**. **I am Bob.";
            const string expected = @"{\rtf\ansi \i Hello\i0 . \i I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringCorrectlyInsertsBold()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "*Hello*. I am Bob.";
            const string expected = @"{\rtf\ansi \b Hello\b0 . I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringHandlesMissingBoldClose()
        {
            // Bob is a proper noun and should be capitalized
            const string input = "*Hello*. I am *Bob.";
            const string expected = @"{\rtf\ansi \b Hello\b0 . I am \b Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRtfFromStringEscapesBackslashes()
        {
            const string input = @"Hello\Hi. I am Bob.";
            const string expected = @"{\rtf\ansi Hello\\Hi. I am Bob.}";
            var provider = new MarkdownToAnsiRtfProvider();

            var actual = provider.GetRtfFromString(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
