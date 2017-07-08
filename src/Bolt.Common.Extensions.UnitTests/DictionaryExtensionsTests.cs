using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void GetValueOrDefaultTest()
        {
            var source = new Dictionary<string, string> {{"name", "ruhul"}};

            source.GetValueOrDefault("name").ShouldBe("ruhul");
            source.GetValueOrDefault("postcode").ShouldBe(null);
            source.GetValueOrDefault("postcode", "3000").ShouldBe("3000");
        }
    }
}