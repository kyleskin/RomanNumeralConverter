using FluentAssertions;
using RomanNumeralService;

namespace RomanNumeralServiceUnitTests;

public class RomanNumeralConvertUnitTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GivenANullOrEmptyValueIsPassedIn_ThenAnArgumentNullExceptionIsThrown(string? romanNumeral)
    {
        // Act
        Action act = () => RomanNumerals.ConvertRomanNumeral(romanNumeral);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenAnInvalidRomanNumeralIsPassedIn_ThenArgumentOutOfRangeExceptionIsThrow()
    {
        // Act
        Action act = () => RomanNumerals.ConvertRomanNumeral("P");

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    public void Convert_SingleNumeral(string romanNumeral, int expectedResult)
    {  
        // Act
        var result = RomanNumerals.ConvertRomanNumeral(romanNumeral);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("II", 2)]
    [InlineData("XX", 20)]
    [InlineData("CC", 200)]
    [InlineData("MM", 2000)]
    public void Convert_DoubleNumeral(string romanNumeral, int expectedResult)
    {  
        // Act
        var result = RomanNumerals.ConvertRomanNumeral(romanNumeral);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("VI", 6)]
    [InlineData("XV", 15)]
    [InlineData("CL", 150)]
    public void Convert_AddingNumerals(string romanNumeral, int expectedResult)
    {  
        // Act
        var result = RomanNumerals.ConvertRomanNumeral(romanNumeral);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XC", 90)]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    public void Convert_SubtractingFromNumerals(string romanNumeral, int expectedResult)
    {  
        // Act
        var result = RomanNumerals.ConvertRomanNumeral(romanNumeral);

        // Assert
        result.Should().Be(expectedResult);
    }
}