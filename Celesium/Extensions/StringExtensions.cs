using System.Text.RegularExpressions;

namespace CopperDevs.Celesium;

public static partial class StringExtensions
{
    extension(string input)
    {
        public string ToTitleCase()
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var result = TitleCaseRegex().Replace(input, " $1");

            result = char.ToUpper(result[0]) + result[1..].ToLower();
            return result;
        }

        public string ToKebabCase()
        {
            return string.IsNullOrEmpty(input)
                ? input
                : KebabCaseRegex().Replace(input, "-$1").ToLower();
        }
    }

    [GeneratedRegex("(\\B[A-Z])")]
    private static partial Regex TitleCaseRegex();

    [GeneratedRegex(@"(?<!^)(?<!-)((?<=\p{Ll})\p{Lu}|\p{Lu}(?=\p{Ll}))")]
    private static partial Regex KebabCaseRegex();
}