using Bolt.Common.Extensions.FluentUrls;

namespace Bolt.Common.Extensions;

public static class BuildUrl
{
    public static IHaveUrl From(string url, bool assumeUrlQueryParamsEncoded = false)
    {
        return new FluentUrlBuilder(url, assumeUrlQueryParamsEncoded);
    }
}
