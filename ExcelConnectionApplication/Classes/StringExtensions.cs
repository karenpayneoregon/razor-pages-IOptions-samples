namespace ExcelConnectionApplication.Classes;
public static class StringExtensions
{

    /// <summary>
    /// Splits a PascalCase or camelCase string into separate words by inserting spaces before uppercase letters.
    /// </summary>
    /// <param name="input">The input string to be split.</param>
    /// <returns>A new string with spaces inserted before uppercase letters, or the original string if it is null or empty.</returns>
    public static string SplitCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();

    }
}
