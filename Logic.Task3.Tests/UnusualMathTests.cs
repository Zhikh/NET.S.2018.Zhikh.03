using System;
using NUnit.Framework;

namespace Logic.Task3.Tests
{
    [TestFixture]
    public class UnusualMathTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(0, ExpectedResult = -1)]
        public int FindNextBiggerNumber_Integer_CorrectResult(int value)
        {
            int actual = 0;

            UnusualMath.FindNextBiggerNumber(value, ref actual);

            return actual;
        }

        [TestCase(-231)]
        public void FindNextBiggerNumber_Integer_ArgumentException(int value)
        {
            int actual = 0;

            Assert.Throws<ArgumentException>(() => UnusualMath.FindNextBiggerNumber(value, ref actual));
        }
    }
}
