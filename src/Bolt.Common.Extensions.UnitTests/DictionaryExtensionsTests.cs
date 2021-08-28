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

        [Fact]
        public void MergeTests()
        {
            var baseStore = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newStore = new Dictionary<string, string>
            {
                ["four"] = "4",
                ["two"] = "-2-"
            };

            var result = baseStore.Merge(newStore);

            result.Count.ShouldBe(4);
            result["one"].ShouldBe("1");
            result["two"].ShouldBe("-2-");
            result["three"].ShouldBe("3");
            result["four"].ShouldBe("4");
        }

        [Fact]
        public void MergeTestsWhenIgnoreExistingIsTru()
        {
            var baseStore = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newStore = new Dictionary<string, string>
            {
                ["four"] = "4",
                ["two"] = "-2-"
            };

            var result = baseStore.Merge(newStore, ignoreWhenAlreadyExists: true);

            result.Count.ShouldBe(4);
            result["one"].ShouldBe("1");
            result["two"].ShouldBe("2");
            result["three"].ShouldBe("3");
            result["four"].ShouldBe("4");
        }

        [Fact]
        public void MergeIgnoreCaseTests()
        {
            var baseStore = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newStore = new Dictionary<string, string>
            {
                ["four"] = "4",
                ["Two"] = "-2-"
            };

            var result = baseStore.MergeIgnoreCase(newStore);

            result.Count.ShouldBe(4);
            result["one"].ShouldBe("1");
            result["Two"].ShouldBe("-2-");
            result["three"].ShouldBe("3");
            result["four"].ShouldBe("4");
        }

        [Fact]
        public void MergeIgnoreCaseTestsWhenIgnoreExistingIsTrue()
        {
            var baseStore = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newStore = new Dictionary<string, string>
            {
                ["four"] = "4",
                ["Two"] = "-2-"
            };

            var result = baseStore.MergeIgnoreCase(newStore, true);

            result.Count.ShouldBe(4);
            result["one"].ShouldBe("1");
            result["two"].ShouldBe("2");
            result["three"].ShouldBe("3");
            result["four"].ShouldBe("4");
        }

        [Fact]
        public void AppendTests()
        {
            var source = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newSource = new Dictionary<string, string>
            {
                ["two"] = "-2-",
                ["four"] = "4"
            };

            _ = source.Append(newSource);

            source.Count.ShouldBe(4);
            source["one"].ShouldBe("1");
            source["two"].ShouldBe("-2-");
            source["three"].ShouldBe("3");
            source["four"].ShouldBe("4");
        }

        [Fact]
        public void AppendTestsWhenIgnoreExistingKey()
        {
            var source = new Dictionary<string, string>
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3"
            };

            var newSource = new Dictionary<string, string>
            {
                ["two"] = "-2-",
                ["four"] = "4"
            };

            _ = source.Append(newSource, true);

            source.Count.ShouldBe(4);
            source["one"].ShouldBe("1");
            source["two"].ShouldBe("2");
            source["three"].ShouldBe("3");
            source["four"].ShouldBe("4");
        }
    }
}