using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class Base64ExtensionsTests
    {
        [Theory]
        [InlineData("Hello", "SGVsbG8=")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void EncodeBas64Test(string givenUtf8, string expected)
        {
            var gotEncoded = givenUtf8.Base64Encode();
            gotEncoded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("SGVsbG8=", "Hello")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void DecodeBas64Test(string givenBase64, string expected)
        {
            var gotEncoded = givenBase64.Base64Decode();
            gotEncoded.ShouldBe(expected);
        }
    }
}
