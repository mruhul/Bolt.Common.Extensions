using Xunit;
using Shouldly;

namespace Bolt.Common.Extensions.UnitTests
{
    public class NullSafeExtensionsTests
    {
        [InlineData(null, 0)]
        [InlineData(1, 1)]
        public void NullIntTests(int? source, int expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }

        [InlineData(null, 1, 1)]
        [InlineData(2, 1, 2)]
        public void ValueOrDefaultTests(int? source, int defaultValue, int expectedValue)
        {
            source.NullSafe(defaultValue).ShouldBe(expectedValue);
        }

        [InlineData(null, false)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void NullBoolTests(bool? source, bool expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }

        [InlineData(null, Color.None)]
        [InlineData(Color.Red, Color.Red)]
        public void NullEnumTests(Color? source, Color expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }
    }
}