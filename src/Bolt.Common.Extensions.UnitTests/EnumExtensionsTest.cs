using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using Xunit;

namespace Bolt.Common.Extensions.UnitTests
{
    [TestFixture]
    public class EnumExtensionsTest
    {
        [TestCase("", null)]
        [TestCase(null, null)]
        [TestCase("red", Color.Red)]
        [TestCase("Red", Color.Red)]
        [TestCase("reds", null)]
        public void ToEnumTest(string source, Color? expectedResult)
        {
            source.ToEnum<Color>().ShouldBe(expectedResult);
        }

        [TestCase(null, Color.None)]
        [TestCase(Color.Red, Color.Red)]
        public void NullSafeTest(Color? source, Color expected)
        {
            source.NullSafe().ShouldBe(expected);
        }
    }

    public enum Color
    {
        None = 0,
        Red = 1,
        Green = 2,
        Blue = 3
    }
}
