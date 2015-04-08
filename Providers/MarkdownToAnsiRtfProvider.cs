using System;
using System.Text.RegularExpressions;

namespace Providers
{
    public class MarkdownToAnsiRtfProvider
        : IRtfProvider
    {
        /// <summary>
        /// Converts from Markdown to RTF
        /// </summary>
        /// <param name="input">A markdown string</param>
        /// <returns>Its RTF equivilent</returns>
        public String GetRtfFromString(string input)
        {
            input = ReplaceSignificantWhitespace(input);
            input = RemoveInsignificantWhitespaceFromString(input);

            input = AddFormatting(input);

            var output = String.Concat(@"{\rtf\ansi ", input, "}");
            return output;
        }

        private static string AddFormatting(string input)
        {
            var italicsRegex = new Regex(@"\*\*");
            var boldRegex = new Regex(@"\*");
            input = AddFormatting(input, italicsRegex, @"\i");
            return AddFormatting(input, boldRegex, @"\b");
        }

        private static string AddFormatting(string input, Regex italicsRegex, string formatOption)
        {
            while (italicsRegex.IsMatch(input))
            {
                // Add opening italics mark
                input = italicsRegex.Replace(input, String.Concat(formatOption, " "), 1);

                // Disable on the next occurance of a match
                input = italicsRegex.Replace(input, String.Concat(formatOption, "0 "), 1);
            }

            return input;
        }

        private static string ReplaceSignificantWhitespace(string input)
        {
            // Significant whitespace is 2 or more new lines
            var whitespaceRegex = new Regex(@"(\n){2,}");

            if (whitespaceRegex.IsMatch(input))
            {
                // Replace any Group of whitespace characters with a single space
                return whitespaceRegex.Replace(input, @"\par ");
            }

            return input;
        }

        private static string RemoveInsignificantWhitespaceFromString(string input)
        {
            var whitespaceRegex = new Regex(@"\s{2,}");

            if (whitespaceRegex.IsMatch(input))
            {
                // Replace any Group of whitespace characters with a single space
                return whitespaceRegex.Replace(input, " ");
            }

            return input;
        }
    }
}
