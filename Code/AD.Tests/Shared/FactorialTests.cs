using System;
using FluentAssertions;
using Xunit;

namespace AD.Tests.Shared;

public static class FactorialTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    [InlineData(6, 720)]
    [InlineData(10, 3_628_800)]
    public static void CalculateFactorial(int input, int expectedResult)
    {
        var actualResult = CommonMath.CalculateFactorial(input);

        actualResult.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-1000)]
    public static void InvalidFactorialInput(int invalidInput)
    {
        var act = () => CommonMath.CalculateFactorial(invalidInput);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(15)]
    [InlineData(14)]
    [InlineData(13)]
    public static void ResultTooLargeForInt32(int invalidInput)
    {
        var act = () => CommonMath.CalculateFactorial(invalidInput);

        act.Should().Throw<OverflowException>();
    }
}