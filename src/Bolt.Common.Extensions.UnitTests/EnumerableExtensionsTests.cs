using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests;

public class EnumerableExtensionsTests
{
    [Fact]
    public void IsEmptyReturnsTrueWhenNull()
    {
        IEnumerable<string>? collection = null;

        collection.IsEmpty().ShouldBe(true);
    }

    [Fact]
    public void IsEmptyReturnsTrueWhenEmpty()
    {
        List<string> collection = [];

        collection.IsEmpty().ShouldBe(true);
    }

    [Fact]
    public void IsEmptyReturnsFalseWhenNotEmpty()
    {
        var collection = new List<string> { "1" };

        collection.IsEmpty().ShouldBe(false);
    }


    [Fact]
    public void HasItemReturnsFalseWhenNull()
    {
        IEnumerable<string>? collection = null;

        collection.HasItem().ShouldBe(false);
    }

    [Fact]
    public void HasItemReturnsFalseWhenEmpty()
    {
        var collection = new List<string>();

        collection.HasItem().ShouldBe(false);
    }

    [Fact]
    public void HasItemReturnsTrueWhenNotEmpty()
    {
        var collection = new List<string> { "1" };

        collection.HasItem().ShouldBe(true);
    }

    [Fact]
    public void ContainsIgnoreCaseReturnFalseWhenCollectionIsNull()
    {
        List<string> collection = null;

        collection.ContainsIgnoreCase("test").ShouldBe(false);
    }

    [Fact]
    public void ContainsIgnoreCaseReturnFalseWhenValueIsNull()
    {
        List<string> collection = new List<string>
        {
            "test"
        };

        collection.ContainsIgnoreCase(null).ShouldBe(false);
    }



    [Fact]
    public void ContainsIgnoreCaseReturnFalseWhenValueIsEmpty()
    {
        List<string> collection = new List<string>
        {
            "test"
        };

        collection.ContainsIgnoreCase(string.Empty).ShouldBe(false);
    }

    [Fact]
    public void ContainsIgnoreCaseReturnFalseWhenCollectionDoesntContainsTheValue()
    {
        List<string> collection = new List<string>
        {
            "test-1"
        };

        collection.ContainsIgnoreCase("test").ShouldBe(false);
    }

    [Fact]
    public void ContainsIgnoreCaseReturnTrueWhenCollectionContainsTheValueWithSameCase()
    {
        List<string> collection = new List<string>
        {
            "test-1",
            "test"
        };

        collection.ContainsIgnoreCase("test").ShouldBe(true);
    }


    [Fact]
    public void ContainsIgnoreCaseReturnTrueWhenCollectionContainsTheValueWithDifferentCase()
    {
        List<string> collection = new List<string>
        {
            "test-1",
            "TEst"
        };

        collection.ContainsIgnoreCase("test").ShouldBe(true);
    }

    [Fact]
    public void ContainsAnyIgnoreCaseReturnTrueWhenOneItemMatch()
    {
        var collection = new List<string>
        {
            "one",
            "two",
            "three"
        };

        collection.ContainsIgnoreCaseAny("Two", "three").ShouldBeTrue();
    }
    
    


    [Theory]
    [InlineData(null, "", null)]
    [InlineData(new[]{"test"}, "", "test")]
    [InlineData(new[]{"test", null}, ", ", "test")]
    [InlineData(new[]{"first", null, "", "last"}, ",", "first,last")]
    [InlineData(new String[]{}, ",", "")]
    public void JoinNonEmptyValuesTests(IEnumerable<string?>? source, string separator, string? expected)
    {
        var got = source.JoinNonEmptyValues(separator);
        got.ShouldBe(expected);
    }
}