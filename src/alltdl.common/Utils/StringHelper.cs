using alltdl.Constants;

using System.Linq;
using System.Text.RegularExpressions;

namespace alltdl.Utils
{
    /// <summary>
    /// The string helper.
    /// </summary>
    public static class StringHelper
    {
        public static bool HasEmbeddedSpaces(this string s)
        {
            return s.Trim().Any(ch => ch == ' ');
        }

        public static bool IsValidUrl(string url)
        {
            var rgx = new Regex(RegexPattern.Url, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rgx.IsMatch(url);
        }

        /// <summary>
        /// Checks if a string start with a lower case.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static bool StartsWithLower(this string s)
        {
            return !string.IsNullOrWhiteSpace(s) && char.IsLower(s[0]);
        }

        /// <summary>
        /// Checks if a string starts with an upper case.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static bool StartsWithUpper(this string s)
        {
            return !string.IsNullOrWhiteSpace(s) && char.IsUpper(s[0]);
        }
    }
}