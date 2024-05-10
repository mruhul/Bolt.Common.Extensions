using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests;

public class BoolExtensionsTests
{
    [Theory]
    [InlineData("When source is null", null, null)]
    [InlineData("When source is empty", "", null)]
    [InlineData("When source is number", "1", null)]
    [InlineData("When source is alpha", "abc", null)]
    [InlineData("When source is string as true", "true", true)]
    [InlineData("When source is string as True", "true", true)]
    [InlineData("When source is string as false", "false", false)]
    [InlineData("When source is string as False", "False", false)]
    public void ToBooleanReturnCorrectResult(string scenario, string? given, bool? expected)
    {
        given.ToBoolean().ShouldBe(expected, scenario);
    }
}