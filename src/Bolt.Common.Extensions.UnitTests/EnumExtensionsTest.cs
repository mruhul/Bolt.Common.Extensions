using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class EnumExtensionsTest
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData("red", Color.Red)]
        [InlineData("Red", Color.Red)]
        [InlineData("reds", null)]
        public void ToEnumTest(string source, Color? expectedResult)
        {
            source.ToEnum<Color>().ShouldBe(expectedResult);
        }

        [InlineData(null, Color.None)]
        [InlineData(Color.Red, Color.Red)]
        public void NullSafeTest(Color? source, Color expected)
        {
            source.NullSafe().ShouldBe(expected);
        }
    }

    public enum Color
    {
        None = 0,
        [System.ComponentModel.Description("Red Color")]
        Red = 1,
        Green = 2,
        Blue = 3
    }
}
