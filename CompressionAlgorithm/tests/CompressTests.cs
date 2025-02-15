using CompressionAlgorithm;
using FluentAssertions;

namespace CompressionAlgorithmTests;

public class CompressTests
{
    [Theory]
    [InlineData("AA", "2A")]
    [InlineData("AAB", "2A1B")]
    [InlineData("AAABBCCCCDDABC", "3A2B4C2D1A1B1C")]
    [InlineData("CCCACABBDD", "3C1A1C1A2B2D")]
    [InlineData("A", "1A")]
    [InlineData("BBBBB", "5B")]
    [InlineData("ABABAB", "1A1B1A1B1A1B")]
    [InlineData("", "")]
    public void CompressString_ShouldReturnExpectedOutput(string input, string expectedOutput)
    {
        string result = Compressor.StringCompress(input);
        
        result.Should().Be(expectedOutput);
    }
}