using System;
using NUnit.Framework;

namespace Logic.Task4.Tests
{
    [TestFixture]
    public class GreatestCommonDivisorTests
    {
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(11, 11, ExpectedResult = 11)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(2, -10, ExpectedResult = 2)]
        [TestCase(661, 113, ExpectedResult = 1)]
        public int FindGCDEuclidean_TwoParams_CorrectResult(int firstValue, int secondValue)
            => GreatestCommonDivisor.FindGCDEuclidean(firstValue, secondValue);

        [TestCase(1, 10, 12, ExpectedResult = 1)]
        [TestCase(5, 10, 45, ExpectedResult = 5)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(0, 5, 0, ExpectedResult = 5)]
        [TestCase(1, 10, 0, ExpectedResult = 1)]
        [TestCase(2, -10, -40, ExpectedResult = 2)]
        [TestCase(661, 113, 333, ExpectedResult = 1)]
        public int FindGCDEuclidean_ThreeParams_CorrectResult(int firstValue, int secondValue, int thirdValue)
            => GreatestCommonDivisor.FindGCDEuclidean(firstValue, secondValue, thirdValue);

        [TestCase(17, 17, 17, 17, ExpectedResult = 17)]
        [TestCase(15, 10, 7, 7, ExpectedResult = 1)]
        [TestCase(2, 6, 8, 7, ExpectedResult = 1)]
        [TestCase(20, 10, 25, 40, ExpectedResult = 5)]
        [TestCase(-30, 7, 77, 88, ExpectedResult = 1)]
        [TestCase(9, 3, -21, -7, ExpectedResult = 1)]
        [TestCase(1, 0, 0, 0, ExpectedResult = 1)]
        [TestCase(0, -10, 0, 0, ExpectedResult = 10)]
        [TestCase(-9, 0, 0, 0, ExpectedResult = 9)]
        [TestCase(111, 222, 333, 444, ExpectedResult = 111)]
        public int FindGCDEuclidean_FourParams_CorrectResult(int firstValue, int secondValue, int thirdValue, int fourthValue)
           => GreatestCommonDivisor.FindGCDEuclidean(firstValue, secondValue, thirdValue, fourthValue);

        [TestCase(777, 7, 111, 7, 7, ExpectedResult = 1)]
        [TestCase(555, 10, 5, 25, 15, 5, ExpectedResult = 5)]
        [TestCase(842, 1000, 8, 16, 8, ExpectedResult = 2)]
        [TestCase(-1, 0, 0, 0, 0, 0, 2, ExpectedResult = 1)]
        [TestCase(-30, -7, -77, -88, -1, 0, ExpectedResult = 1)]
        [TestCase(9, 3, -21, -7, 55, ExpectedResult = 1)]
        [TestCase(1, 0, 0, 0, 11, 12, ExpectedResult = 1)]
        [TestCase(0, -10, 0, 0, 10, 100, 0, ExpectedResult = 10)]
        [TestCase(-9, 0, 0, 0, 0, 0, ExpectedResult = 9)]
        [TestCase(111, 222, 333, 444, 555, ExpectedResult = 111)]
        [TestCase(0, 0, int.MinValue + 1, 0, 0, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int FindGCDEuclidean_NParams_CorrectResult(params int[] values)
           => GreatestCommonDivisor.FindGCDEuclidean(values);

        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(11, 11, ExpectedResult = 11)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(2, -10, ExpectedResult = 2)]
        [TestCase(661, 113, ExpectedResult = 1)]
        public int FindGCDStein_TwoParams_CorrectResult(int firstValue, int secondValue)
            => GreatestCommonDivisor.FindGCDEuclidean(firstValue, secondValue);

        [TestCase(1, 10, 12, ExpectedResult = 1)]
        [TestCase(5, 10, 45, ExpectedResult = 5)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(0, 5, 0, ExpectedResult = 5)]
        [TestCase(1, 10, 0, ExpectedResult = 1)]
        [TestCase(2, -10, -40, ExpectedResult = 2)]
        [TestCase(661, 113, 333, ExpectedResult = 1)]
        public int FindGCDStein_ThreeParams_CorrectResult(int firstValue, int secondValue, int thirdValue)
            => GreatestCommonDivisor.FindGCDStein(firstValue, secondValue, thirdValue);

        [TestCase(17, 17, 17, 17, ExpectedResult = 17)]
        [TestCase(15, 10, 7, 7, ExpectedResult = 1)]
        [TestCase(2, 6, 8, 7, ExpectedResult = 1)]
        [TestCase(20, 10, 25, 40, ExpectedResult = 5)]
        [TestCase(-30, 7, 77, 88, ExpectedResult = 1)]
        [TestCase(9, 3, -21, -7, ExpectedResult = 1)]
        [TestCase(1, 0, 0, 0, ExpectedResult = 1)]
        [TestCase(0, -10, 0, 0, ExpectedResult = 10)]
        [TestCase(-9, 0, 0, 0, ExpectedResult = 9)]
        [TestCase(111, 222, 333, 444, ExpectedResult = 111)]
        public int FindGCDStein_FourParams_CorrectResult(int firstValue, int secondValue, int thirdValue, int fourthValue)
           => GreatestCommonDivisor.FindGCDStein(firstValue, secondValue, thirdValue, fourthValue);

        [TestCase(777, 7, 111, 7, 7, ExpectedResult = 1)]
        [TestCase(555, 10, 5, 25, 15, 5, ExpectedResult = 5)]
        [TestCase(842, 1000, 8, 16, 8, ExpectedResult = 2)]
        [TestCase(-1, 0, 0, 0, 0, 0, 2, ExpectedResult = 1)]
        [TestCase(-30, -7, -77, -88, -1, 0, ExpectedResult = 1)]
        [TestCase(9, 3, -21, -7, 55, ExpectedResult = 1)]
        [TestCase(1, 0, 0, 0, 11, 12, ExpectedResult = 1)]
        [TestCase(0, -10, 0, 0, 10, 100, 0, ExpectedResult = 10)]
        [TestCase(-9, 0, 0, 0, 0, 0, ExpectedResult = 9)]
        [TestCase(111, 222, 333, 444, 555, ExpectedResult = 111)]
        [TestCase(0, 0, int.MinValue + 1, 0, 0, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int FindGCDStein_NParams_CorrectResult(params int[] values)
           => GreatestCommonDivisor.FindGCDStein(values);
    }
}
