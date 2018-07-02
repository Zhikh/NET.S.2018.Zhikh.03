using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
        public static int FindGCDEuclidean(int firstValue, int secondValue)
        {
            int temp;

            while (firstValue != 0)
            {
                temp = firstValue;
                firstValue = secondValue % firstValue;
                secondValue = temp;
            }

            return Math.Abs(secondValue);
        }

        public static int FindGCDEuclidean(int firstValue, int secondValue, int thirdValue)
        {
            int gcd = FindGCDEuclidean(firstValue, secondValue);

            return FindGCDEuclidean(gcd, thirdValue);
        }

        public static int FindGCDEuclidean(int firstValue, int secondValue, int thirdValue, int fourthValue)
        {
            int gcd = FindGCDEuclidean(firstValue, secondValue, thirdValue);

            return FindGCDEuclidean(gcd, fourthValue);
        }

        public static int FindGCDEuclidean(params int[] values)
        {
            int gcd = 0;

            foreach (var value in values)
            {
                gcd = FindGCDEuclidean(gcd, value);
            }

            return gcd;
        }
    }
}
