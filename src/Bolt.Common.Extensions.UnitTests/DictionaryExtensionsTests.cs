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

            source.TryGetValueOrDefault("name").ShouldBe("ruhul");
            source.TryGetValueOrDefault("postcode").ShouldBe(null);
            source.TryGetValueOrDefault("postcode", "3000").ShouldBe("3000");
        }
    }
}