using System;
using NUnit.Framework;

namespace Logic.Task2.Tests
{
    [TestFixture]
    class AdditionalMathPackTests
    {
        [TestCase(1, 3, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_Integer_Tree_FourSing(double value, int degree, double eps) 
            => value.FindNthRoot(degree, eps);

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -0.0001)]
        public void FindNthRoot_Value_Degree_Precision_ArgumentException(double value, int degree, double eps) 
            => Assert.Throws<ArgumentException>(() => value.FindNthRoot(degree, eps));
    }
}
