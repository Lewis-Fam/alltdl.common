namespace alltdl.Utils;

/// <summary>
/// The string helper.
/// </summary>
public static class StringHelper
{
    public static bool StartsWithUpper(this string s)
    {
        return !string.IsNullOrWhiteSpace(s) && char.IsUpper(s[0]);
    }

    public static bool StartsWithLower(this string s)
    {
        return !string.IsNullOrWhiteSpace(s) && char.IsLower(s[0]);
    }

    public static bool HasEmbeddedSpaces(this string s)
    {
        return s.Trim().Any(ch => ch == ' ');
    }
}