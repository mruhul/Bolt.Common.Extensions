using System;
using Shouldly;
using Xunit;


namespace Bolt.Common.Extensions.UnitTests
{
    public static class DateTimeExtensionsTests
    {
        [Fact]
        public static void ToUnixTimeSecondsTests()
        {
            var now = DateTime.UtcNow;
            var dataTimeOffset = new DateTimeOffset(now);

            now.ToUnixTimeSeconds().ShouldBe(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }

        [Fact]
        public static void ToUnixTimeMillisecondsTests()
        {
            var now = DateTime.UtcNow;
            var dateTimeOffset = new DateTimeOffset(now);

            now.ToUnixTimeMilliseconds().ShouldBe(dateTimeOffset.ToUnixTimeMilliseconds());
        }

        [Fact]
        public static void ToDateTimeTests()
        {
            var dateStr = "2015-04-04";
            var date = dateStr.ToDateTime();
            date.ShouldBe(new DateTime(2015, 4, 4));

            dateStr = "04/03/2015";
            date = dateStr.ToDateTime();
            date.ShouldBe(new DateTime(2015, 4, 3));

            dateStr = "04/03/2015";
            date = dateStr.ToDateTime("dd/MM/yyyy");
            date.ShouldBe(new DateTime(2015,3,4));
        }

        [Fact]
        public static void ToUtcDateTimeTests()
        {
            var utcDateFromUtcDateString = "2021-07-10T12:40:21.3389002Z";
            var utcDateFromLocalDateString = "2021-07-10T22:40:21.3389002+10:00";

            var utcDateFromUtcString = utcDateFromUtcDateString.ToUtcDateTime();
            var utcDateFromLocalString = utcDateFromLocalDateString.ToUtcDateTime();

            utcDateFromUtcString.ShouldBe(utcDateFromLocalString);
        }

        [Fact]
        public static void FormatAsUtcTests()
        {
            var utcDateAsString = "2021-07-10T12:40:21.3389002Z";
            var dateAsString = "2021-07-10T22:40:21.3389002+10:00";

            var utcDate = DateTime.Parse(utcDateAsString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind);
            var localDate = DateTime.Parse(dateAsString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind);

            var utcDateString = utcDate.FormatAsUtc();
            var localDateString = localDate.FormatAsUtc();

            utcDateString.ShouldBe(localDateString);
        }
    }
}