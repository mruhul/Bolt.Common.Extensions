using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    public class UrlExtensionsTest
    {
        [Fact]
        public void fluent_build_should_work_as_expected()
        {
            var url = BuildUrl.From("/api/v1/books?key=fgh")
                .Path("/100/authors/")
                .Query("max", 1)
                .Query("columns","id,name")
                .Build();

            url.ShouldBe("/api/v1/books/100/authors/?key=fgh&max=1&columns=id%2Cname");
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_querystring_return_correct_result(UrlBuilderTestDto input)
        {
            var urlGot = BuildUrl.From(input.GivenUrl)
                .Path(input.GivenPaths)
                .Query(input.GivenQueryParams)
                .Build();

            urlGot.ShouldBe(input.Expected, input.Scenario);
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] {
                new UrlBuilderTestDto
                {
                    GivenUrl = "/",
                    GivenPaths = null!,
                    GivenQueryParams = null!,
                    Expected = "/",
                    Scenario = "When all empty"
                }
            },
            new object[] {
                new UrlBuilderTestDto
                {
                    GivenUrl = "https://hello-world",
                    GivenPaths = null!,
                    GivenQueryParams = null!,
                    Expected = "https://hello-world",
                    Scenario = "When all empty for full url"
                }
            },
            new object[] {
                new UrlBuilderTestDto
                {
                    GivenUrl = "/test/",
                    GivenPaths = ["/part1"],
                    GivenQueryParams = null!,
                    Expected = "/test/part1/",
                    Scenario = "When path provided"
                }
            },
            new object[] {
                new UrlBuilderTestDto
                {
                    GivenUrl = "/test",
                    GivenPaths = ["/part1/"],
                    GivenQueryParams = null!,
                    Expected = "/test/part1/",
                    Scenario = "When path provided that has slash start and end"
                }
            },
            new object[] {
                new UrlBuilderTestDto
                {
                    GivenUrl = "/test",
                    GivenPaths = new List<string>{"/part1/"},
                    GivenQueryParams = new Dictionary<string, string>
                    {
                        ["q1"] = "1",
                        [""]  = ""
                    },
                    Expected = "/test/part1/?q1=1",
                    Scenario = "When querystring provided"
                }
            },
        };

        public record UrlBuilderTestDto
        {
            public string GivenUrl { get; init; } = string.Empty;
            public List<string> GivenPaths { get; init; } = [];
            public Dictionary<string, string> GivenQueryParams { get; init; } = [];
            public string Expected { get; init; } = string.Empty;
            public string Scenario { get; init; } = string.Empty;
        }
    }
}
