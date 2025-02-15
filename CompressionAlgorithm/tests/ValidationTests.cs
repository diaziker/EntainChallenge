using CompressionAlgorithm;
using FluentAssertions;

namespace CompressionAlgorithmTests;

public class ValidationTests
{
    [Theory]
    [InlineData("AA", true)]
    [InlineData("AAB", true)]
    [InlineData("AAABBCCCCDDABC", true)]
    [InlineData("CCCACABBDD", true)]
    [InlineData("12345", false)]
    [InlineData("A1B2C3", false)]
    [InlineData("AA BB", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ValidateString_ShouldReturnExpectedResult(string input, bool expectedResult)
    {
        bool result = ValidatedString.TryCreate(input, out _);
        
        result.Should().Be(expectedResult);
    }
}