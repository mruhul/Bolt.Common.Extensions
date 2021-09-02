using System;
using Bolt.Common.Extensions.UnitTests.Infra;
using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class JsonExtensionsTests
    {
        [Fact]
        public void ToJsonTest()
        {
            var person = new Person
            {
                Name = "test-name",
                Age = 58,
                CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            var serializedData = person.SerializeToJson();

            serializedData.ShouldMatchApprovedDefault();
        }

        [Fact]
        public void ToPrettyJsonTest()
        {
            var person = new Person
            {
                Name = "test-name",
                Age = 58,
                CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            var serializedData = person.SerializeToPrettyJson();

            serializedData.ShouldMatchApprovedDefault();
        }

        [Fact]
        public void FromJsonTest()
        {
            var person = new Person
            {
                Name = "test-name",
                Age = 58,
                CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            var serializedData = person.SerializeToJson();

            var result = serializedData.DeserializeFromJson<Person>();

            result.ShouldSatisfyAllConditions
            (
                () => result.Name.ShouldBe(person.Name),
                () => result.Age.ShouldBe(person.Age),
                () => result.CreatedAt.ShouldBe(person.CreatedAt)
            );
        }
    }

    public record Person
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
