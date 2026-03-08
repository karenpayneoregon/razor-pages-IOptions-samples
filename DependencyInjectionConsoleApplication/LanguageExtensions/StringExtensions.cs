using System.Text.RegularExpressions;

namespace DependencyInjectionConsoleApplication.LanguageExtensions;

public static partial class StringExtensions
{

    /// <summary>
    /// Use to split on uppercased characters and separate with a single space.
    /// </summary>
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseWordRegex().Matches(sender)
            .Select(m => m.Value));
    
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CamelCaseWordRegex();
}