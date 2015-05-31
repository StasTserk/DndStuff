namespace Providers.FormatProviders
{
    public interface IRtfProvider
    {
        /// <summary>
        /// Gets the associated RTF string for the provided input
        /// </summary>
        /// <param name="input">The string to convert to RTF</param>
        /// <returns>The RTF representation of the input string</returns>
        string GetRtfFromString(string input);

        string GetRtfFromString(string input, int textSize);
    }
}