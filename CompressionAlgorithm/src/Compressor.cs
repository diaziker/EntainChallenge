using System.Text;

namespace CompressionAlgorithm;

public static class Compressor
{
    public static string StringCompress(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var output = new StringBuilder();
        var previousChar = input[0];
        var actualCharCount = 0;

        foreach (var character in input)
        {
            if (character != previousChar)
            {
                output.Append($"{actualCharCount}{previousChar}");
                actualCharCount = 0;
                previousChar = character;
            }

            actualCharCount++;
        }

        output.Append($"{actualCharCount}{previousChar}");
        
        return output.ToString();
    }
}