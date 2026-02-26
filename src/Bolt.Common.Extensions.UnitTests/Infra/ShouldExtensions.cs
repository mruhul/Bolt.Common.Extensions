using Shouldly;

namespace Bolt.Common.Extensions.UnitTests.Infra
{
    public static class ShouldExtensions
    {
        public static void ShouldMatchApprovedDefault(this string source, string? discriminator = null)
        {
            source.ShouldMatchApproved(c =>
            {
                c.UseCallerLocation();
                c.SubFolder("approved");
                if (discriminator != null) c.WithDiscriminator(discriminator);
            });
        }
    }
}
