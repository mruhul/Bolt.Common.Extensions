using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests;

public class GuidExtensionTests
{
    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenEmpty()
    {
        Guid.Empty.IsEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenNull()
    {
        NullGuid().IsEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse()
    {
        Guid.NewGuid().IsEmpty().ShouldBeFalse();
    }

    [Fact]
    public void HasValue_ShouldReturnTrue()
    {
        Guid.NewGuid().HasValue().ShouldBeTrue();
    }

    [Fact]
    public void HasValue_ShouldReturnFalse_WhenEmpty()
    {
        Guid.Empty.HasValue().ShouldBeFalse();
    }

    [Fact]
    public void HasValue_ShouldReturnFalse_WhenNull()
    {
        NullGuid().HasValue().ShouldBeFalse();
    }

    private Guid? NullGuid() => null;
}