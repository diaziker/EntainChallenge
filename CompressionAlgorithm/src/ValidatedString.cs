using System.Text.RegularExpressions;

namespace CompressionAlgorithm;

public readonly struct ValidatedString
{
    public string Value { get; }

    private ValidatedString(string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? input, out ValidatedString validatedString)
    {
        if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, "^[a-zA-Z]+$"))
        {
            validatedString = new ValidatedString(input);
            return true;
        }

        validatedString = default;
        return false;
    }
}