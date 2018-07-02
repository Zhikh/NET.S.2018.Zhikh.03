using System;

namespace Logic.Task4
{
    public static class GreatestCommonDivisor
    {
        public delegate int FindGCDAlgorithm(int x, int y);
        #region Euclidean

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

        #region дублирующийся код
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
        #endregion
        #endregion

        #region Stein
        public static int FindGCDStein(int firstValue, int secondValue)
        {
            
        }
        #endregion

        #region дублирующийся код
        public static int FindGCDStein(int firstValue, int secondValue, int thirdValue, FindGCDAlgorithm callback)
        {
            int gcd = callback(firstValue, secondValue);

            return callback(gcd, thirdValue);
        }

        public static int FindGCDStein(int firstValue, int secondValue, int thirdValue, int fourthValue, FindGCDAlgorithm callback)
        {
            int gcd = FindGCDStein(firstValue, secondValue, thirdValue, callback);

            return callback(gcd, fourthValue);
        }

        public static int FindGCDStein(FindGCDAlgorithm callback, params int[] values)
        {
            int gcd = 0;

            foreach (var value in values)
            {
                gcd = callback(gcd, value);
            }

            return gcd;
        }
        #endregion
    }
}
