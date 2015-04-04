using NUnit.Framework;
using Shouldly;

namespace Bolt.Common.Extensions.UnitTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase(null, null, true)]
        [TestCase("", null, false)]
        [TestCase("", "", true)]
        [TestCase("hEllo world!", "Hello World!", true)]
        [TestCase("same", "same", true)]
        [TestCase("same", "same ", false)]
        [TestCase("same", "samed", false)]
        public void IsSameTests(string source, string compareWith, bool expectedResult)
        {
            source.IsSame(compareWith).ShouldBe(expectedResult);
        }

        [Test]
        public void JoinTests()
        {
            string[] data = new []{"Kingsville","3012"};

            data.NullSafe().Join(",").ShouldBe("Kingsville,3012");
        }

        [Test]
        public void DescriptionTests()
        {
            Color.Red.Description().ShouldBe("Red Color");
            Color.Green.Description().ShouldBe("Green");
        }

        [TestCase("Hello World ", "hello-world")]
        [TestCase("Hello World--", "hello-world")]
        [TestCase("Hello--World", "hello-world")]
        public void ToSlugTests(string input, string expected)
        {
            input.ToSlug().ShouldBe(expected);
        }
    }
}