using NUnit.Framework;
using Shouldly;

namespace Bolt.Common.Extensions.UnitTests
{
    [TestFixture]
    public class NullSafeExtensionsTests
    {
        [TestCase(null, 0)]
        [TestCase(1, 1)]
        public void NullIntTests(int? source, int expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }

        [TestCase(null, false)]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void NullBoolTests(bool? source, bool expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }

        [TestCase(null, Color.None)]
        [TestCase(Color.Red, Color.Red)]
        public void NullEnumTests(Color? source, Color expectedValue)
        {
            source.NullSafe().ShouldBe(expectedValue);
        }
    }
}