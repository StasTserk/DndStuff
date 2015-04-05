using System;

namespace Providers
{
    public interface IRtfProvider
    {
        /// <summary>
        /// Gets the associated RTF string for the provided input
        /// </summary>
        /// <param name="input">The string to convert to RTF</param>
        /// <returns>The RTF representation of the input string</returns>
        String GetRtfFromString(String input);
    }
}