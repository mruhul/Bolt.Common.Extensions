using Xunit;
using Shouldly;
using System.Collections.Generic;

namespace Bolt.Common.Extensions.UnitTests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData(null, null, true)]
        [InlineData("", null, false)]
        [InlineData("", "", true)]
        [InlineData("hEllo world!", "Hello World!", true)]
        [InlineData("same", "same", true)]
        [InlineData("same", "same ", false)]
        [InlineData("same", "samed", false)]
        public void IsSameTests(string source, string compareWith, bool expectedResult)
        {
            source.IsSame(compareWith).ShouldBe(expectedResult);
        }

        [Fact]
        public void JoinTests()
        {
            string[] data = new []{"Kingsville","3012"};

            data.NullSafe().Join(",").ShouldBe("Kingsville,3012");
        }

        [Fact]
        public void DescriptionTests()
        {
            Color.Red.Description().ShouldBe("Red Color");
            Color.Green.Description().ShouldBe("Green");
        }

        [Theory]
        [InlineData("Hello World ", "hello-world")]
        [InlineData("Hello World--", "hello-world")]
        [InlineData("Hello--World", "hello-world")]
        public void ToSlugTests(string input, string expected)
        {
            input.ToSlug().ShouldBe(expected);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", null, null)]
        [InlineData(" ", null, null)]
        [InlineData(null, "hello", "hello")]
        [InlineData("", "hello", "hello")]
        [InlineData(" ", "hello", "hello")]
        public void EmptyAlternativeTest(string value, string alt, string exp)
        {
            value.EmptyAlternative(alt).ShouldBe(exp);
        }

        [Theory]
        [InlineData(null, null, false)]
        [InlineData(null, "", false)]
        [InlineData("", null, false)]
        [InlineData("", "", true)]
        [InlineData("Test", "te", true)]
        [InlineData("Test", "Te", true)]
        [InlineData("Test", "", true)]
        public void StartsWithIgnoreCaseTest(string input, string startsWithValue, bool expected)
        {
            var got = input.StartsWithIgnoreCase(startsWithValue);
            got.ShouldBe(expected);
        }



        [Theory]
        [InlineData(null, null, false)]
        [InlineData(null, "", false)]
        [InlineData("", null, false)]
        [InlineData("", "", true)]
        [InlineData("Test", "te", true)]
        [InlineData("Test", "Te", true)]
        [InlineData("Test", "es", true)]
        [InlineData("Test", "ES", true)]
        [InlineData("Test", "", true)]
        public void ContainsIgnoreCaseTest(string input, string startsWithValue, bool expected)
        {
            var got = input.ContainsIgnoreCase(startsWithValue);
            got.ShouldBe(expected);
        }


        [Fact]
        public void IsSameAnyReturnFalseWhenAtleastOneMatch()
        {
            "test".IsSameAny("hello", "teST").ShouldBeTrue();
        }

        [Fact]
        public void IsEndWithTest()
        {
            var sut = "Hello world";
            sut.EndsWithIgnoreCase("WORLD").ShouldBeTrue();
        }

        [Theory]
        [InlineData(null, 10, null, null)]
        [InlineData(null, 0, null, null)]
        [InlineData(null, 0, "...", null)]
        [InlineData("", 10, null, "")]
        [InlineData("", 0, null, "")]
        [InlineData("", 0, "...", "")]
        [InlineData("test", 5, null, "test")]
        [InlineData("test", 2, null, "te")]
        [InlineData("test", 2, "...", "te...")]
        public void TruncateTest(string sut, int maxLength, string postFix, string expected)
        {
            var got = sut.Truncate(maxLength, postFix);
            got.ShouldBe(expected);
        }


        [Theory]
        [InlineData(null, "", null)]
        [InlineData(new[]{"test"}, "", "test")]
        [InlineData(new[]{"test", null}, ", ", "test")]
        [InlineData(new[]{"first", null, "", "last"}, ",", "first,last")]
        [InlineData(new String[]{}, ",", "")]
        public void JoinNonEmptyValuesTests(IEnumerable<string> source, string separator, string expected)
        {
            var got = source.JoinNonEmptyValues(separator);
            got.ShouldBe(expected);
        }
    }
}