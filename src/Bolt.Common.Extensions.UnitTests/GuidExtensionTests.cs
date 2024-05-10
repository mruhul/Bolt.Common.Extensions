using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class GuidExtensionTests
    {
        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenEmpty()
        {
            Assert.True(Guid.Empty.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenNull()
        {
            Guid? nullableGuid = null;
            Assert.True(nullableGuid.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse()
        {
            Assert.False(Guid.NewGuid().IsEmpty());
        }

        [Fact]
        public void HasValue_ShouldReturnTrue()
        {
            Assert.True(Guid.NewGuid().HasValue());
        }

        [Fact]
        public void HasValue_ShouldReturnFalse_WhenEmpty()
        {
            Assert.False(Guid.Empty.HasValue());
        }

        [Fact]
        public void HasValue_ShouldReturnFalse_WhenNull()
        {
            Guid? nullableGuid = null;
            Assert.False(nullableGuid.HasValue());
        }
    }
}