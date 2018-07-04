using System;
using NUnit.Framework;

namespace Logic.Task2.Tests
{
    [TestFixture]
    class AdditionalMathPackTests
    {
        [TestCase(1, 3, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001,  0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_Integer_Tree_FourSing(double value, int degree, double eps, double expected)
        {
            Assert.AreEqual(expected, value.FindNthRoot(degree, eps), GetAccuracy(eps));
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -0.0001)]
        public void FindNthRoot_Value_Degree_Precision_ArgumentException(double value, int degree, double eps) 
            => Assert.Throws<ArgumentException>(() => value.FindNthRoot(degree, eps));

        private static int GetAccuracy(double eps)
        {
            int result = 0;

            while (eps != 1)
            {
                eps *= 10;

                result++;
            }

            return result;
        }

    }
}
